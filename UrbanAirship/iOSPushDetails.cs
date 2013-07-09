using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UrbanAirship
{
    /// <summary>
    /// iOS Push root payload.
    /// </summary>
    [DataContract]
    public sealed class iOSPushDetails
    {
        internal iOSPushDetails()
        {
            NotificationMetaData = new Extensibility.JsonDictionary<string, object>();
        }

        /// <summary>
        /// Alert Message to be sent.
        /// </summary>
        [DataMember(Name = "alert", IsRequired = true)]
        public string Alert { get; set; }

        /// <summary>
        /// Number to show in the application icon.
        /// </summary>
        [DataMember(Name = "badge", IsRequired = false, EmitDefaultValue = false)]
        public int Badge { get; set; }

        /// <summary>
        /// Sound file name inside the iOS App Bundle.
        /// </summary>
        [DataMember(Name="sound", IsRequired= false, EmitDefaultValue = false)]
        public string Sound { get; set; }

        /// <summary>
        /// iOS extra , used for passing Meta data with the push
        /// </summary>
        [DataMember(Name = "ex", IsRequired = false, EmitDefaultValue = false)]
        public Extensibility.JsonDictionary<string, object> NotificationMetaData { get; set; }
    }
}
