using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Natty.Utility.Configurations {
   public  class ServiceProvidersSection:ConfigurationSection {

        [ConfigurationProperty("providers")]
       public ServiceNodeCollection Providers {
           get { return (ServiceNodeCollection)base["providers"]; }
        }
    }
}
