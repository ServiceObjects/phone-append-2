import { BusinessPhoneAppendClient } from '../phone-append-2-nodejs/REST/business_phone_append_rest.js';

async function businessPhoneAppendRestExample(isLive, licenseKey) {
    console.log("\r\n-------------------------------------------------");
    console.log("PhoneAppend2 - BusinessPhoneAppend - REST Example");
    console.log("-------------------------------------------------");

    const businessName = "Brooks Institute";
    const address = "27 E Cota ST";
    const city = "Santa Barbara";
    const state = "CA";
    const postalCode = "93101";

    console.log("\r\n* Input *\r\n");
    console.log(`Business Name: ${businessName}`);
    console.log(`Address      : ${address}`);
    console.log(`City         : ${city}`);
    console.log(`State        : ${state}`);
    console.log(`Postal Code  : ${postalCode}`);
    console.log(`License Key  : ${licenseKey}`);
    console.log(`Is Live      : ${isLive}`);

    try {
        const response = await BusinessPhoneAppendClient.invokeAsync(
            businessName,
            address,
            city,
            state,
            postalCode,
            licenseKey,
            isLive
        );

        console.log("\r\n* Phone Info *\r\n");
        if (response && !response.Error) {
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
            console.log("\r\n* Error *\r\n");
            console.log(`Error Type     : ${response.Error.Type}`);
            console.log(`Error Type Code: ${response.Error.TypeCode}`);
            console.log(`Error Desc     : ${response.Error.Desc}`);
            console.log(`Error Desc Code: ${response.Error.DescCode}`);
        }
    } catch (e) {
        console.log("\r\n* Error *\r\n");
        console.log(`Error Message: ${e.message}`);
    }
}

export { businessPhoneAppendRestExample };