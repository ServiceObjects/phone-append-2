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
// 1 Instantiate the service wrapper
 var pv2 = new PhoneAppendValidation(isLive);

// 2 Provide your input data
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

// 3 Call the service
string FullName = "Tim Cook";
string FirstName = "";
string LastName = "";
string Address = "1 Infinite Loop";
string City = "Cupertino";
string State = "CA";
string PostalCode = "95014-2083";
string LicenseKey = "YOUR LICENSE KEY";

PhoneInfoResponse response = pv2.PhoneAppendAsync(FullName, FirstName, LastName, Address, City, State, PostalCode, LicenseKey).Result;

// 4. Inspect results.
if (response.Error is null)
{
    Console.WriteLine("\r\n* Phone Info *\r\n");
    if (response.PhoneInfo != null)
    {
        Console.WriteLine($"Phone         : {response.PhoneInfo.Phone}");
        Console.WriteLine($"Name          : {response.PhoneInfo.Name}");
        Console.WriteLine($"Address       : {response.PhoneInfo.Address}");
        Console.WriteLine($"City          : {response.PhoneInfo.City}");
        Console.WriteLine($"State         : {response.PhoneInfo.State}");
        Console.WriteLine($"Postal Code   : {response.PhoneInfo.PostalCode}");
        Console.WriteLine($"Is Residential: {response.PhoneInfo.IsResidential}");
        Console.WriteLine($"Certainty     : {response.PhoneInfo.Certainty}");
        Console.WriteLine($"Line Type     : {response.PhoneInfo.LineType}");
    }
    else
    {
        Console.WriteLine("No phone info found.");
    }
}
else
{
    Console.WriteLine("\r\n* Error *\r\n");
    Console.WriteLine($"Error Type    : {response.Error.Type}");
    Console.WriteLine($"Error TypeCode: {response.Error.TypeCode}");
    Console.WriteLine($"Error Desc    : {response.Error.Desc}");
    Console.WriteLine($"Error DescCode: {response.Error.DescCode}");
}
```
# PA2 - BusinessPhoneAppend

Uses the provided FullName, FirstName, LastName, Address, City, State, Postal Code, License Key to return a landline phone number.

### [BusinessPhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-businessphoneappend/)

## Library Usage

```
// 1 Instantiate the service wrapper
 var pa2 = new BusinessPhoneAppendValidation(isLive);

// 2 Provide your input data
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

// 3 Call the service
string BusinessName = "Brooks Institute";
string Address = "27 E Cota ST";
string City = "Santa Barbara";
string State = "CA";
string PostalCode = "93101";

PhoneInfoResponse response = pa2.BusinessPhoneAppendAsync(BusinessName, Address, City, State, PostalCode, licenseKey).Result;

// 4. Inspect results.
if (response.Error is null)
{
    Console.WriteLine("\r\n* Phone Info *\r\n");
    if (response.PhoneInfo != null)
    {
        Console.WriteLine($"Phone         : {response.PhoneInfo.Phone}");
        Console.WriteLine($"Name          : {response.PhoneInfo.Name}");
        Console.WriteLine($"Address       : {response.PhoneInfo.Address}");
        Console.WriteLine($"City          : {response.PhoneInfo.City}");
        Console.WriteLine($"State         : {response.PhoneInfo.State}");
        Console.WriteLine($"Postal Code   : {response.PhoneInfo.PostalCode}");
        Console.WriteLine($"Is Residential: {response.PhoneInfo.IsResidential}");
        Console.WriteLine($"Certainty     : {response.PhoneInfo.Certainty}");
        Console.WriteLine($"Line Type     : {response.PhoneInfo.LineType}");
        Console.WriteLine($"Debug         : {response.PhoneInfo.Debug}");
    }
    else
    {
        Console.WriteLine("No phone info found.");
    }
}
else
{
    Console.WriteLine("\r\n* Error *\r\n");
    Console.WriteLine($"Error Type    : {response.Error.Type}");
    Console.WriteLine($"Error TypeCode: {response.Error.TypeCode}");
    Console.WriteLine($"Error Desc    : {response.Error.Desc}");
    Console.WriteLine($"Error DescCode: {response.Error.DescCode}");
}
```
# PA2 - CompositePhoneAppend

Uses the provided FullName, FirstName, LastName, Address, City, State, Postal Code, License Key to return a landline phone number.

### [CompositePhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-compositephoneappend/)

## Library Usage

```
// 1 Instantiate the service wrapper
 var pv2 = new CompositePhoneAppendValidation(isLive);

// 2 Provide your input data
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

string Name = "Brooks Institute";
string Address = "27 E Cota ST";
string City = "Santa Barbara";
string State = "CA";
string PostalCode = "93101";
string IsBusiness = "True";

// 2. Call the sync Invoke() method.
PA2Response response = CompositePhoneAppendClient.Invoke(compositePhoneAppendInput);

// 3. Inspect results.
if (response.Error is null)
{
    Console.WriteLine("\r\n* Phone Info *\r\n");
    if (response.PhoneInfo != null)
    {
        Console.WriteLine($"Phone         : {response.PhoneInfo.Phone}");
        Console.WriteLine($"Name          : {response.PhoneInfo.Name}");
        Console.WriteLine($"Address       : {response.PhoneInfo.Address}");
        Console.WriteLine($"City          : {response.PhoneInfo.City}");
        Console.WriteLine($"State         : {response.PhoneInfo.State}");
        Console.WriteLine($"Postal Code   : {response.PhoneInfo.PostalCode}");
        Console.WriteLine($"Is Residential: {response.PhoneInfo.IsResidential}");
        Console.WriteLine($"Certainty     : {response.PhoneInfo.Certainty}");
        Console.WriteLine($"Line Type     : {response.PhoneInfo.LineType}");
    }
    else
    {
        Console.WriteLine("No phone info found.");
    }
}
else
{
    Console.WriteLine("\r\n* Error *\r\n");
    Console.WriteLine($"Error Type    : {response.Error.Type}");
    Console.WriteLine($"Error TypeCode: {response.Error.TypeCode}");
    Console.WriteLine($"Error Desc    : {response.Error.Desc}");
    Console.WriteLine($"Error DescCode: {response.Error.DescCode}");
}
```