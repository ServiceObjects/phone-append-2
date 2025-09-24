import sys
import os

sys.path.insert(0, os.path.abspath("../phone-append-2-python/SOAP"))

from business_phone_append_soap import BusinessPhoneAppendSoap

def business_phone_append_soap_sdk_go(is_live: bool, license_key: str) -> None:
    print("\r\n---------------------------------------------")
    print("PhoneAppend2 - BusinessPhoneAppend - SOAP SDK")
    print("---------------------------------------------")

    business_name = "Brooks Institute"
    address = "27 E Cota ST"
    city = "Santa Barbara"
    state = "CA"
    postal_code = "93101"
    timeout_seconds = 15

    print("\r\n* Input *\r\n")
    print(f"Business Name  : {business_name}")
    print(f"Address        : {address}")
    print(f"City           : {city}")
    print(f"State          : {state}")
    print(f"Postal Code    : {postal_code}")
    print(f"License Key    : {license_key}")
    print(f"Is Live        : {is_live}")
    print(f"Timeout Seconds: {timeout_seconds}")

    try:
        service = BusinessPhoneAppendSoap(license_key, is_live, timeout_seconds * 1000)
        response = service.get_business_phone_append(business_name, address, city, state, postal_code)

        if not hasattr(response, 'Error') or not response.Error:
            print("\r\n* Phone Info *\r\n")
            if hasattr(response, 'PhoneInfo') and response.PhoneInfo:
                print(f"Phone           : {getattr(response.PhoneInfo, 'Phone', None)}")
                print(f"Name            : {getattr(response.PhoneInfo, 'Name', None)}")
                print(f"Address         : {getattr(response.PhoneInfo, 'Address', None)}")
                print(f"City            : {getattr(response.PhoneInfo, 'City', None)}")
                print(f"State           : {getattr(response.PhoneInfo, 'State', None)}")
                print(f"Postal Code     : {getattr(response.PhoneInfo, 'PostalCode', None)}")
                print(f"Is Residential  : {getattr(response.PhoneInfo, 'IsResidential', None)}")
                print(f"Certainty       : {getattr(response.PhoneInfo, 'Certainty', None)}")
                print(f"Line Type       : {getattr(response.PhoneInfo, 'LineType', None)}")
            else:
                print("No phone info found.")
        else:
            print("No phone info found.")

        if hasattr(response, 'Error') and response.Error:
            print("\r\n* Error *\r\n")
            print(f"Error Type      : {getattr(response.Error, 'Type', None)}")
            print(f"Error Type Code : {getattr(response.Error, 'TypeCode', None)}")
            print(f"Error Desc      : {getattr(response.Error, 'Desc', None)}")
            print(f"Error Desc Code : {getattr(response.Error, 'DescCode', None)}")

    except Exception as e:
        print("\r\n* Error *\r\n")
        print(f"Exception occurred: {str(e)}")