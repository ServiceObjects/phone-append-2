import { CompositePhoneAppendSoap } from '../phone-append-2-nodejs/SOAP/composite_phone_append_soap.js';

async function compositePhoneAppendSoapExample(isLive, licenseKey) {
    console.log("\n--------------------------------------------------");
    console.log("PhoneAppend2 - CompositePhoneAppend - SOAP Example");
    console.log("--------------------------------------------------");

    const name = "Brooks Institute";
    const address = "27 E Cota ST";
    const city = "Santa Barbara";
    const state = "CA";
    const postalCode = "93101";
    const isBusiness = "True";
    const timeoutSeconds = 15;

    console.log("\n* Input *\n");
    console.log(`Name           : ${name}`);
    console.log(`Address        : ${address}`);
    console.log(`City           : ${city}`);
    console.log(`State          : ${state}`);
    console.log(`Postal Code    : ${postalCode}`);
    console.log(`Is Business    : ${isBusiness}`);
    console.log(`License Key    : ${licenseKey}`);
    console.log(`Is Live        : ${isLive}`);
    console.log(`Timeout Seconds: ${timeoutSeconds}`);

    try {
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

        console.log("\n* Phone Info *\n");
        if (response) {
            if (response.PhoneInfo) {
                console.log(`Phone         : ${response.PhoneInfo.Phone}`);
                console.log(`Name          : ${response.PhoneInfo.Name}`);
                console.log(`Address       : ${response.PhoneInfo.Address}`);
                console.log(`City          : ${response.PhoneInfo.City}`);
                console.log(`State         : ${response.PhoneInfo.State}`);
                console.log(`Postal Code   : ${response.PhoneInfo.PostalCode}`);
                console.log(`Is Residential: ${response.PhoneInfo.IsResidential}`);
                console.log(`Certainty     : ${response.PhoneInfo.Certainty}`);
                console.log(`Line Type     : ${response.PhoneInfo.LineType}`);
            } else {
                console.log("No phone info found.");
            }
        } else {
            console.log("No phone info found.");
        }

        if (response.Error) {
            console.log("\n* Error *\n");
            console.log(`Error Type     : ${response.Error.Type}`);
            console.log(`Error Type Code: ${response.Error.TypeCode}`);
            console.log(`Error Desc     : ${response.Error.Desc}`);
            console.log(`Error Desc Code: ${response.Error.DescCode}`);
        }
    } catch (e) {
        console.log("\n* Error *\n");
        console.log(`Error Message: ${e.message}`);
    }
}

export { compositePhoneAppendSoapExample };