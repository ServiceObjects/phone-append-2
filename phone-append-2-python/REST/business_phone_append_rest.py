from pa2_response import PA2Response, PhoneInfo, Error
import requests
from typing import Optional

# Endpoint URLs for ServiceObjects BusinessPhoneAppend API
primary_url = "https://sws.serviceobjects.com/pa2/api.svc/json/BusinessPhoneAppendJson?"
backup_url = "https://swsbackup.serviceobjects.com/pa2/api.svc/json/BusinessPhoneAppendJson?"
trial_url = "https://trial.serviceobjects.com/pa2/api.svc/json/BusinessPhoneAppendJson?"

def get_business_phone_append(
    business_name: str,
    address: Optional[str] = None,
    city: str = None,
    state: str = None,
    postal_code: Optional[str] = None,
    license_key: str = None,
    is_live: bool = True
) -> PA2Response:
    """
    Call ServiceObjects BusinessPhoneAppend API to retrieve a phone number for a given business address.

    Parameters:
        business_name: The name of the business to retrieve the phone number for (e.g., "ServiceObjects").
        address: Address line of the business. Optional.
        city: The city of the business. Required.
        state: The state of the business. Required.
        postal_code: The postal code of the business. Optional.
        license_key: Your ServiceObjects license key.
        is_live: Use live or trial servers.

    Returns:
        PA2Response: Parsed JSON response with phone information or error details.

    Raises:
        RuntimeError: If the API returns an error payload.
        requests.RequestException: On network/HTTP failures (trial mode).
    """
    params = {
        "BusinessName": business_name,
        "Address": address,
        "City": city,
        "State": state,
        "PostalCode": postal_code,
        "LicenseKey": license_key,
    }
    # Select the base URL: production vs trial
    url = primary_url if is_live else trial_url

    try:
        # Attempt primary (or trial) endpoint
        response = requests.get(url, params=params, timeout=10)
        response.raise_for_status()
        data = response.json()

        # If API returned an error in JSON payload, trigger fallback
        error = data.get('Error')
        if not (error is None or error.get('TypeCode') != "3"):
            if is_live:
                # Try backup URL
                response = requests.get(backup_url, params=params, timeout=10)
                response.raise_for_status()
                data = response.json()

                # If still error, propagate exception
                if 'Error' in data:
                    raise RuntimeError(f"BusinessPhoneAppend service error: {data['Error']}")
            else:
                # Trial mode error is terminal
                raise RuntimeError(f"BusinessPhoneAppend trial error: {data['Error']}")

        # Convert JSON response to PA2Response for structured access
        error = Error(**data.get("Error", {})) if data.get("Error") else None

        return PA2Response(
            PhoneInfo=PhoneInfo(
                Phone=data.get("PhoneInfo", {}).get("Phone"),
                Name=data.get("PhoneInfo", {}).get("Name"),
                Address=data.get("PhoneInfo", {}).get("Address"),
                City=data.get("PhoneInfo", {}).get("City"),
                State=data.get("PhoneInfo", {}).get("State"),
                PostalCode=data.get("PhoneInfo", {}).get("PostalCode"),
                IsResidential=data.get("PhoneInfo", {}).get("IsResidential"),
                Certainty=data.get("PhoneInfo", {}).get("Certainty"),
                LineType=data.get("PhoneInfo", {}).get("LineType"),
                Debug=data.get("PhoneInfo", {}).get("Debug")
            ) if data.get("PhoneInfo") else None,
            Error=error
        )

    except requests.RequestException as req_exc:
        # Network or HTTP-level error occurred
        if is_live:
            try:
                # Fallback to backup URL
                response = requests.get(backup_url, params=params, timeout=10)
                response.raise_for_status()
                data = response.json()
                if "Error" in data:
                    raise RuntimeError(f"BusinessPhoneAppend backup error: {data['Error']}") from req_exc

                error = Error(**data.get("Error", {})) if data.get("Error") else None

                return PA2Response(
                    PhoneInfo=PhoneInfo(
                        Phone=data.get("PhoneInfo", {}).get("Phone"),
                        Name=data.get("PhoneInfo", {}).get("Name"),
                        Address=data.get("PhoneInfo", {}).get("Address"),
                        City=data.get("PhoneInfo", {}).get("City"),
                        State=data.get("PhoneInfo", {}).get("State"),
                        PostalCode=data.get("PhoneInfo", {}).get("PostalCode"),
                        IsResidential=data.get("PhoneInfo", {}).get("IsResidential"),
                        Certainty=data.get("PhoneInfo", {}).get("Certainty"),
                        LineType=data.get("PhoneInfo", {}).get("LineType"),
                        Debug=data.get("PhoneInfo", {}).get("Debug")
                    ) if data.get("PhoneInfo") else None,
                    Error=error
                )
            except Exception as backup_exc:
                raise RuntimeError("BusinessPhoneAppend service unreachable on both endpoints") from backup_exc
        else:
            raise RuntimeError(f"BusinessPhoneAppend trial error: {str(req_exc)}") from req_exc