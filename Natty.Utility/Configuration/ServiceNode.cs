using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Natty.Utility.Configurations{
    public class ServiceNode : ConfigurationElement {
        /// <summary>
        /// ����
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        /// <summary>
        /// ��ַ
        /// </summary>
        [ConfigurationProperty("address", IsRequired = true)]
        public string Address
        {
            get { return (string)base["address"]; }
            set { base["address"] = value; }
        }

        /// <summary>
        /// ����Э��
        /// </summary>
        [ConfigurationProperty("binding", IsRequired = true)]
        public string Binding
        {
            get { return (string)base["binding"]; }
            set { base["binding"] = value; }
        }

        /// <summary>
        /// ������Լ
        /// </summary>
        [ConfigurationProperty("contract", IsRequired = true)]
        public string Contract
        {
            get { return (string)base["contract"]; }
            set { base["contract"] = value; }
        }
    }
}
