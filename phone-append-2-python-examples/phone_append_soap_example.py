import sys
import os

sys.path.insert(0, os.path.abspath("../phone-append-2-python/SOAP"))

from phone_append_soap import PhoneAppendSoap

def phone_append_soap_sdk_go(is_live: bool, license_key: str) -> None:
    print("\r\n---------------------------------------")
    print("PhoneAppend2 - PhoneAppend - SOAP SDK")
    print("---------------------------------------")


    full_name = "Tim Cook"
    first_name = ""
    last_name = ""
    address = "1 Infinite Loop"
    city = "Cupertino"
    state = "CA"
    postal_code = "95014-2083"
    timeout_seconds = 15

    print("\r\n* Input *\r\n")
    print(f"Full Name      : {full_name}")
    print(f"First Name     : {first_name}")
    print(f"Last Name      : {last_name}")
    print(f"Address        : {address}")
    print(f"City           : {city}")
    print(f"State          : {state}")
    print(f"Postal Code    : {postal_code}")
    print(f"License Key    : {license_key}")
    print(f"Is Live        : {is_live}")
    print(f"Timeout Seconds: {timeout_seconds}")

    try:
        service = PhoneAppendSoap(license_key, is_live, timeout_seconds * 1000)
        response = service.get_phone_append(full_name, first_name, last_name, address, city, state, postal_code)

        if not hasattr(response, 'Error') or not response.Error:
            print("\r\n* Phone Info *\r\n")
            if hasattr(response, 'PhoneInfo') and response.PhoneInfo:
                print(f"Phone         : {getattr(response.PhoneInfo, 'Phone', None)}")
                print(f"Name          : {getattr(response.PhoneInfo, 'Name', None)}")
                print(f"Address       : {getattr(response.PhoneInfo, 'Address', None)}")
                print(f"City          : {getattr(response.PhoneInfo, 'City', None)}")
                print(f"State         : {getattr(response.PhoneInfo, 'State', None)}")
                print(f"Postal Code   : {getattr(response.PhoneInfo, 'PostalCode', None)}")
                print(f"Is Residential: {getattr(response.PhoneInfo, 'IsResidential', None)}")
                print(f"Certainty     : {getattr(response.PhoneInfo, 'Certainty', None)}")
                print(f"Line Type     : {getattr(response.PhoneInfo, 'LineType', None)}")
            else:
                print("No phone info found.")
        else:
            print("No phone info found.")

        if hasattr(response, 'Error') and response.Error:
            print("\r\n* Error *\r\n")
            print(f"Error Type     : {getattr(response.Error, 'Type', None)}")
            print(f"Error Type Code: {getattr(response.Error, 'TypeCode', None)}")
            print(f"Error Desc     : {getattr(response.Error, 'Desc', None)}")
            print(f"Error Desc Code: {getattr(response.Error, 'DescCode', None)}")

    except Exception as e:
        print("\r\n* Error *\r\n")
        print(f"Exception occurred: {str(e)}")