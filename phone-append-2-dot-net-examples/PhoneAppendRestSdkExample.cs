using phone_append_2_dot_net.REST;

namespace phone_append_2_dot_net_examples
{
    public class PhoneAppendRestSdkExample
    {
        public static void Go(string licenseKey, bool isLive)
        {
            Console.WriteLine("\r\n-------------------------------------");
            Console.WriteLine("PhoneAppend2 - PhoneAppend - REST SDK");
            Console.WriteLine("-------------------------------------");

            PhoneAppendClient.PhoneAppendInput phoneAppendInput = new(
                FullName: "Tim Cook",
                FirstName: "",
                LastName: "",
                Address: "1 Infinite Loop",
                City: "Cupertino",
                State: "CA",
                PostalCode: "95014-2083",
                LicenseKey: licenseKey,
                IsLive: isLive,
                TimeoutSeconds: 15
            );

            Console.WriteLine("\r\n* Input *\r\n");
            Console.WriteLine($"Full Name  : {phoneAppendInput.FullName}");
            Console.WriteLine($"First Name : {phoneAppendInput.FirstName}");
            Console.WriteLine($"Last Name  : {phoneAppendInput.LastName}");
            Console.WriteLine($"Address    : {phoneAppendInput.Address}");
            Console.WriteLine($"City       : {phoneAppendInput.City}");
            Console.WriteLine($"State      : {phoneAppendInput.State}");
            Console.WriteLine($"Postal Code: {phoneAppendInput.PostalCode}");
            Console.WriteLine($"License Key: {phoneAppendInput.LicenseKey}");
            Console.WriteLine($"Is Live    : {phoneAppendInput.IsLive}");

            PA2Response response = PhoneAppendClient.Invoke(phoneAppendInput);
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