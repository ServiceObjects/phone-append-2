using System;
using System.Threading.Tasks;
using PA2Reference;

namespace phone_append_2_dot_net.SOAP
{
    /// <summary>
    /// Provides functionality to call the ServiceObjects PhoneAppend2 (PA2) SOAP service's PhoneAppend operation,
    /// retrieving phone number information for a contact based on provided inputs with fallback to a backup endpoint for reliability in live mode.
    /// </summary>
    public class PhoneAppendValidation
    {
        private const string LiveBaseUrl = "https://sws.serviceobjects.com/PA2/api.svc/soap";
        private const string BackupBaseUrl = "https://swsbackup.serviceobjects.com/PA2/api.svc/soap";
        private const string TrialBaseUrl = "https://trial.serviceobjects.com/PA2/api.svc/soap";

        private readonly string _primaryUrl;
        private readonly string _backupUrl;
        private readonly int _timeoutMs;
        private readonly bool _isLive;

        /// <summary>
        /// Initializes URLs/timeout/IsLive.
        /// </summary>
        public PhoneAppendValidation(bool isLive)
        {
            _timeoutMs = 10000;
            _isLive = isLive;

            _primaryUrl = isLive ? LiveBaseUrl : TrialBaseUrl;
            _backupUrl = isLive ? BackupBaseUrl : TrialBaseUrl;

            if (string.IsNullOrWhiteSpace(_primaryUrl))
                throw new InvalidOperationException("Primary URL not set.");
            if (string.IsNullOrWhiteSpace(_backupUrl))
                throw new InvalidOperationException("Backup URL not set.");
        }

        /// <summary>
        /// This operation returns the best available phone number match for a given contact, including phone number,
        /// name, address, city, state, postal code, residential status, certainty, and line type.
        /// </summary>
        /// <param name="FullName">The full name of the contact. Optional if FirstName and LastName are provided.</param>
        /// <param name="FirstName">The first name of the contact. Optional if FullName is provided.</param>
        /// <param name="LastName">The last name of the contact. Optional if FullName is provided.</param>
        /// <param name="Address">Address line of the contact. Optional.</param>
        /// <param name="City">The city of the contact. Optional if postal code is provided.</param>
        /// <param name="State">The state of the contact. Optional if postal code is provided.</param>
        /// <param name="PostalCode">The postal code of the contact. Optional if city and state are provided.</param>
        /// <param name="LicenseKey">The license key to authenticate the API request.</param>
        public async Task<PhoneInfoResponse> PhoneAppendAsync(string FullName, string FirstName, string LastName, string Address, string City, string State, string PostalCode, string LicenseKey)
        {
            PhoneAppend2Client clientPrimary = null;
            PhoneAppend2Client clientBackup = null;

            try
            {
                // Attempt Primary
                clientPrimary = new PhoneAppend2Client();
                clientPrimary.Endpoint.Address = new System.ServiceModel.EndpointAddress(_primaryUrl);
                clientPrimary.InnerChannel.OperationTimeout = TimeSpan.FromMilliseconds(_timeoutMs);

                PhoneInfoResponse response = await clientPrimary.PhoneAppendAsync(
                    FullName, FirstName, LastName, Address, City, State, PostalCode, LicenseKey).ConfigureAwait(false);

                if (_isLive && !ValidResponse(response))
                {
                    throw new InvalidOperationException("Primary endpoint returned null or a fatal TypeCode=3 error for PhoneAppend");
                }
                return response;
            }
            catch (Exception primaryEx)
            {
                try
                {
                    clientBackup = new PhoneAppend2Client();
                    clientBackup.Endpoint.Address = new System.ServiceModel.EndpointAddress(_backupUrl);
                    clientBackup.InnerChannel.OperationTimeout = TimeSpan.FromMilliseconds(_timeoutMs);

                    return await clientBackup.PhoneAppendAsync(
                        FullName, FirstName, LastName, Address, City, State, PostalCode, LicenseKey).ConfigureAwait(false);
                }
                catch (Exception backupEx)
                {
                    throw new InvalidOperationException(
                        $"Both primary and backup endpoints failed.\n" +
                        $"Primary error: {primaryEx.Message}\n" +
                        $"Backup error: {backupEx.Message}");
                }
                finally
                {
                    clientBackup?.CloseAsync().GetAwaiter().GetResult();
                }
            }
            finally
            {
                clientPrimary?.CloseAsync().GetAwaiter().GetResult();
            }
        }

        private static bool ValidResponse(PhoneInfoResponse response)
        {
            return (response?.Error == null || response.Error.TypeCode != "3");
        }
    }
}