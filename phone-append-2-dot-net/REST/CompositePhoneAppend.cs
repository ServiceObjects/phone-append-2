using System.Web;

namespace phone_append_2_dot_net.REST
{
    /// <summary>
    /// Provides functionality to call the ServiceObjects CompositePhoneAppend (PA2) REST API's CompositePhoneAppend endpoint,
    /// retrieving phone number information for a contact (business or residential) based on provided inputs with fallback to a backup endpoint for reliability in live mode.
    /// </summary>
    public static class CompositePhoneAppendClient
    {
        // Base URL constants: production, backup, and trial
        private const string LiveBaseUrl = "https://sws.serviceobjects.com/pa2/api.svc/json/";
        private const string BackupBaseUrl = "https://swsbackup.serviceobjects.com/pa2/api.svc/json/";
        private const string TrialBaseUrl = "https://trial.serviceobjects.com/pa2/api.svc/json/";

        /// <summary>
        /// Synchronously calls the CompositePhoneAppend REST endpoint to retrieve phone number information,
        /// attempting the primary endpoint first and falling back to the backup if the response is invalid
        /// (Error.TypeCode == "3") in live mode.
        /// </summary>
        /// <param name="input">The input parameters including name, address, city, state, postal code, isBusiness, and license key.</param>
        /// <returns>Deserialized <see cref="PA2Response"/> containing phone number data or an error.</returns>
        public static PA2Response Invoke(CompositePhoneAppendInput input)
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
        /// Asynchronously calls the CompositePhoneAppend REST endpoint to retrieve phone number information,
        /// attempting the primary endpoint first and falling back to the backup if the response is invalid
        /// (Error.TypeCode == "3") in live mode.
        /// </summary>
        /// <param name="input">The input parameters including name, address, city, state, postal code, isBusiness, and license key.</param>
        /// <returns>Deserialized <see cref="PA2Response"/> containing phone number data or an error.</returns>
        public static async Task<PA2Response> InvokeAsync(CompositePhoneAppendInput input)
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
        private static string BuildUrl(CompositePhoneAppendInput input, string baseUrl)
        {
            // Construct query string with URL-encoded parameters
            string qs = $"CompositePhoneAppendJson?" +
                        $"Name={Helper.UrlEncode(input.Name)}" +
                        $"&Address={Helper.UrlEncode(input.Address)}" +
                        $"&City={Helper.UrlEncode(input.City)}" +
                        $"&State={Helper.UrlEncode(input.State)}" +
                        $"&PostalCode={Helper.UrlEncode(input.PostalCode)}" +
                        $"&IsBusiness={Helper.UrlEncode(input.IsBusiness)}" +
                        $"&LicenseKey={Helper.UrlEncode(input.LicenseKey)}";
            return baseUrl + qs;
        }

        private static bool ValidResponse(PA2Response response)
        {
            return (response?.Error == null || response.Error.TypeCode != "3");
        }

        /// <summary>
        /// Input parameters for the CompositePhoneAppend API call. Represents a contact (business or residential) to retrieve phone number information.
        /// </summary>
        /// <param name="Name">The name of the contact.</param>
        /// <param name="Address">Address line of the contact. Optional.</param>
        /// <param name="City">The city of the contact.</param>
        /// <param name="State">The state of the contact.</param>
        /// <param name="PostalCode">The postal code of the contact. Optional.</param>
        /// <param name="IsBusiness">Indicates if the contact is a business ("True", "False", or empty to let the service decide). Optional.</param>
        /// <param name="LicenseKey">The license key to authenticate the API request.</param>
        /// <param name="IsLive">Indicates whether to use the live service (true) or trial service (false).</param>
        /// <param name="TimeoutSeconds">Timeout duration for the API call, in seconds.</param>
        public record CompositePhoneAppendInput(
            string Name = "",
            string Address = "",
            string City = "",
            string State = "",
            string PostalCode = "",
            string IsBusiness = "",
            string LicenseKey = "",
            bool IsLive = true,
            int TimeoutSeconds = 15
        );
    }
}