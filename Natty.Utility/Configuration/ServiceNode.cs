using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Natty.Utility.Configurations{
    public class ServiceNode : ConfigurationElement {
        /// <summary>
        /// 名称
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        [ConfigurationProperty("address", IsRequired = true)]
        public string Address
        {
            get { return (string)base["address"]; }
            set { base["address"] = value; }
        }

        /// <summary>
        /// 传输协议
        /// </summary>
        [ConfigurationProperty("binding", IsRequired = true)]
        public string Binding
        {
            get { return (string)base["binding"]; }
            set { base["binding"] = value; }
        }

        /// <summary>
        /// 服务契约
        /// </summary>
        [ConfigurationProperty("contract", IsRequired = true)]
        public string Contract
        {
            get { return (string)base["contract"]; }
            set { base["contract"] = value; }
        }
    }
}
