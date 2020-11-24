using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace WWW58COM.Utility.Configurations{
    public class ConnectionElement : ConfigurationElement {
        /// <summary>
        /// Gets or sets the ip name of the node.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        //[StringValidator(MinLength=1)]
        public string Name {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }


        /// <summary>
        /// Gets or sets the ip providerInvariantName of the node.
        /// </summary>
        [ConfigurationProperty("providerInvariantName", IsRequired = true, IsKey = true)]
        //[StringValidator(MinLength = 1)]
        public string ProviderInvariantName {
            get { return (string)base["providerInvariantName"]; }
            set { base["providerInvariantName"] = value; }
        }


        /// <summary>
        /// Gets or sets the ip connectionString of the node.
        /// </summary>
        [ConfigurationProperty("connectionString", IsRequired = true, IsKey = true)]
       // [StringValidator(MinLength = 1)]
        public string ConnectionString {
            get { return (string)base["connectionString"]; }
            set { base["connectionString"] = value; }
        }

        /// <summary>
        /// Gets or sets the ip useEntityFactory of the node.
        /// </summary>
        [ConfigurationProperty("useEntityFactory", IsRequired = true, IsKey = true)]
        // [StringValidator(MinLength = 1)]
        public bool UseEntityFactory {
            get { return bool.Parse((string)base["useEntityFactory"]); }
            set { base["useEntityFactory"] = value; }
        }

        /// <summary>
        /// Gets or sets the ip enableEntityTracking of the node.
        /// </summary>
        [ConfigurationProperty("enableEntityTracking", IsRequired = true, IsKey = true)]
        // [StringValidator(MinLength = 1)]
        public bool EnableEntityTracking {
            get { return bool.Parse((string)base["enableEntityTracking"]); }
            set { base["enableEntityTracking"] = value; }
        }

    }
}
