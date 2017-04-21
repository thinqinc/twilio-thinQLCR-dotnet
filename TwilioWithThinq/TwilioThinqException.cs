using System;

namespace TwilioWithThinQLCR
{
    class TwilioThinqException : Exception
    {
        public TwilioThinqException() : base() { }
        public TwilioThinqException(string message) : base(message) { }
        public TwilioThinqException(string message, Exception inner) : base(message, inner) { }
    }
}
