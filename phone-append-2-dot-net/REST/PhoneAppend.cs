using System.Web;

namespace phone_append_2_dot_net.REST
{
    /// <summary>
    /// Provides functionality to call the ServiceObjects PhoneAppend (PA2) REST API's PhoneAppend endpoint,
    /// retrieving phone number information for a contact based on provided inputs with fallback to a backup endpoint for reliability in live mode.
    /// </summary>
    public static class PhoneAppendClient  
    {
        // Base URL constants: production, backup, and trial
        private const string LiveBaseUrl = "https://sws.serviceobjects.com/pa2/api.svc/json/";
        private const string BackupBaseUrl = "https://swsbackup.serviceobjects.com/pa2/api.svc/json/";
        private const string TrialBaseUrl = "https://trial.serviceobjects.com/pa2/api.svc/json/";

        /// <summary>
        /// Synchronously calls the PhoneAppend REST endpoint to retrieve phone number information,
        /// attempting the primary endpoint first and falling back to the backup if the response is invalid
        /// (Error.TypeCode == "3") in live mode.
        /// </summary>
        /// <param name="input">The input parameters including full name, first name, last name, address, city, state, postal code, and license key.</param>
        /// <returns>Deserialized <see cref="PA2Response"/> containing phone number data or an error.</returns>
        public static PA2Response Invoke(PhoneAppendInput input)
        {
            // Use query string parameters so missing/optional fields don't break the URL
            string url = BuildUrl(input, input.IsLive ? LiveBaseUrl : TrialBaseUrl);
            PA2Response response = Helper.HttpGet<PA2Response>(url, input.TimeoutSeconds);

            // Fallback on error in live mode
            if (input.IsLive && !ValidResponse(response))
            {
                string fallbackUrl = BuildUrl(input, BackupBaseUrl);
                PA2Response fallbackResponse = Helper.HttpGet<PA2Response>(fallbackUrl, input.TimeoutSeconds);
                return fallbackResponse;
            }

            return response;
        }

        /// <summary>
        /// Asynchronously calls the PhoneAppend REST endpoint to retrieve phone number information,
        /// attempting the primary endpoint first and falling back to the backup if the response is invalid
        /// (Error.TypeCode == "3") in live mode.
        /// </summary>
        /// <param name="input">The input parameters including full name, first name, last name, address, city, state, postal code, and license key.</param>
        /// <returns>Deserialized <see cref="PA2Response"/> containing phone number data or an error.</returns>
        public static async Task<PA2Response> InvokeAsync(PhoneAppendInput input)
        {
            // Use query string parameters so missing/optional fields don't break the URL
            string url = BuildUrl(input, input.IsLive ? LiveBaseUrl : TrialBaseUrl);
            PA2Response response = await Helper.HttpGetAsync<PA2Response>(url, input.TimeoutSeconds).ConfigureAwait(false);

            // Fallback on error in live mode
            if (input.IsLive && !ValidResponse(response))
            {
                string fallbackUrl = BuildUrl(input, BackupBaseUrl);
                PA2Response fallbackResponse = await Helper.HttpGetAsync<PA2Response>(fallbackUrl, input.TimeoutSeconds).ConfigureAwait(false);
                return fallbackResponse;
            }

            return response;
        }

        // Build the full request URL, including URL-encoded query string
        private static string BuildUrl(PhoneAppendInput input, string baseUrl)
        {
            // Construct query string with URL-encoded parameters
            string qs = $"PhoneAppendJson?" +
                        $"FullName={Helper.UrlEncode(input.FullName)}" +
                        $"&FirstName={Helper.UrlEncode(input.FirstName)}" +
                        $"&LastName={Helper.UrlEncode(input.LastName)}" +
                        $"&Address={Helper.UrlEncode(input.Address)}" +
                        $"&City={Helper.UrlEncode(input.City)}" +
                        $"&State={Helper.UrlEncode(input.State)}" +
                        $"&PostalCode={Helper.UrlEncode(input.PostalCode)}" +
                        $"&LicenseKey={Helper.UrlEncode(input.LicenseKey)}";
            return baseUrl + qs;
        }

        private static bool ValidResponse(PA2Response response)
        {
            return (response?.Error == null || response.Error.TypeCode != "3");
        }

        /// <summary>
        /// Input parameters for the PhoneAppend API call. Represents a contact to retrieve phone number information.
        /// </summary>
        /// <param name="FullName">The full name of the contact. Optional if FirstName and LastName are provided.</param>
        /// <param name="FirstName">The first name of the contact. Optional if FullName is provided.</param>
        /// <param name="LastName">The last name of the contact. Optional if FullName is provided.</param>
        /// <param name="Address">Address line of the contact. Optional.</param>
        /// <param name="City">The city of the contact. Optional if postal code is provided.</param>
        /// <param name="State">The state of the contact. Optional if postal code is provided.</param>
        /// <param name="PostalCode">The postal code of the contact. Optional if city and state are provided.</param>
        /// <param name="LicenseKey">The license key to authenticate the API request.</param>
        /// <param name="IsLive">Indicates whether to use the live service (true) or trial service (false).</param>
        /// <param name="TimeoutSeconds">Timeout duration for the API call, in seconds.</param>
        public record PhoneAppendInput(
            string FullName = "",
            string FirstName = "",
            string LastName = "",
            string Address = "",
            string City = "",
            string State = "",
            string PostalCode = "",
            string LicenseKey = "",
            bool IsLive = true,
            int TimeoutSeconds = 15
        );
    }
}