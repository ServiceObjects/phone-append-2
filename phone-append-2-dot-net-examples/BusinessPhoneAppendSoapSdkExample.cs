using PA2Reference;
using phone_append_2_dot_net.SOAP;

namespace phone_append_2_dot_net_examples
{
    public static class BusinessPhoneAppendSoapSdkExample
    {
        public static void Go(string licenseKey, bool isLive)
        {
            Console.WriteLine("\r\n---------------------------------------------");
            Console.WriteLine("PhoneAppend2 - BusinessPhoneAppend - SOAP SDK");
            Console.WriteLine("---------------------------------------------");

            string BusinessName = "Brooks Institute";
            string Address = "27 E Cota ST";
            string City = "Santa Barbara";
            string State = "CA";
            string PostalCode = "93101";

            Console.WriteLine("\r\n* Input *\r\n");
            Console.WriteLine($"Business Name: {BusinessName}");
            Console.WriteLine($"Address      : {Address}");
            Console.WriteLine($"City         : {City}");
            Console.WriteLine($"State        : {State}");
            Console.WriteLine($"Postal Code  : {PostalCode}");
            Console.WriteLine($"License Key  : {licenseKey}");
            Console.WriteLine($"Is Live      : {isLive}");

            var pa2 = new BusinessPhoneAppendValidation(isLive);
            PhoneInfoResponse response = pa2.BusinessPhoneAppendAsync(BusinessName, Address, City, State, PostalCode, licenseKey).Result;

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
        }
    }
}