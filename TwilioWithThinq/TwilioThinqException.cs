using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilioWithThinQLCR
{
    [Serializable()]
    class TwilioThinqException : System.Exception
    {
        public TwilioThinqException() : base() { }
        public TwilioThinqException(string message) : base(message) { }
        public TwilioThinqException(string message, System.Exception inner) : base(message, inner) { }

        protected TwilioThinqException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
}
