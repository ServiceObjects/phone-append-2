from business_phone_append_rest_example import business_phone_append_rest_sdk_go
from business_phone_append_soap_example import business_phone_append_soap_sdk_go
from composite_phone_append_rest_example import composite_phone_append_rest_sdk_go
from composite_phone_append_soap_example import composite_phone_append_soap_sdk_go
from phone_append_rest_example import phone_append_rest_sdk_go
from phone_append_soap_example import phone_append_soap_sdk_go

if __name__ == "__main__":

  # Your license key from Service Objects.  
  # Trial license keys will only work on the trial environments and production  
  # license keys will only work on production environments.
  #   
  license_key = "LICENSE KEY"  
  is_live = True

  # PhoneAppend2 - PhoneAppend - REST SDK
  phone_append_rest_sdk_go(is_live, license_key)

  # PhoneAppend2 - PhoneAppend - SOAP SDK
  phone_append_soap_sdk_go(is_live, license_key)

  # PhoneAppend2 - BusinessPhoneAppend - REST SDK
  business_phone_append_rest_sdk_go(is_live, license_key)

  # PhoneAppend2 - BusinessPhoneAppend - SOAP SDK
  business_phone_append_soap_sdk_go(is_live, license_key)

  # PhoneAppend2 - CompositePhoneAppend - REST SDK
  composite_phone_append_rest_sdk_go(is_live, license_key)

  # PhoneAppend2 - CompositePhoneAppend - SOAP SDK
  composite_phone_append_soap_sdk_go(is_live, license_key)

  