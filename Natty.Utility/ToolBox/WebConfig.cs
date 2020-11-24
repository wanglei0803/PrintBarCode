using System;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// �����ļ�����
    /// </summary>
    public class WebConfig
    {
        #region �����ļ�
        /// <summary>
        /// �������ý���Ϣ
        /// </summary>
        /// <param name="key">��</param>
        /// <param name="value">ֵ</param>
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
        /// ��ȡ���ý���Ϣ
        /// </summary>
        /// <param name="key">��</param>
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
        /// ��ȡ���ý���Ϣ
        /// </summary>
        /// <param name="key">��</param>
        /// <returns></returns>
        public static string GetConnectionStrings(string key)
        {
            return WebConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        #endregion
    }
}
