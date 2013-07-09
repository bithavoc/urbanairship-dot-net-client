using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace UrbanAirship
{
    /// <summary>
    /// Implements the android Platform operations.
    /// </summary>

    public class GCMPlatform : PlatfromBase
    {
        internal DataContractJsonSerializer payloadSerializer;
        internal GCMPlatform(Client client)
            : base(client)
        {
            payloadSerializer = new DataContractJsonSerializer(typeof(GCMRegistrationPayload));
        }

        protected override void OnRegisterDevice(string token)
        {
            using (HttpWebResponse response = this.Client.HttpPut("/apids/" + token))
            {
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created) // 201 or 200
                {
                    throw new UrbanAirshipException("Unable to register device token");
                }
            }
        }

        protected override void OnRegisterDeviceWithAlias(string token, string alias)
        {
            GCMRegistrationPayload registration = new GCMRegistrationPayload() { DeviceAlias = alias };
            using (HttpWebResponse response = this.Client.HttpPut("/apids/" + token, registration, this.payloadSerializer))
            {
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created) // 201 or 200
                {
                    throw new UrbanAirshipException("Unable to register device token");
                }
            }
        }


        [DataContract]
        public class GCMRegistrationPayload
        {
            /// <summary>
            /// Alias Property.
            /// </summary>
            [DataMember(Name = "alias", EmitDefaultValue = false)]
            public string DeviceAlias { get; set; }

            /// <summary>
            /// Tags Property, not implement on this library
            /// </summary>
            [DataMember(Name = "tags", EmitDefaultValue = false)]
            public string DeviceTags { get; set; }
        }
    }
}
