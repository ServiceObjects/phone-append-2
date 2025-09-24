import sys
import os

sys.path.insert(0, os.path.abspath("../phone-append-2-python/REST"))

from composite_phone_append_rest import get_composite_phone_append

def composite_phone_append_rest_sdk_go(is_live: bool, license_key: str) -> None:
    print("\r\n----------------------------------------------")
    print("PhoneAppend2 - CompositePhoneAppend - REST SDK")
    print("----------------------------------------------")

    name = "Brooks Institute"
    address = "27 E Cota ST"
    city = "Santa Barbara"
    state = "CA"
    postal_code = "93101"
    is_business = "False"

    print("\r\n* Input *\r\n")
    print(f"Name       : {name}")
    print(f"Address    : {address}")
    print(f"City       : {city}")
    print(f"State      : {state}")
    print(f"Postal Code: {postal_code}")
    print(f"Is Business: {is_business}")
    print(f"License Key: {license_key}")
    print(f"Is Live    : {is_live}")

    try:
        response = get_composite_phone_append(name, address, city, state, postal_code, is_business, license_key, is_live)

        print("\r\n* Phone Info *\r\n")
        if response and not response.Error:
            if response.PhoneInfo:
                print(f"Phone         : {response.PhoneInfo.Phone}")
                print(f"Name          : {response.PhoneInfo.Name}")
                print(f"Address       : {response.PhoneInfo.Address}")
                print(f"City          : {response.PhoneInfo.City}")
                print(f"State         : {response.PhoneInfo.State}")
                print(f"Postal Code   : {response.PhoneInfo.PostalCode}")
                print(f"Is Residential: {response.PhoneInfo.IsResidential}")
                print(f"Certainty     : {response.PhoneInfo.Certainty}")
                print(f"Line Type     : {response.PhoneInfo.LineType}")
                print(f"Debug         : {response.PhoneInfo.Debug}")
            else:
                print("No phone info found.")
        else:
            print("No phone info found.")

        if response.Error:
            print("\r\n* Error *\r\n")
            print(f"Error Type     : {response.Error.Type}")
            print(f"Error Type Code: {response.Error.TypeCode}")
            print(f"Error Desc     : {response.Error.Desc}")
            print(f"Error Desc Code: {response.Error.DescCode}")

    except Exception as e:
        print("\r\n* Error *\r\n")
        print(f"Error Message: {str(e)}")