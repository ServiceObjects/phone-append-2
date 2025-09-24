using System;
using phone_append_2_dot_net.REST;

namespace phone_append_2_dot_net_examples
{
    public class BusinessPhoneAppendRestSdkExample
    {
        public static void Go(string licenseKey, bool isLive)
        {
            Console.WriteLine("\r\n---------------------------------------------");
            Console.WriteLine("PhoneAppend2 - BusinessPhoneAppend - REST SDK");
            Console.WriteLine("---------------------------------------------");

            BusinessPhoneAppendClient.BusinessPhoneAppendInput businessPhoneAppendInput = new(
                BusinessName: "Brooks Institute",
                Address: "27 E Cota ST",
                City: "Santa Barbara",
                State: "CA",
                PostalCode: "93101",
                LicenseKey: licenseKey,
                IsLive: isLive,
                TimeoutSeconds: 15
            );

            Console.WriteLine("\r\n* Input *\r\n");
            Console.WriteLine($"Business Name: {businessPhoneAppendInput.BusinessName}");
            Console.WriteLine($"Address      : {businessPhoneAppendInput.Address}");
            Console.WriteLine($"City         : {businessPhoneAppendInput.City}");
            Console.WriteLine($"State        : {businessPhoneAppendInput.State}");
            Console.WriteLine($"Postal Code  : {businessPhoneAppendInput.PostalCode}");
            Console.WriteLine($"License Key  : {businessPhoneAppendInput.LicenseKey}");
            Console.WriteLine($"Is Live      : {businessPhoneAppendInput.IsLive}");

            PA2Response response = BusinessPhoneAppendClient.Invoke(businessPhoneAppendInput);
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