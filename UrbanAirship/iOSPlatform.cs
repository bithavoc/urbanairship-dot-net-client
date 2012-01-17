using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace UrbanAirship
{
    /// <summary>
    /// Implements the iOS Platform operations.
    /// </summary>
    public class iOSPlatform : PlatfromBase
    {
        internal iOSPlatform(Client client) :  base(client)
        {

        }
        protected override void OnRegisterDevice(string token)
        {
            using (HttpWebResponse response = this.Client.HttpPut("/device_tokens/" + token))
            {
                if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created) // 201 or 200
                {
                    throw new UrbanAirshipException("Unable to register device token");
                }
            }
        }
    }
}
