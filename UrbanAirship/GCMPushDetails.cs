using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UrbanAirship
{
    /// <summary>
    /// google GCM Push root payload.
    /// </summary>
    [DataContract]
    public sealed class GCMPushDetails
    {
        internal GCMPushDetails()
        {
            Extras = new Extensibility.JsonDictionary<string, string>();
        }

        /// <summary>
        /// Alert Message to be sent.
        /// </summary>
        [DataMember(Name = "alert", IsRequired = true)]
        public string Alert { get; set; }

        /// <summary>
        /// Contains one or more keyvalue pairs along with the push payload.
        /// </summary>
        [DataMember(Name = "extra", IsRequired = false, EmitDefaultValue = false)]
        public Extensibility.JsonDictionary<string, string> Extras { get; set; }
    }
}
