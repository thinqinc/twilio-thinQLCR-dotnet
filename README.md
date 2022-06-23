# Twilio .NET SDK 5.X Wrapper Library For thinQ LCR integration

**This package is no longer maintainted. You should use the rest API instead**
--------------------------------------------------------------------------

#### Note that you will need a valid LCR Account with thinQ before using the libraries. For more information please contact your thinQ Sales representative at [http://www.thinq.com](http://www.thinq.com)

Example usage:

```C#
using System;
using TwilioWithThinQLCR;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string thinqAccountId = "thinqAccountId";
            string thinqToken = "thinqToken";
            string twilioSid = "twilioSid";
            string twilioToken = "twilioToken";

            //
            // Example using a callOptions object
            //

            // Initialize the Twilio rest client using your Twilio SID and Token.
            TwilioClient.Init(twilioSid, twilioToken);

            // Create a thinQ callOptions object, passing in your thinQ ID and ThinQ Token.
            CreateCallOptionsWithThinQLCR callOptions = new CreateCallOptionsWithThinQLCR(thinqAccountId, thinqToken, new PhoneNumber("19195551234"), new PhoneNumber("19198900000"));
            // Populate your callOptions object with any additional parameters like normal.
            callOptions.Url = new Uri("https://demo.twilio.com/docs/voice.xml");

            // Create your call as you normally would.
            var call = CallResource.Create(callOptions);
            Console.WriteLine("Call sid: " + call.Sid);
            Console.ReadLine();


            //
            // Example using the thinQ wrapper
            //

            // Create a wrapper object, psasing in your Twilio SID, Twilio Token, thinQ ID and thinQ Token.
            TwilioWrapper wrapper = new TwilioWrapper(twilioSid, twilioToken, thinqAccountId, thinqToken);

            // Call the createCall method on the wrapper as normal.
            var call2 = wrapper.createCall(new PhoneNumber("19195551234"), new PhoneNumber("19198900000"), url: new Uri("https://demo.twilio.com/docs/voice.xml"));
            Console.WriteLine("Call2 sid: " + call2.Sid);
            Console.ReadLine();


            //
            // Example using the thinQ wrapper and callOptions.
            //

            // Create a wrapper object, psasing in your Twilio SID, Twilio Token, thinQ ID and thinQ Token.
            TwilioWrapper wrapper2 = new TwilioWrapper(twilioSid, twilioToken, thinqAccountId, thinqToken);

            // Create a callOptions object, passing in your to and from numbers.
            CreateCallOptions callOptions2 = new CreateCallOptions(new PhoneNumber("19195551234"), new PhoneNumber("19198900000"));
            // Populate your callOptions object with any additional parameters like normal.
            callOptions2.Url = new Uri("https://demo.twilio.com/docs/voice.xml");

            // Call the createCall method on the wrapper as normal.
            CallResource call3 = wrapper2.createCall(callOptions);
            Console.WriteLine("Call sid: " + call3.Sid);
            Console.ReadLine();
        }
    }
}

```
---

###### *Copyright (c) 2017 thinQ*
