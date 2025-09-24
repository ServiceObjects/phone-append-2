using phone_append_2_dot_net_examples;

//Your license key from Service Objects.
//Trial license keys will only work on the
//trail environments and production license
//keys will only work on production environments.
string LicenseKey = "LICENSE KEY";

bool IsProductionKey = true;

// PhoneAppend2 - PhoneAppend - REST SDK
PhoneAppendRestSdkExample.Go(LicenseKey, IsProductionKey);

// PhoneAppend2 - PhoneAppend - SOAP SDK
PhoneAppendSoapSdkExample.Go(LicenseKey, IsProductionKey);

// PhoneAppend2 - BusinessPhoneAppend - REST SDK
BusinessPhoneAppendRestSdkExample.Go(LicenseKey, IsProductionKey);

// PhoneAppend2 - BusinessPhoneAppend - SOAP SDK
BusinessPhoneAppendSoapSdkExample.Go(LicenseKey, IsProductionKey);

// PhoneAppend2 - CompositePhoneAppend - REST SDK
CompositePhoneAppendRestSdkExample.Go(LicenseKey, IsProductionKey);

// PhoneAppend2 - CompositePhoneAppend - SOAP SDK
CompositePhoneAppendSoapSdkExample.Go(LicenseKey, IsProductionKey);