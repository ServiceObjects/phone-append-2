from suds.client import Client
from suds import WebFault
from suds.sudsobject import Object
from typing import Optional

class PhoneAppendSoap:
    def __init__(self, license_key: str, is_live: bool = True, timeout_ms: int = 15000):
        """
        license_key: Service Objects PA2 license key.
        is_live: Whether to use live or trial endpoints.
        timeout_ms: SOAP call timeout in milliseconds.
        """
        self.is_live = is_live
        self.timeout = timeout_ms / 1000.0
        self.license_key = license_key

        # WSDL URLs
        self._primary_wsdl = (
            "https://sws.serviceobjects.com/PA2/api.svc?wsdl"
            if is_live
            else "https://trial.serviceobjects.com/PA2/api.svc?wsdl"
        )
        self._backup_wsdl = (
            "https://swsbackup.serviceobjects.com/PA2/api.svc?wsdl"
            if is_live
            else "https://trial.serviceobjects.com/PA2/api.svc?wsdl"
        )

    def get_phone_append(
        self,
        full_name: Optional[str] = None,
        first_name: Optional[str] = None,
        last_name: Optional[str] = None,
        address: Optional[str] = None,
        city: Optional[str] = None,
        state: Optional[str] = None,
        postal_code: Optional[str] = None
    ) -> Object:
        """
        Calls the PhoneAppend SOAP API to retrieve a phone number for a given residential contact.

        Parameters:
            full_name: The full name of the contact. Optional if first_name and last_name are provided.
            first_name: The first name of the contact. Optional if full_name is provided.
            last_name: The last name of the contact. Optional if full_name is provided.
            address: Address line of the contact. Optional.
            city: The city of the contact. Optional.
            state: The state of the contact. Optional.
            postal_code: The postal code of the contact. Optional.
            license_key: Your ServiceObjects license key.
            is_live: Determines whether to use the live or trial servers.
            timeout_ms: Timeout, in milliseconds, for the call to the service.

        Returns:
            suds.sudsobject.Object: SOAP response containing phone information or error details.

        Raises:
            RuntimeError: If both primary and backup endpoints fail or return invalid responses.
        """
        # Common kwargs for both calls
        call_kwargs = dict(
            FullName=full_name,
            FirstName=first_name,
            LastName=last_name,
            Address=address,
            City=city,
            State=state,
            PostalCode=postal_code,
            LicenseKey=self.license_key,
        )

        # Attempt primary
        try:
            client = Client(self._primary_wsdl)
            response = client.service.PhoneAppend(**call_kwargs)

            # If response invalid or Error.TypeCode == "3", trigger fallback
            if response is None or (
                hasattr(response, "Error")
                and response.Error
                and response.Error.TypeCode == "3"
            ):
                raise ValueError("Primary returned no result or Error.TypeCode=3")

            return response

        except (WebFault, ValueError, Exception) as primary_ex:
            # Attempt backup
            try:
                client = Client(self._backup_wsdl)
                response = client.service.PhoneAppend(**call_kwargs)
                if response is None:
                    raise ValueError("Backup returned no result")
                return response
            except (WebFault, Exception) as backup_ex:
                msg = (
                    "Both primary and backup endpoints failed.\n"
                    f"Primary error: {str(primary_ex)}\n"
                    f"Backup error: {str(backup_ex)}"
                )
                raise RuntimeError(msg)