using System;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioWithThinQLCR
{
    /// <summary>
    /// Create Call Options object using ThinQ LCR
    /// </summary>
    public class CreateCallOptionsWithThinQLCR : CreateCallOptions
    {
        /// <summary>
        /// Initializes twilio wrapper object
        /// </summary>
        /// <param name="thinQ_id">registered thinQ id to be used.</param>
        /// <param name="thinQ_token"></param>
        /// <param name="to"></param>
        /// <param name="from"></param>
        public CreateCallOptionsWithThinQLCR(string thinQ_id, string thinQ_token, IEndpoint to, PhoneNumber from) : base(ModifyTo(thinQ_id, thinQ_token, to), from)
        {
        }

        /// <summary>
        /// Initializes twilio wrapper object
        /// </summary>
        /// <param name="thinQ_id">registered thinQ id to be used.</param>
        /// <param name="thinQ_token">>registered thinQ token to be used.</param>
        /// <param name="to"></param>
        private static IEndpoint ModifyTo(string thinQ_id, string thinQ_token, IEndpoint to)
        {
            return Helpers.FormatThinQSipNumber(to, thinQ_id, thinQ_token);
        }
    }
}
