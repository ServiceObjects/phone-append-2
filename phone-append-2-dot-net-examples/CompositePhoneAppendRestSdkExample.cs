using phone_append_2_dot_net.REST;

namespace phone_append_2_dot_net_examples
{
    public class CompositePhoneAppendRestSdkExample
    {
        public static void Go(string licenseKey, bool isLive)
        {
            Console.WriteLine("\r\n----------------------------------------------");
            Console.WriteLine("PhoneAppend2 - CompositePhoneAppend - REST SDK");
            Console.WriteLine("----------------------------------------------");

            CompositePhoneAppendClient.CompositePhoneAppendInput compositePhoneAppendInput = new(
                Name: "Brooks Institute",
                Address: "27 E Cota ST",
                City: "Santa Barbara",
                State: "CA",
                PostalCode: "93101",
                IsBusiness: "True",
                LicenseKey: licenseKey,
                IsLive: isLive,
                TimeoutSeconds: 15
            );

            Console.WriteLine("\r\n* Input *\r\n");
            Console.WriteLine($"Name       : {compositePhoneAppendInput.Name}");
            Console.WriteLine($"Address    : {compositePhoneAppendInput.Address}");
            Console.WriteLine($"City       : {compositePhoneAppendInput.City}");
            Console.WriteLine($"State      : {compositePhoneAppendInput.State}");
            Console.WriteLine($"Postal Code: {compositePhoneAppendInput.PostalCode}");
            Console.WriteLine($"Is Business: {compositePhoneAppendInput.IsBusiness}");
            Console.WriteLine($"License Key: {compositePhoneAppendInput.LicenseKey}");
            Console.WriteLine($"Is Live    : {compositePhoneAppendInput.IsLive}");

            PA2Response response = CompositePhoneAppendClient.Invoke(compositePhoneAppendInput);
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
        }
    }
}