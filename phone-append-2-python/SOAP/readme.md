![Service Objects Logo](https://www.serviceobjects.com/wp-content/uploads/2021/05/SO-Logo-with-TM.gif "Service Objects Logo")

# PA2 - Phone Append 2

DOTS Phone Append 2 is an XML web service that provides information about landline telephone numbers. By providing contact name or business name and address information, DOTS Phone Append 2 provides the landline telephone number registered to the supplied information.

With Phone Append 2, users append telephone numbers to existing contact information. This information can be used to improve online applications or as supplemental information for existing databases.

## [Service Objects Website](https://serviceobjects.com)

# PA2 - PhoneAppend

Uses the provided FullName, FirstName, LastName, Address, City, State, Postal Code, License Key to return a landline phone number.

### [PhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-phoneappend-recommended/)

## Library Usage

```
# 1. Build the input
#
#  Required fields:
#               license_key
#               is_live
# 
# Optional:
#        full_name
#        first_name
#        last_name
#        address
#        city
#        state	
#        postal_code
#        timeout_seconds (default: 15)

from phone_append_soap import PhoneAppendSoap

full_name = "Tim Cook"
first_name = ""
last_name = ""
address = "1 Infinite Loop"
city = "Cupertino"
state = "CA"
postal_code = "95014-2083"
timeout_seconds = 15
is_live = True
license_key = "YOUR LICENSE KEY"

# 2. Call the method.
service = PhoneAppendSoap(license_key, is_live, timeout_seconds * 1000)
response = service.get_phone_append(full_name, first_name, last_name, address, city, state, postal_code)

# 3. Inspect results.
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
```
# PA2 - BusinessPhoneAppend

Uses the provided BusinessName, Address, City, State, Postal Code, License Key to return a landline phone number.

### [BusinessPhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-businessphoneappend/)

## Library Usage

```
# 1. Build the input
#
#  Required fields:
#               license_key
#               is_live
# 
# Optional:
#        business_name
#        address
#        city
#        state
#        postal_code

from business_phone_append_soap import BusinessPhoneAppendSoap

business_name = "Brooks Institute"
address = "27 E Cota ST"
city = "Santa Barbara"
state = "CA"
postal_code = "93101"
is_live = True
license_key = "YOUR LICENSE KEY"

# 2. Call the method.
service = BusinessPhoneAppendSoap(license_key, is_live, timeout_seconds * 1000)
response = service.get_business_phone_append(business_name, address, city, state, postal_code)

# 3. Inspect results.
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
```
# PA2 - CompositePhoneAppend

Uses the provided Name, Address, City, State, Postal Code, IsBusiness, LicenseKey to return a landline phone number.

### [CompositePhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-compositephoneappend/)

## Library Usage

```
# 1. Build the input
#
#  Required fields:
#               license_key
#               is_live
# 
# Optional:
#        name
#        address
#        city
#        state
#        postal_code Code
#        is_business
#        timeout_seconds (default: 15)

from composite_phone_append_soap import CompositePhoneAppendSoap

name = "Brooks Institute"
address = "27 E Cota ST"
city = "Santa Barbara"
state = "CA"
postal_code = "93101"
is_business = "False"
is_live = True
license_key = "YOUR LICENSE KEY"

# 2. Call the method.
service = CompositePhoneAppendSoap(license_key, is_live, timeout_seconds * 1000)
response = service.get_composite_phone_append(name, address, city, state, postal_code)

# 3. Inspect results.
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
```