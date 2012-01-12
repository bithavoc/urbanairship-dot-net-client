using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrbanAirship
{
    /// <summary>
    /// Occurs when there is an error interacting with the UrbanAirship API.
    /// </summary>
    [Serializable]
    public class UrbanAirshipException : ApplicationException
    {
        public UrbanAirshipException() { }
        public UrbanAirshipException(string message) : base(message) { }
        public UrbanAirshipException(string message, Exception inner) : base(message, inner) { }
        protected UrbanAirshipException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
