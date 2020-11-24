using System;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// 配置文件处理
    /// </summary>
    public class WebConfig
    {
        #region 配置文件
        /// <summary>
        /// 设置配置节信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetWebConfig(string key, string value)
        {
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;
            config.Save();
        }
        /// <summary>
        /// 读取配置节信息
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetWebConfig(string key)
        {
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (config.AppSettings.Settings[key] == null)
                return string.Empty;
            else
                return config.AppSettings.Settings[key].Value;

        }
        /// <summary>
        /// 读取配置节信息
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetConnectionStrings(string key)
        {
            return WebConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        #endregion
    }
}
