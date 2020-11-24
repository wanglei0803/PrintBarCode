using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace WWW58COM.Utility.Configurations {
   public  class ConnectionProvidersSection:ConfigurationSection {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        [ConfigurationProperty("providers")]
       public ConnectionElementCollection Providers {
           get { return (ConnectionElementCollection)base["providers"]; }
        }

        /// <summary>
        /// Gets or sets the default provider.
        /// </summary>
        /// <value>The default provider.</value>
        [StringValidator(MinLength = 1)]
        [ConfigurationProperty("defaultProvider", DefaultValue = "SqlNetTiersProvider")]
        public string DefaultProvider {
            get { return (string)base["defaultProvider"]; }
            set { base["defaultProvider"] = value; }
        }
    }
}
