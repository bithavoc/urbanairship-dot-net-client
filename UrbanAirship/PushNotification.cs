using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;
using System.Runtime.Serialization.Json;
namespace UrbanAirship
{
    /// <summary>
    /// Push Notification Information.
    /// </summary>
    [DataContract]
    public class PushNotification
    {
        internal DataContractJsonSerializer serializer;

        public PushNotification() {
            //iOS properties
            this.DeviceTokens = new List<string>();
            this.iOS = new iOSPushDetails();

            //GCM Properties
            this.GoogleApids = new List<string>();
            this.GoogleGCMDetails = new GCMPushDetails();
        }

        /// <summary>
        /// Client instance to be used as the transport of the notification.
        /// </summary>
        [IgnoreDataMember]
        public Client Client { get; internal set; }

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
        /// Google GCM (google cloud messaging) apids (device ids).
        /// </summary>
        [DataMember(Name = "apids", EmitDefaultValue = false)]
        public List<string> GoogleApids { get; set; }

        /// <summary>
        /// Google GCM (google cloud messaging) Notification Details.
        /// </summary>
        [DataMember(Name = "android", EmitDefaultValue = false)]
        public GCMPushDetails GoogleGCMDetails { get; set; }

        /// <summary>
        /// Urban Airship registered Aliases.
        /// </summary>
        [DataMember(Name = "aliases", EmitDefaultValue = false)]
        public List<string> Aliases { get; set; }

        /// <summary>
        /// Sends the notification to all the devices.
        /// </summary>
        public void Send()
        {
            if (this.Client == null)
            {
                throw new UrbanAirshipException("Can not set a notification without a client");
            }
            using (HttpWebResponse response = this.Client.HttpPost("/push/", this, this.serializer))
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new UrbanAirshipException("An error occurred while sending the push");
                }
            }
        }


        /// <summary>
        /// Reset unused properties to null so they don't get serialized as empty objects
        /// </summary>
        private void PreparePayload()
        {
            if (this.DeviceTokens != null && this.DeviceTokens.Count == 0)
                this.DeviceTokens = null;
            if (this.iOS != null && String.IsNullOrEmpty(this.iOS.Alert))
                this.iOS = null;

            if (this.GoogleApids != null && this.GoogleApids.Count == 0)
                this.GoogleApids = null;
            if (GoogleGCMDetails != null && String.IsNullOrEmpty(GoogleGCMDetails.Alert))
                GoogleGCMDetails = null;
        }
    }
}
