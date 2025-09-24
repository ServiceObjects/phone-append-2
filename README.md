![Service Objects Logo](https://www.serviceobjects.com/wp-content/uploads/2021/05/SO-Logo-with-TM.gif "Service Objects Logo")

# PA2 - Phone Append 2

DOTS Phone Append 2 is an XML web service that provides information about landline telephone numbers. By providing contact name or business name and address information, DOTS Phone Append 2 provides the landline telephone number registered to the supplied information.

With Phone Append 2, users append telephone numbers to existing contact information. This information can be used to improve online applications or as supplemental information for existing databases.

## [Service Objects Website](https://serviceobjects.com)
## [Developer Guide/Documentation](https://www.serviceobjects.com/docs/)

# PA2 - PhoneAppend

PhoneAppend: Uses the provided FullName, FirstName, LastName, Address, City, State, Postal Code, License Key to return a landline phone number.

## [PhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-phoneappend-recommended/)

## PhoneAppend Request URLs (Query String Parameters)

>[!CAUTION]
>### *Important - Use query string parameters for all inputs.  Do not use path parameters since it will lead to errors due to optional parameters and special character issues.*


### JSON
#### Trial

https://trial.serviceobjects.com/pa2/api.svc/PhoneAppendJson?FullName=Tim+Cook&FirstName=&LastName=&Address=1+Infinite+Loop&City=Cupertino&State=CA&PostalCode=95014-2083&LicenseKey={LicenseKey}

#### Production

https://sws.serviceobjects.com/pa2/api.svc/PhoneAppendJson?FullName=Tim+Cook&FirstName=&LastName=&Address=1+Infinite+Loop&City=Cupertino&State=CA&PostalCode=95014-2083&LicenseKey={LicenseKey}

#### Production Backup

https://swsbackup.serviceobjects.com/pa2/api.svc/PhoneAppendJson?FullName=Tim+Cook&FirstName=&LastName=&Address=1+Infinite+Loop&City=Cupertino&State=CA&PostalCode=95014-2083&LicenseKey={LicenseKey}

### XML
#### Trial

https://trial.serviceobjects.com/PA2/api.svc/PhoneAppend?FullName=Tim+Cook&FirstName=&LastName=&Address=1+Infinite+Loop&City=Cupertino&State=CA&PostalCode=95014-2083&LicenseKey={LicenseKey}

#### Production

https://sws.serviceobjects.com/PA2/api.svc/PhoneAppend?FullName=Tim+Cook&FirstName=&LastName=&Address=1+Infinite+Loop&City=Cupertino&State=CA&PostalCode=95014-2083&LicenseKey={LicenseKey}

#### Production Backup

https://swsbackup.serviceobjects.com/PA2/api.svc/PhoneAppend?FullName=Tim+Cook&FirstName=&LastName=&Address=1+Infinite+Loop&City=Cupertino&State=CA&PostalCode=95014-2083&LicenseKey={LicenseKey}

# PA2 - CompositePhoneAppend

This operation is a composite of PhoneAppend and BusinessPhoneAppend. CompositePhoneAppend provides the convenience for developers to code to one operation and is able to append phone numbers for business and residential contacts A parameter “IsBusiness” allows the client to specify whether the contact is a business or not. If left blank, the service can make the determination on its own, however, this increases the response time from the request

## [CompositePhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-compositephoneappend/)

## CompositePhoneAppend Request URLs (Query String Parameters)

>[!CAUTION]
>#### *Important - Use query string parameters for all inputs.  Do not use path parameters since it will lead to errors due to optional parameters and special character issues.*

### JSON
#### Trial

https://trial.serviceobjects.com/PA2/api.svc/CompositePhoneAppendJson?Name=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&IsBusiness=yes&LicenseKey={LicenseKey}

#### Production

https://sws.serviceobjects.com/PA2/api.svc/CompositePhoneAppendJson?Name=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&IsBusiness=yes&LicenseKey={LicenseKey}

#### Production Backup

https://swsbackup.serviceobjects.com/PA2/api.svc/CompositePhoneAppendJson?Name=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&IsBusiness=yes&LicenseKey={LicenseKey}

### XML
#### Trial

https://trial.serviceobjects.com/PA2/api.svc/CompositePhoneAppend?Name=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&IsBusiness=yes&LicenseKey={LicenseKey}

#### Production

https://sws.serviceobjects.com/PA2/api.svc/CompositePhoneAppend?Name=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&IsBusiness=yes&LicenseKey={LicenseKey}

#### Production Backup

https://swsbackup.serviceobjects.com/PA2/api.svc/CompositePhoneAppend?Name=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&IsBusiness=yes&LicenseKey={LicenseKey}

# PA2 - BusinessPhoneAppend

BusinessPhoneAppend returns a phone number based on provided inputs. The minimum required inputs are BusinessName City State.

## [BusinessPhoneAppend Developer Guide/Documentation](https://www.serviceobjects.com/docs/dots-phone-append-2/pa2-operations/pa2-businessphoneappend/)

## BusinessPhoneAppend Request URLs (Query String Parameters)

>[!CAUTION]
>#### *Important - Use query string parameters for all inputs.  Do not use path parameters since it will lead to errors due to optional parameters and special character issues.*

### JSON
#### Trial

https://trial.serviceobjects.com/PA2/api.svc/BusinessPhoneAppendJson?BusinessName=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&LicenseKey={LicenseKey}

#### Production

https://sws.serviceobjects.com/PA2/api.svc/BusinessPhoneAppendJson?BusinessName=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&LicenseKey={LicenseKey}

#### Production Backup

https://swsbackup.serviceobjects.com/PA2/api.svc/BusinessPhoneAppendJson?BusinessName=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&LicenseKey={LicenseKey}

### XML
#### Trial

https://trial.serviceobjects.com/PA2/api.svc/BusinessPhoneAppend?BusinessName=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&LicenseKey={LicenseKey}

#### Production

https://sws.serviceobjects.com/PA2/api.svc/BusinessPhoneAppend?BusinessName=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&LicenseKey={LicenseKey}

#### Production Backup

https://swsbackup.serviceobjects.com/PA2/api.svc/BusinessPhoneAppend?BusinessName=Brooks+Institute&Address=27+E+Cota+St+Ste+500&City=Santa+Barbara&State=CA&PostalCode=93101&LicenseKey={LicenseKey}
