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
// 1. Build the input
//
//  Required fields:
//               LicenseKey
//               IsLive
// 
// Optional:
//        FullName
//        FirstName
//        LastName
//        Address
//        City
//        State	
//        PostalCode
//        TimeoutSeconds (default: 15)

import { PhoneAppendSoap } from '../phone-append-2-nodejs/SOAP/phone_append_soap.js';

const fullName = "Tim Cook";
const firstName = "";
const lastName = "";
const address = "1 Infinite Loop";
const city = "Cupertino";
const state = "CA";
const postalCode = "95014-2083";
const timeoutSeconds = 15;

// 2. Call the sync Invoke() method.
const pa2 = new PhoneAppendSoap(
    fullName,
    firstName,
    lastName,
    address,
    city,
    state,
    postalCode,
    licenseKey,
    isLive,
    timeoutSeconds
);
const response = await pa2.invokeAsync();

// 3. Inspect results.
console.log("\r\n* Phone Info *\r\n");
if (response && !response.Error) 
{
    if (response.PhoneInfo) 
    {
        console.log(`Phone         : ${response.PhoneInfo.Phone}`);
        console.log(`Name          : ${response.PhoneInfo.Name}`);
        console.log(`Address       : ${response.PhoneInfo.Address}`);
        console.log(`City          : ${response.PhoneInfo.City}`);
        console.log(`State         : ${response.PhoneInfo.State}`);
        console.log(`Postal Code   : ${response.PhoneInfo.PostalCode}`);
        console.log(`Is Residential: ${response.PhoneInfo.IsResidential}`);
        console.log(`Certainty     : ${response.PhoneInfo.Certainty}`);
        console.log(`Line Type     : ${response.PhoneInfo.LineType}`);
    }
    else
    {
        console.log("No phone info found.");
    }
}
else 
{
    console.log("No phone info found.");
}

if (response.Error) 
{
    console.log("\r\n* Error *\r\n");
    console.log(`Error Type     : ${response.Error.Type}`);
    console.log(`Error Type Code: ${response.Error.TypeCode}`);
    console.log(`Error Desc     : ${response.Error.Desc}`);
    console.log(`Error Desc Code: ${response.Error.DescCode}`);
}
```
# PA2 - BusinessPhoneAppend

Uses the provided FullName, FirstName, LastName, Address, City, State, Postal Code, License Key to return a landline phone number.

### [BusinessPhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-businessphoneappend/)

## Library Usage

```
// 1. Build the input
//
//  Required fields:
//               BusinessName
//               City
//               State
//               LicenseKey
//               IsLive
// 
// Optional:
//        Address
//        Postal Code
//        TimeoutSeconds (default: 15)

import { BusinessPhoneAppendSoap } from '../phone-append-2-nodejs/SOAP/business_phone_append_soap.js';

const businessName = "Brooks Institute";
const address = "27 E Cota ST";
const city = "Santa Barbara";
const state = "CA";
const postalCode = "93101";


// 2. Call the sync Invoke() method.
const pa2 = new BusinessPhoneAppendSoap(
    businessName,
    address,
    city,
    state,
    postalCode,
    licenseKey,
    isLive,
    timeoutSeconds
);
const response = await pa2.invokeAsync();

// 3. Inspect results.
if (response && !response.Error)
{
    if (response.PhoneInfo) 
    {
        console.log(`Phone         : ${response.PhoneInfo.Phone}`);
        console.log(`Name          : ${response.PhoneInfo.Name}`);
        console.log(`Address       : ${response.PhoneInfo.Address}`);
        console.log(`City          : ${response.PhoneInfo.City}`);
        console.log(`State         : ${response.PhoneInfo.State}`);
        console.log(`Postal Code   : ${response.PhoneInfo.PostalCode}`);
        console.log(`Is Residential: ${response.PhoneInfo.IsResidential}`);
        console.log(`Certainty     : ${response.PhoneInfo.Certainty}`);
        console.log(`Line Type     : ${response.PhoneInfo.LineType}`);
    }
    else
    {
        console.log("No phone info found.");
    }
} 
else
{
    console.log("No phone info found.");
}

if (response.Error)
{
    console.log("\r\n* Error *\r\n");
    console.log(`Error Type     : ${response.Error.Type}`);
    console.log(`Error Type Code: ${response.Error.TypeCode}`);
    console.log(`Error Desc     : ${response.Error.Desc}`);
    console.log(`Error Desc Code: ${response.Error.DescCode}`);
}
```
# PA2 - CompositePhoneAppend

Uses the provided FullName, FirstName, LastName, Address, City, State, Postal Code, License Key to return a landline phone number.

### [CompositePhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-compositephoneappend/)

## Library Usage

```
// 1. Build the input
//
//  Required fields:
//               LicenseKey
//               IsLive
// 
// Optional:
//        Name
//        Address
//        City
//        State
//        Postal Code
//        IsBusiness
//        TimeoutSeconds (default: 15)

import { CompositePhoneAppendSoap } from '../phone-append-2-nodejs/SOAP/composite_phone_append_soap.js';

const name = "Brooks Institute";
const address = "27 E Cota ST";
const city = "Santa Barbara";
const state = "CA";
const postalCode = "93101";
const isBusiness = "True";

// 2. Call the sync Invoke() method.
const pa2 = new CompositePhoneAppendSoap(
    name,
    address,
    city,
    state,
    postalCode,
    isBusiness,
    licenseKey,
    isLive,
    timeoutSeconds
);
const response = await pa2.invokeAsync();

// 3. Inspect results.
if (response && !response.Error) 
{
    if (response.PhoneInfo)
    {
        console.log(`Phone         : ${response.PhoneInfo.Phone}`);
        console.log(`Name          : ${response.PhoneInfo.Name}`);
        console.log(`Address       : ${response.PhoneInfo.Address}`);
        console.log(`City          : ${response.PhoneInfo.City}`);
        console.log(`State         : ${response.PhoneInfo.State}`);
        console.log(`Postal Code   : ${response.PhoneInfo.PostalCode}`);
        console.log(`Is Residential: ${response.PhoneInfo.IsResidential}`);
        console.log(`Certainty     : ${response.PhoneInfo.Certainty}`);
        console.log(`Line Type     : ${response.PhoneInfo.LineType}`);
    } 
    else 
    {
        console.log("No phone info found.");
    }
}
else 
{
    console.log("No phone info found.");
}

if (response.Error) 
{
    console.log("\r\n* Error *\r\n");
    console.log(`Error Type     : ${response.Error.Type}`);
    console.log(`Error Type Code: ${response.Error.TypeCode}`);
    console.log(`Error Desc     : ${response.Error.Desc}`);
    console.log(`Error Desc Code: ${response.Error.DescCode}`);
}
```