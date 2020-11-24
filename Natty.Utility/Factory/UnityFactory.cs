using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Utility;
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.Unity.Configuration;

namespace Natty.Utility.Factory
{
    public static class UnityFactory
    {

        private static IUnityContainer cantainer = new UnityContainer();

        static UnityFactory()
        {
            RegisterContainer("DAL");
        }

        public static void RegisterContainer(string containername)
        {
            //加载unity配置文件
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            string dependencyFile= ConfigurationManager.AppSettings["unityconfig"];
            map.ExeConfigFilename = dependencyFile;
            if (!System.IO.File.Exists(map.ExeConfigFilename))
            {
                string basepath = System.AppDomain.CurrentDomain.BaseDirectory;
                if (basepath.Substring(basepath.Length - 1) == "\\")
                {
                    basepath = basepath.Substring(0, basepath.Length - 1);
                }
                map.ExeConfigFilename = basepath + "\\" + dependencyFile;
                if (!System.IO.File.Exists(map.ExeConfigFilename))
                {
                    throw new Exception("找不到系统配置文件:" + dependencyFile + "!");
                }
            }
            System.Configuration.Configuration config
              = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            UnityConfigurationSection section
              = (UnityConfigurationSection)config.GetSection("unity");

            section.Containers[containername].Configure(cantainer);
        }

        public static T Reslove<T>()
        {
            return cantainer.Resolve<T>();
        }

        public static T Reslove<T>(string name)
        {
            return cantainer.Resolve<T>(name);
        }

    }
}
