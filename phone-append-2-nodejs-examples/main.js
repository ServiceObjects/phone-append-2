import {businessPhoneAppendRestExample} from './business_phone_append_rest_example.js';
import{businessPhoneAppendSoapExample} from './business_phone_append_soap_example.js'
import {compositePhoneAppendRestExample} from'./composite_phone_append_rest_example.js'
import {compositePhoneAppendSoapExample} from'./composite_phone_append_soap_example.js'
import {phoneAppendRestExample} from './phone_append_rest_example.js';
import {phoneAppendSoapExample} from './phone_append_soap_example.js';

export async function main()
{
    //Your license key from Service Objects.
    //Trial license keys will only work on the
    //trail environments and production license
    //keys will only work on production environments.
    const licenseKey = "LICENSE KEY";
    const isLive = true;

    // PhoneAppend2 - PhoneAppend - REST SDK
    await phoneAppendRestExample(isLive, licenseKey);

    // PhoneAppend2 - PhoneAppend - SOAP SDK
    await phoneAppendSoapExample(isLive, licenseKey);

    // PhoneAppend2 - BusinessPhoneAppend - REST SDK
    await businessPhoneAppendRestExample(isLive, licenseKey);

    // PhoneAppend2 - BusinessPhoneAppend - SOAP SDK
    await businessPhoneAppendSoapExample(isLive, licenseKey);

    // PhoneAppend2 - CompositePhoneAppend - REST SDK
    await compositePhoneAppendRestExample(isLive, licenseKey);

    // PhoneAppend2 - CompositePhoneAppend - SOAP SDK
    await compositePhoneAppendSoapExample(isLive, licenseKey);
}
main().catch((error) => {
  console.error("An error occurred:", error);
  process.exit(1);
});