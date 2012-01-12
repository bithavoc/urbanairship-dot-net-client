using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanAirship;

namespace UrbanAirshipSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.iOS.RegisterDevice("a19bd7bb7103997d850008744540d0e2f05d51cbf89b03dfbcf3d3d5063e40f2");
            PushNotification notification = client.CreatePush();
            notification.iOS.Alert = "Hello there in something else";
            notification.DeviceTokens.Add("a19bd7bb7103997d850008744540d0e2f05d51cbf89b03dfbcf3d3d5063e40f2");
            notification.Send();
        }
    }
}
