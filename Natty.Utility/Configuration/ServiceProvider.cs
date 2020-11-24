using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Threading;
namespace Natty.Utility.Configurations {
    public static  class ServiceProvider {

        static ServiceProvidersSection serviceproviders = null;
        public static ServiceNode GetServiceNode<T>()
        {
            if (serviceproviders == null)
            {
                serviceproviders = System.Configuration.ConfigurationManager.GetSection("Services") as ServiceProvidersSection;
            }
            
            return serviceproviders.Providers.GetElement<T>();
        }

        public static ServiceNode GetServiceNode<T>(string name)
        {
            if (serviceproviders == null)
            {
                serviceproviders = System.Configuration.ConfigurationManager.GetSection("Services") as ServiceProvidersSection;
            }

            return serviceproviders.Providers.GetElementByName(name);
        }
 
    }
}
