using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace TwilioWithThinQLCR
{
    /// <summary>
    /// Main wrapper class that handles twilio operations that connect with thinq.
    /// </summary>
    public class TwilioWrapper
    {
        /// <summary>
        /// thinQ.com sip domain
        /// </summary>
        public const String THINQ_DOMAIN = "wap.thinq.com";

        /// <summary>
        /// Embedded callback url for twilio calls.
        /// </summary>
        public const String TWIML_RESOURCE_URL = "http://demo.twilio.com/docs/voice.xml";

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
        /// Twilio service REST client
        /// </summary>
        public TwilioRestClient client { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TwilioWrapper()
        {

        }

        /// <summary>
        /// Initializes twilio wrapper object
        /// </summary>
        /// <param name="twilio_account_sid">twilio account sid to be used.</param>
        /// <param name="twilio_account_token">twilio account token to be used.</param>
        /// <param name="thinQ_id">registered thinQ id to be used.</param>
        /// <param name="thinQ_token">>registered thinQ token to be used.</param>
        public TwilioWrapper(String twilio_account_sid, String twilio_account_token, String thinQ_id, String thinQ_token)
        {
            this.twilio_account_sid = twilio_account_sid;
            this.twilio_account_token = twilio_account_token;
            this.thinQ_id = thinQ_id;
            this.thinQ_token = thinQ_token;

            this.client = new TwilioRestClient(twilio_account_sid, twilio_account_token);
        }

        /// <summary>
        /// Check if current wrapper object has a valid twilio client.
        /// </summary>
        /// <returns>true if it has valid client, otherwise false</returns>
        public bool isClientValid()
        {
            return this.client != null && this.client.GetAccount() != null;
        }

        /// <summary>
        /// Initiates an outgoing twilio call that calls customer phone, redirects to thinq at the time when the customer accepts the call.
        /// </summary>
        /// <param name="from">'from' number</param>
        /// <param name="to">'to' number</param>
        /// <param name="url">TwiML location</param>
        /// <returns>call object if successful, exception otherwise</returns>
        public Call call(String from, String to, String url = TWIML_RESOURCE_URL)
        {
            if (!this.isClientValid())
            {
                throw new TwilioThinqException("Invalid Twilio Account details.");
            }

            try
            {
                var options = new CallOptions();
                options.Url = url;
                options.To = "sip:" + to + "@" + THINQ_DOMAIN + "?thinQid=" + this.thinQ_id + "&thinQtoken=" + this.thinQ_token;
                options.From = from;
                return this.client.InitiateOutboundCall(options);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Initiates an outgoing twilio call that calls customer phone, redirects to thinq at the time when the customer accepts the call.
        /// </summary>
        /// <param name="callOptions">Populated CallOptions object</param>
        /// <returns>call object if successful, exception otherwise</returns>
        public Call call(CallOptions callOptions)
        {
            if (!this.isClientValid())
            {
                throw new TwilioThinqException("Invalid Twilio Account details.");
            }

            if (callOptions.To == "")
            {
                throw new TwilioThinqException("'To' number is required.");
            }
            if (callOptions.From == "")
            {
                throw new TwilioThinqException("'From' number is required.");
            }
            if (callOptions.Url == "")
            {
                throw new TwilioThinqException("'Url' is required.");
            }

            try
            {
                callOptions.To = "sip:" + callOptions.To + "@" + THINQ_DOMAIN + "?thinQid=" + this.thinQ_id + "&thinQtoken=" + this.thinQ_token;
                return this.client.InitiateOutboundCall(callOptions);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
