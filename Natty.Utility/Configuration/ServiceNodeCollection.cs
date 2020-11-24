using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;

namespace Natty.Utility.Configurations {
    public class ServiceNodeCollection:ConfigurationElementCollection {

        protected override ConfigurationElement CreateNewElement() {
            return new ServiceNode();
        }


        protected override object GetElementKey(ConfigurationElement element) {
            ServiceNode node = (ServiceNode)element;

            return node.Name;
        }

        public ServiceNode GetElementByName(string name) {
            IEnumerator ie = this.GetEnumerator();
            while (ie.MoveNext()) {
                ServiceNode element = (ServiceNode)ie.Current;
                if (element.Name == name)
                {
                    return element;
                }
            }
            return null;
        }

        public ServiceNode GetElement<T>()
        {
            IEnumerator ie = this.GetEnumerator();
            while (ie.MoveNext())
            {
                ServiceNode node = (ServiceNode)ie.Current;
                Type type = typeof(T);
                if (node.Contract.EndsWith(type.Name))
                {
                    return node;
                }
            }
            return null;
        }

    }
}
