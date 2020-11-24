using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
namespace WWW58COM.Utility.Configurations {
    public  class ConnectionProvider {
        private  ConnectionElement current = null;
        private  ConnectionElement _default = null;

        private static ConnectionProvider instance = null;

        public static ConnectionProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConnectionProvider();
                }
                return instance;
            }
        }


        public  ConnectionElement Current {
            get {
                if (current == null) {
                    ConnectionProvidersSection serviceproviders = System.Configuration.ConfigurationManager.GetSection("ConnectionProviders") as ConnectionProvidersSection;
                    current = serviceproviders.Providers.GetElementByKey(serviceproviders.DefaultProvider);
                }
                return current;
            }
        }

        public  ConnectionElement Default {
            get {
                if (_default == null) {
                    ConnectionProvidersSection serviceproviders = System.Configuration.ConfigurationManager.GetSection("ConnectionProviders") as ConnectionProvidersSection;
                    _default = serviceproviders.Providers.GetElementByKey(serviceproviders.DefaultProvider);
                }
                return _default;
            }
        }

        public  ConnectionElement GetConnection(string key) {
            ConnectionProvidersSection serviceproviders = System.Configuration.ConfigurationManager.GetSection("ConnectionProviders") as ConnectionProvidersSection;
            return  serviceproviders.Providers.GetElementByKey(key);
        }

        public  void Change(string key) {
            ConnectionProvidersSection serviceproviders = System.Configuration.ConfigurationManager.GetSection("ConnectionProviders") as ConnectionProvidersSection;
            current = serviceproviders.Providers.GetElementByKey(key);
        }
    }
}
