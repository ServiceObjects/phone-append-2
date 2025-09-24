import axios from 'axios';
import querystring from 'querystring';
import { PA2Response } from './pa2_response.js';

/**
 * @constant
 * @type {string}
 * @description The base URL for the live ServiceObjects PhoneAppend2 (PA2) API service.
 */
const LiveBaseUrl = 'https://sws.serviceobjects.com/pa2/api.svc/json/';

/**
 * @constant
 * @type {string}
 * @description The base URL for the backup ServiceObjects PhoneAppend2 (PA2) API service.
 */
const BackupBaseUrl = 'https://swsbackup.serviceobjects.com/pa2/api.svc/json/';

/**
 * @constant
 * @type {string}
 * @description The base URL for the trial ServiceObjects PhoneAppend2 (PA2) API service.
 */
const TrialBaseUrl = 'https://trial.serviceobjects.com/pa2/api.svc/json/';

/**
 * <summary>
 * Checks if a response from the API is valid by verifying that it either has no Error object
 * or the Error.TypeCode is not equal to '3'.
 * </summary>
 * <param name="response" type="Object">The API response object to validate.</param>
 * <returns type="boolean">True if the response is valid, false otherwise.</returns>
 */
const isValid = (response) => !response?.Error || response.Error.TypeCode !== '3';

/**
 * <summary>
 * Constructs a full URL for the CompositePhoneAppendJson API endpoint by combining the base URL
 * with query parameters derived from the input parameters.
 * </summary>
 * <param name="params" type="Object">An object containing all the input parameters.</param>
 * <param name="baseUrl" type="string">The base URL for the API service (live, backup, or trial).</param>
 * <returns type="string">The constructed URL with query parameters.</returns>
 */
const buildUrl = (params, baseUrl) =>
    `${baseUrl}CompositePhoneAppendJson?${querystring.stringify(params)}`;

/**
 * <summary>
 * Performs an HTTP GET request to the specified URL with a given timeout.
 * </summary>
 * <param name="url" type="string">The URL to send the GET request to.</param>
 * <param name="timeoutSeconds" type="number">The timeout duration in seconds for the request.</param>
 * <returns type="Promise<PA2Response>">A promise that resolves to a PA2Response object containing the API response data.</returns>
 * <exception cref="Error">Thrown if the HTTP request fails, with a message detailing the error.</exception>
 */
const httpGet = async (url, timeoutSeconds) => {
    try {
        const response = await axios.get(url, { timeout: timeoutSeconds * 1000 });
        return new PA2Response(response.data);
    } catch (error) {
        throw new Error(`HTTP request failed: ${error.message}`);
    }
};

/**
 * <summary>
 * Provides functionality to call the ServiceObjects PhoneAppend2 (PA2) API's CompositePhoneAppendJson endpoint,
 * retrieving phone number information for a contact (business or residential) based on provided inputs with fallback to a backup endpoint for reliability in live mode.
 * </summary>
 */
const CompositePhoneAppendClient = {
    /**
     * <summary>
     * Asynchronously invokes the CompositePhoneAppendJson API endpoint, attempting the primary endpoint
     * first and falling back to the backup if the response is invalid (Error.TypeCode == '3') in live mode.
     * </summary>
     * @param {string} Name - The name of the contact.
     * @param {string} Address - Address line of the contact. Optional.
     * @param {string} City - The city of the contact.
     * @param {string} State - The state of the contact
     * @param {string} PostalCode - The postal code of the contact (e.g., "93101"). Optional.
     * @param {string} IsBusiness - Indicates if the contact is a business ("True", "False", or empty). Optional.
     * @param {string} LicenseKey - Your license key to use the service.
     * @param {boolean} isLive - Value to determine whether to use the live or trial servers.
     * @param {number} timeoutSeconds - Timeout, in seconds, for the call to the service.
     * @returns {Promise<PA2Response>} - A promise that resolves to a PA2Response object.
     */
    async invokeAsync(Name, Address, City, State, PostalCode, IsBusiness, LicenseKey, isLive = true, timeoutSeconds = 15) {
        const params = {
            Name,
            Address,
            City,
            State,
            PostalCode,
            IsBusiness,
            LicenseKey
        };

        const url = buildUrl(params, isLive ? LiveBaseUrl : TrialBaseUrl);
        let response = await httpGet(url, timeoutSeconds);

        if (isLive && !isValid(response)) {
            const fallbackUrl = buildUrl(params, BackupBaseUrl);
            const fallbackResponse = await httpGet(fallbackUrl, timeoutSeconds);
            return fallbackResponse;
        }
        return response;
    },

    /**
     * <summary>
     * Synchronously invokes the CompositePhoneAppendJson API endpoint by wrapping the async call
     * and awaiting its result immediately.
     * </summary>
     * @param {string} Name - The name of the contact.
     * @param {string} Address - Address line of the contact. Optional.
     * @param {string} City - The city of the contact.
     * @param {string} State - The state of the contact.
     * @param {string} PostalCode - The postal code of the contact. Optional.
     * @param {string} IsBusiness - Indicates if the contact is a business ("True", "False", or empty). Optional.
     * @param {string} LicenseKey - Your license key to use the service.
     * @param {boolean} isLive - Value to determine whether to use the live or trial servers.
     * @param {number} timeoutSeconds - Timeout, in seconds, for the call to the service.
     * @returns {PA2Response} - A PA2Response object with phone number details or an error.
     */
    invoke(Name, Address, City, State, PostalCode, IsBusiness, LicenseKey, isLive = true, timeoutSeconds = 15) {
        return (async () => await this.invokeAsync(
            Name, Address, City, State, PostalCode, IsBusiness, LicenseKey, isLive, timeoutSeconds
        ))();
    }
};

export { CompositePhoneAppendClient, PA2Response };