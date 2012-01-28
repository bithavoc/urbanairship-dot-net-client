using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanAirship.Configuration;
using System.Configuration;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

namespace UrbanAirship
{
    /// <summary>
    /// Universal client for UrbanAirship.com
    /// </summary>
    public class Client
    {
        private const string BaseUrl = "https://go.urbanairship.com/api";

        /// <summary>
        /// Creates an instance of the client with the given application key and secret.
        /// </summary>
        /// <param name="appKey">Application Key(master or regular)</param>
        /// <param name="secret">Application Secret</param>
        public Client(string appKey, string secret) : this(new UrbanAirshipSection
            {
                ApplicationKey = appKey,
                ApplicationSecret = secret
            })
        {

        }

        /// <summary>
        /// Creates an instance using the applicationKey and secret specified in the configuration file.
        /// </summary>
        public Client() : this(UrbanAirshipSection.Settings)
        {

        }

        /// <summary>
        /// Creates an instance with the given configuration.
        /// </summary>
        /// <param name="configuration"></param>
        public Client(UrbanAirshipSection configuration)
        {
            this.Configuration = configuration;
            if (this.Configuration == null)
            {
                throw new ArgumentNullException("settings");
            }

            // Initialize iOS Client
            this.iOS = new iOSPlatform(this);
        }

        /// <summary>
        /// iOS Platform operations.
        /// </summary>
        public iOSPlatform iOS { get; private set; }

        /// <summary>
        /// Configurations for this Client.
        /// </summary>
        public UrbanAirshipSection Configuration { get; private set; }

        internal HttpWebResponse HttpPut(string resource)
        {
            return HttpPut(resource, null, null);
        }
        internal HttpWebResponse HttpPut(string resource, object jsonPayload, DataContractJsonSerializer payloadSerializer)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(BaseUrl + resource));
            request.Credentials = new NetworkCredential(this.Configuration.ApplicationKey, this.Configuration.ApplicationSecret);
            request.Method = "PUT";
            if (jsonPayload != null)
            {
                request.ContentType = "application/json; charset=utf-8";
                payloadSerializer.WriteObject(request.GetRequestStream(), jsonPayload);
            }
            else
            {
                request.ContentLength = 0;
            }
            return (HttpWebResponse)request.GetResponse();
        }

        internal HttpWebResponse HttpPost(string resource, object jsonPayload, DataContractJsonSerializer payloadSerializer)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(BaseUrl + resource));
            request.Credentials = new NetworkCredential(this.Configuration.ApplicationKey, this.Configuration.ApplicationSecret);
            request.Method = "POST";
            if (jsonPayload != null)
            {
                request.ContentType = "application/json; charset=utf-8";
                payloadSerializer.WriteObject(request.GetRequestStream(), jsonPayload);
            }
            else
            {
                request.ContentLength = 0;
            }
            return (HttpWebResponse)request.GetResponse();
        }

        /// <summary>
        /// Creates a new Instance of <see cref="PushNotification"/>. See <see cref="PushNotification.Send"/>
        /// </summary>
        /// <returns>Returns an instance of <see cref="PushNotification"/></returns>
        public PushNotification CreatePush()
        {
            return CreatePush<PushNotification>();
        }

        /// <summary>
        /// Create a new Instance of <paramref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="PushNotification"/></typeparam>
        /// <returns>Returns an instance of <paramref name="T"/> ready to be sent</returns>
        public T CreatePush<T>() where T : PushNotification, new()
        {
            T push = new T();
            push.Client = this;

            // Intialize the JSON Serializer for Push Messages
            push.serializer = new DataContractJsonSerializer(typeof(T));

            return push;
        }
    }
}
