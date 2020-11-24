using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Web;

using Natty.Utility.Configurations;

namespace Natty.Utility.Factory {
    public class ServiceFactory
    {
        #region Remoting服务工厂
        private static string strType = string.Empty;
        public static  T CreateService<T> (string url)
        {
            if (!typeof(T).IsInterface)
            {
                throw new NotSupportedException("this T only support interface!");
            }

           T service = (T)Activator.GetObject(
             typeof(T),
             url
            );
           return service;
        }
        #endregion

        #region Wcf服务工厂
        public static T CreateWCFService<T>()
        {
            // Create a channel
            if (!typeof(T).IsInterface)
            {
                throw new NotSupportedException("this T only support interface!");
            }

            ServiceNode node = ServiceProvider.GetServiceNode<T>();
            EndpointAddress address = new EndpointAddress(node.Address);
            Binding binding = CreateBinding(node.Binding);
            ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
            return factory.CreateChannel();
        }

        public static T CreateWCFService<T>(string name)
        {
            // Create a channel
            if (!typeof(T).IsInterface)
            {
                throw new NotSupportedException("this T only support interface!");
            }

            ServiceNode node = ServiceProvider.GetServiceNode<T>(name);
            EndpointAddress address = new EndpointAddress(node.Address);
            Binding binding = CreateBinding(node.Binding);
            ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
            return factory.CreateChannel();
        }
        #endregion

        #region 创建传输协议
        /// <summary>
        /// 创建传输协议
        /// </summary>
        /// <param name="binding">传输协议名称</param>
        /// <returns></returns>
        private static Binding CreateBinding(string binding)
        {
            Binding bindinginstance = null;
            if (binding.ToLower() == "basichttpbinding")
            {
                BasicHttpBinding ws = new BasicHttpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "netnamedpipebinding")
            {
                NetNamedPipeBinding ws = new NetNamedPipeBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "netpeertcpbinding")
            {
                NetPeerTcpBinding ws = new NetPeerTcpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "nettcpbinding")
            {
                NetTcpBinding ws = new NetTcpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                ws.Security.Mode = SecurityMode.None;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "wsdualhttpbinding")
            {
                WSDualHttpBinding ws = new WSDualHttpBinding();
                ws.MaxReceivedMessageSize = 65535000;

                bindinginstance = ws;
            }
            else if (binding.ToLower() == "webhttpbinding")
            {
                WebHttpBinding ws = new WebHttpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "wsfederationhttpbinding")
            {
                WSFederationHttpBinding ws = new WSFederationHttpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "wshttpbinding")
            {
                WSHttpBinding ws = new WSHttpBinding(SecurityMode.None);
                ws.MaxReceivedMessageSize = 65535000;
                ws.Security.Message.ClientCredentialType = System.ServiceModel.MessageCredentialType.Windows;
                ws.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
                ws.ReaderQuotas.MaxStringContentLength = 65535000;
                bindinginstance = ws;
            }
            return bindinginstance;

        }
        #endregion
    }
}
