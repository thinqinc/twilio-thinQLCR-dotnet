﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwilioWithThinQLCR;
using Twilio;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            TwilioWrapper wrapper = new TwilioWrapper("twilio-sid", "twilio-token", "thinq-account-id", "thinq-token");
            CallOptions callOptions = new CallOptions();
            callOptions.To = "19195551234";
            callOptions.From = "19198900000";
            callOptions.Url = "http://twilio.example.com/twilio.xml";

            Call call = wrapper.call(callOptions);
            Console.WriteLine("Call sid: " + call.Sid);
            Console.ReadLine();
        }
    }
}
