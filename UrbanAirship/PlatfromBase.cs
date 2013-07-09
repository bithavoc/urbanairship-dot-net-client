using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace UrbanAirship
{
    /// <summary>
    /// Base for all the standard operations in all the supported platforms by UrbanAirship.
    /// </summary>
    public abstract class PlatfromBase
    {
        protected Client Client{ get; private set;}

        protected internal PlatfromBase(Client client)
        {
            this.Client = client;
        }

        /// <summary>
        /// Register a device token.
        /// </summary>
        /// <param name="token">Device token(iOS Device Token, Android APID, etc)</param>
        public void RegisterDevice(string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            this.OnRegisterDevice(token);
        }


        /// <summary>
        /// Register a device token.
        /// </summary>
        /// <param name="token">Device token(iOS Device Token, Android APID, etc)</param>
        public void RegisterDevice(string token, string alias)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }
            if (String.IsNullOrEmpty(alias))
            {
                throw new ArgumentNullException("Alias");
            }
            this.OnRegisterDeviceWithAlias(token, alias);
        }
        protected abstract void OnRegisterDevice(string token);
        protected abstract void OnRegisterDeviceWithAlias(string token, string alias);
    }
}
