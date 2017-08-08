using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Clients;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioWithThinQLCR
{
    /// <summary>
    /// Main wrapper class that handles twilio operations that connect with thinq.
    /// </summary>
    public class TwilioWrapper
    {
        /// <summary>
        /// Twilio account sid.
        /// </summary>
        public String twilio_account_sid { get; set; }

        /// <summary>
        /// Twilio account token.
        /// </summary>
        public String twilio_account_token { get; set; }

        /// <summary>
        /// Registered thinQ id
        /// </summary>
        public String thinQ_id { get; set; }

        /// <summary>
        /// Registered thinQ token
        /// </summary>
        public String thinQ_token { get; set; }

        /// <summary>
        /// Initializes twilio wrapper object
        /// </summary>
        /// <param name="twilio_account_sid">Twilio account sid to be used.</param>
        /// <param name="twilio_account_token">Twilio account token to be used.</param>
        /// <param name="thinQ_id">Registered thinQ account id to be used.</param>
        /// <param name="thinQ_token">Registered thinQ token to be used.</param>
        public TwilioWrapper(String twilio_account_sid, String twilio_account_token, String thinQ_id, String thinQ_token)
        {
            this.twilio_account_sid = twilio_account_sid;
            this.twilio_account_token = twilio_account_token;
            this.thinQ_id = thinQ_id;
            this.thinQ_token = thinQ_token;

            TwilioClient.Init(twilio_account_sid, twilio_account_token);
        }

        /// <summary>
        /// Check if current wrapper object has a valid twilio client.
        /// </summary>
        /// <returns>true if it has valid client, otherwise false</returns>
        public bool isClientValid()
        {
            return this.twilio_account_sid != null && this.twilio_account_token != null;
        }

        /// <summary>
        /// Initiates an outgoing twilio call that calls customer phone, redirects to thinq at the time when the customer accepts the call.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="client"></param>
        /// <returns>call object if successful, exception otherwise</returns>
        public CallResource createCall(CreateCallOptions options, ITwilioRestClient client = null)
        {
            if (!this.isClientValid())
            {
                throw new Twilio.Exceptions.AuthenticationException("Invalid Twilio Account details.");
            }

            var toNumber = Helpers.FormatThinQSipNumber(options.To, this.thinQ_id, this.thinQ_token);

            var optionsWithThinQLCR = new CreateCallOptions(toNumber, options.From);
            optionsWithThinQLCR.SipAuthPassword = options.SipAuthPassword;
            optionsWithThinQLCR.SipAuthUsername = options.SipAuthUsername;
            optionsWithThinQLCR.RecordingStatusCallbackMethod = options.RecordingStatusCallbackMethod;
            optionsWithThinQLCR.RecordingStatusCallback = options.RecordingStatusCallback;
            optionsWithThinQLCR.RecordingChannels = options.RecordingChannels;
            optionsWithThinQLCR.Record = options.Record;
            optionsWithThinQLCR.Timeout = options.Timeout;
            optionsWithThinQLCR.IfMachine = options.IfMachine;
            optionsWithThinQLCR.SendDigits = options.SendDigits;
            optionsWithThinQLCR.StatusCallbackMethod = options.StatusCallbackMethod;
            optionsWithThinQLCR.StatusCallbackEvent = options.StatusCallbackEvent;
            optionsWithThinQLCR.StatusCallback = options.StatusCallback;
            optionsWithThinQLCR.FallbackMethod = options.FallbackMethod;
            optionsWithThinQLCR.FallbackUrl = options.FallbackUrl;
            optionsWithThinQLCR.Method = options.Method;
            optionsWithThinQLCR.ApplicationSid = options.ApplicationSid;
            optionsWithThinQLCR.Url = options.Url;
            optionsWithThinQLCR.PathAccountSid = options.PathAccountSid;
            optionsWithThinQLCR.MachineDetection = options.MachineDetection;
            optionsWithThinQLCR.MachineDetectionTimeout = options.MachineDetectionTimeout;

            return CallResource.Create(optionsWithThinQLCR, client);
        }

#if !NET35
        /// <summary>
        /// Initiates an outgoing twilio call that calls customer phone, redirects to thinq at the time when the customer accepts the call.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="client"></param>
        /// <returns>call object if successful, exception otherwise</returns>
        public async System.Threading.Tasks.Task<CallResource> createCallAsync(CreateCallOptions options, ITwilioRestClient client = null)
        {
            if (!this.isClientValid())
            {
                throw new Twilio.Exceptions.AuthenticationException("Invalid Twilio Account details.");
            }

            var toNumber = Helpers.FormatThinQSipNumber(options.To, this.thinQ_id, this.thinQ_token);

            var optionsWithThinQLCR = new CreateCallOptions(toNumber, options.From);
            optionsWithThinQLCR.SipAuthPassword = options.SipAuthPassword;
            optionsWithThinQLCR.SipAuthUsername = options.SipAuthUsername;
            optionsWithThinQLCR.RecordingStatusCallbackMethod = options.RecordingStatusCallbackMethod;
            optionsWithThinQLCR.RecordingStatusCallback = options.RecordingStatusCallback;
            optionsWithThinQLCR.RecordingChannels = options.RecordingChannels;
            optionsWithThinQLCR.Record = options.Record;
            optionsWithThinQLCR.Timeout = options.Timeout;
            optionsWithThinQLCR.IfMachine = options.IfMachine;
            optionsWithThinQLCR.SendDigits = options.SendDigits;
            optionsWithThinQLCR.StatusCallbackMethod = options.StatusCallbackMethod;
            optionsWithThinQLCR.StatusCallbackEvent = options.StatusCallbackEvent;
            optionsWithThinQLCR.StatusCallback = options.StatusCallback;
            optionsWithThinQLCR.FallbackMethod = options.FallbackMethod;
            optionsWithThinQLCR.FallbackUrl = options.FallbackUrl;
            optionsWithThinQLCR.Method = options.Method;
            optionsWithThinQLCR.ApplicationSid = options.ApplicationSid;
            optionsWithThinQLCR.Url = options.Url;
            optionsWithThinQLCR.PathAccountSid = options.PathAccountSid;
            optionsWithThinQLCR.MachineDetection = options.MachineDetection;
            optionsWithThinQLCR.MachineDetectionTimeout = options.MachineDetectionTimeout;

            return await CallResource.CreateAsync(optionsWithThinQLCR, client);
        }
#endif

        /// <summary>
        /// Initiates an outgoing twilio call that calls customer phone, redirects to thinq at the time when the customer accepts the call.
        /// </summary>
        /// <param name="from">'from' number</param>
        /// <param name="pathAccountSid"></param>
        /// <param name="to">'to' number</param>
        /// <param name="url">TwiML location</param>
        /// <param name="applicationSid"></param>
        /// <param name="method"></param>
        /// <param name="fallbackUrl"></param>
        /// <param name="fallbackMethod"></param>
        /// <param name="statusCallback"></param>
        /// <param name="statusCallbackEvent"></param>
        /// <param name="statusCallbackMethod"></param>
        /// <param name="sendDigits"></param>
        /// <param name="ifMachine"></param>
        /// <param name="timeout"></param>
        /// <param name="record"></param>
        /// <param name="recordingChannels"></param>
        /// <param name="recordingStatusCallback"></param>
        /// <param name="recordingStatusCallbackMethod"></param>
        /// <param name="sipAuthUsername"></param>
        /// <param name="sipAuthPassword"></param>
        /// <param name="machineDetection"></param>
        /// <param name="machineDetectionTimeout"></param>
        /// <param name="client"></param>
        /// <returns>call object if successful, exception otherwise</returns>
        public CallResource createCall(IEndpoint to, PhoneNumber from, string pathAccountSid = null, Uri url = null, string applicationSid = null, HttpMethod method = null, Uri fallbackUrl = null, HttpMethod fallbackMethod = null, Uri statusCallback = null, List<string> statusCallbackEvent = null, HttpMethod statusCallbackMethod = null, string sendDigits = null, string ifMachine = null, int? timeout = default(int?), bool? record = default(bool?), string recordingChannels = null, string recordingStatusCallback = null, HttpMethod recordingStatusCallbackMethod = null, string sipAuthUsername = null, string sipAuthPassword = null, string machineDetection = null, int? machineDetectionTimeout = default(int?), ITwilioRestClient client = null)
        {
            if (!this.isClientValid())
            {
                throw new Twilio.Exceptions.AuthenticationException("Invalid Twilio Account details.");
            }

            var toNumber = Helpers.FormatThinQSipNumber(to, this.thinQ_id, this.thinQ_token);

            CreateCallOptions optionsWithThinQLCR = new CreateCallOptions(toNumber, from);
            optionsWithThinQLCR.SipAuthPassword = sipAuthPassword;
            optionsWithThinQLCR.SipAuthUsername = sipAuthUsername;
            optionsWithThinQLCR.RecordingStatusCallbackMethod = recordingStatusCallbackMethod;
            optionsWithThinQLCR.RecordingStatusCallback = recordingStatusCallback;
            optionsWithThinQLCR.RecordingChannels = recordingChannels;
            optionsWithThinQLCR.Record = record;
            optionsWithThinQLCR.Timeout = timeout;
            optionsWithThinQLCR.IfMachine = ifMachine;
            optionsWithThinQLCR.SendDigits = sendDigits;
            optionsWithThinQLCR.StatusCallbackMethod = statusCallbackMethod;
            optionsWithThinQLCR.StatusCallbackEvent = statusCallbackEvent;
            optionsWithThinQLCR.StatusCallback = statusCallback;
            optionsWithThinQLCR.FallbackMethod = fallbackMethod;
            optionsWithThinQLCR.FallbackUrl = fallbackUrl;
            optionsWithThinQLCR.Method = method;
            optionsWithThinQLCR.ApplicationSid = applicationSid;
            optionsWithThinQLCR.Url = url;
            optionsWithThinQLCR.PathAccountSid = pathAccountSid;
            optionsWithThinQLCR.MachineDetection = machineDetection;
            optionsWithThinQLCR.MachineDetectionTimeout = machineDetectionTimeout;

            return CallResource.Create(optionsWithThinQLCR, client);
        }

#if !NET35
        /// <summary>
        /// Initiates an outgoing twilio call that calls customer phone, redirects to thinq at the time when the customer accepts the call.
        /// </summary>
        /// <param name="from">'from' number</param>
        /// <param name="pathAccountSid"></param>
        /// <param name="to">'to' number</param>
        /// <param name="url">TwiML location</param>
        /// <param name="applicationSid"></param>
        /// <param name="method"></param>
        /// <param name="fallbackUrl"></param>
        /// <param name="fallbackMethod"></param>
        /// <param name="statusCallback"></param>
        /// <param name="statusCallbackEvent"></param>
        /// <param name="statusCallbackMethod"></param>
        /// <param name="sendDigits"></param>
        /// <param name="ifMachine"></param>
        /// <param name="timeout"></param>
        /// <param name="record"></param>
        /// <param name="recordingChannels"></param>
        /// <param name="recordingStatusCallback"></param>
        /// <param name="recordingStatusCallbackMethod"></param>
        /// <param name="sipAuthUsername"></param>
        /// <param name="sipAuthPassword"></param>
        /// <param name="machineDetection"></param>
        /// <param name="machineDetectionTimeout"></param>
        /// <param name="client"></param>
        /// <returns>call object if successful, exception otherwise</returns>
        public async System.Threading.Tasks.Task<CallResource> createCallAsync(IEndpoint to, PhoneNumber from, string pathAccountSid = null, Uri url = null, string applicationSid = null, HttpMethod method = null, Uri fallbackUrl = null, HttpMethod fallbackMethod = null, Uri statusCallback = null, List<string> statusCallbackEvent = null, HttpMethod statusCallbackMethod = null, string sendDigits = null, string ifMachine = null, int? timeout = default(int?), bool? record = default(bool?), string recordingChannels = null, string recordingStatusCallback = null, HttpMethod recordingStatusCallbackMethod = null, string sipAuthUsername = null, string sipAuthPassword = null, string machineDetection = null, int? machineDetectionTimeout = default(int?), ITwilioRestClient client = null)
        {
            if (!this.isClientValid())
            {
                throw new Twilio.Exceptions.AuthenticationException("Invalid Twilio Account details.");
            }

            var toNumber = Helpers.FormatThinQSipNumber(to, this.thinQ_id, this.thinQ_token);

            CreateCallOptions optionsWithThinQLCR = new CreateCallOptions(toNumber, from);
            optionsWithThinQLCR.SipAuthPassword = sipAuthPassword;
            optionsWithThinQLCR.SipAuthUsername = sipAuthUsername;
            optionsWithThinQLCR.RecordingStatusCallbackMethod = recordingStatusCallbackMethod;
            optionsWithThinQLCR.RecordingStatusCallback = recordingStatusCallback;
            optionsWithThinQLCR.RecordingChannels = recordingChannels;
            optionsWithThinQLCR.Record = record;
            optionsWithThinQLCR.Timeout = timeout;
            optionsWithThinQLCR.IfMachine = ifMachine;
            optionsWithThinQLCR.SendDigits = sendDigits;
            optionsWithThinQLCR.StatusCallbackMethod = statusCallbackMethod;
            optionsWithThinQLCR.StatusCallbackEvent = statusCallbackEvent;
            optionsWithThinQLCR.StatusCallback = statusCallback;
            optionsWithThinQLCR.FallbackMethod = fallbackMethod;
            optionsWithThinQLCR.FallbackUrl = fallbackUrl;
            optionsWithThinQLCR.Method = method;
            optionsWithThinQLCR.ApplicationSid = applicationSid;
            optionsWithThinQLCR.Url = url;
            optionsWithThinQLCR.PathAccountSid = pathAccountSid;
            optionsWithThinQLCR.MachineDetection = machineDetection;
            optionsWithThinQLCR.MachineDetectionTimeout = machineDetectionTimeout;

            return await CallResource.CreateAsync(optionsWithThinQLCR, client);
        }
#endif
    }
}
