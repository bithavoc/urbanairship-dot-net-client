using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;

namespace UrbanAirship
{
    /// <summary>
    /// Push Notification Information.
    /// </summary>
    [DataContract]
    public class PushNotification
    {
        public PushNotification(Client client) {
            this.Client = client;
            this.DeviceTokens = new List<string>();
            this.iOS = new iOSPushDetails();
        }

        /// <summary>
        /// Client instance to be used as the transport of the notification.
        /// </summary>
        [IgnoreDataMember]
        public Client Client { get; private set; }

        /// <summary>
        /// All iOS Device Tokens to Send the Notification.
        /// </summary>
        [DataMember(Name="device_tokens")]
        public List<string> DeviceTokens { get; private set; }

        /// <summary>
        /// iOS Notification Details.
        /// </summary>
        [DataMember(Name = "aps")]
        public iOSPushDetails iOS { get; set; }

        /// <summary>
        /// Sends the notification to all the devices.
        /// </summary>
        public void Send()
        {
            using (HttpWebResponse response = this.Client.HttpPost("/push/", this))
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new UrbanAirshipException("An error occurred while sending the push");
                }
            }
        }
    }
}
