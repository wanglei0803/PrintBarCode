using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;

namespace WWW58COM.Utility.Configurations {
    public class ConnectionElementCollection:ConfigurationElementCollection {
        /// <summary>
        /// Creates a new <see cref="T:ConfigurationElement"/>.
        /// </summary>
        /// <returns>A new <see cref="T:ConfigurationElement"/>.</returns>
        protected override ConfigurationElement CreateNewElement() {
            return new ConnectionElement();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <param name="element">The <see cref="T:ConfigurationElement"/> to return the key for. </param>
        /// <returns>An <see cref="T:Object"/> that acts as the key for the specified <see cref="T:ConfigurationElement"/>.</returns>
        protected override object GetElementKey(ConfigurationElement element) {
            ConnectionElement se = (ConnectionElement)element;

            return se.Name;
        }

        public ConnectionElement GetElementByKey(string key) {
            IEnumerator ie = this.GetEnumerator();
            while (ie.MoveNext()) {
                ConnectionElement element = (ConnectionElement)ie.Current;
                if (element.Name == key) {
                    return element;
                }
            }
            return null;
        }

    }
}
