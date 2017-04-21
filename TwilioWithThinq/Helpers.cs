using System;
using Twilio.Types;

namespace TwilioWithThinQLCR
{
    /// <summary>
    /// thinQ helper class
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// thinQ.com SIP domain
        /// </summary>
        public const String THINQ_DOMAIN = "wap.thinq.com";

        /// <summary>
        /// Takes a phone number and converts it to thinQ SIP call format.
        /// </summary>
        /// <param name="numberToFormat">The phone number to format.</param>
        /// <param name="thinQ_id">Registered thinQ account id to be used.</param>
        /// <param name="thinQ_token">Registered thinQ token to be used.</param>
        /// <returns>Formatted phone number object</returns>
        public static PhoneNumber FormatThinQSipNumber(IEndpoint numberToFormat, string thinQ_id, string thinQ_token)
        {
            // Check to see that this isn't alreadt a SIP call.
            if (numberToFormat != null && !numberToFormat.ToString().StartsWith("sip:"))
            {
                return new PhoneNumber("sip:" + numberToFormat.ToString() + "@" + THINQ_DOMAIN + "?thinQid=" + thinQ_id + "%26thinQtoken=" + thinQ_token);
            }

            return (PhoneNumber) numberToFormat;
        }
    }
}
