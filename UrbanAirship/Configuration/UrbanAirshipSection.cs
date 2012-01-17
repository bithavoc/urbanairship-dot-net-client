using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UrbanAirship.Configuration
{
    public class UrbanAirshipSection : ConfigurationSection
    {
        public const string ApplicationKeyKey = "applicationKey";
        public const string ApplicationSecretKey = "applicationSecret";
        public const string SectionName = "UrbanAirship";

        public static UrbanAirshipSection Settings
        {
            get
            {
                return ConfigurationManager.GetSection(SectionName) as UrbanAirshipSection;
            }
        }

        [ConfigurationProperty(ApplicationKeyKey, IsRequired = true)]
        public string ApplicationKey
        {
            get { return (string)this[ApplicationKeyKey]; }
            set { this[ApplicationKeyKey] = value; }
        }

        [ConfigurationProperty(ApplicationSecretKey, IsRequired = true)]
        public string ApplicationSecret
        {
            get { return (string)this[ApplicationSecretKey]; }
            set { this[ApplicationSecretKey] = value; }
        }
    }
}
