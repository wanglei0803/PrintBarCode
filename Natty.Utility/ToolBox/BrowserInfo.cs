using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace Natty.Utility.ToolBox
{
    #region BrowserInfo
    /// <summary>
    /// 浏览器信息
    /// </summary>
    public class BrowserInfo
    {

        private HttpContext _context;

        /// <summary>
        /// Gets the browser.
        /// </summary>
        /// <value>The browser.</value>
        public string Browser
        {
            get
            {
                try
                {
                    string strResult = _context.Request.UserAgent;
                    return GetBrowser(strResult);
                }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Gets the OS.
        /// </summary>
        /// <value>The OS.</value>
        public string OS
        {
            get
            {
                try
                {

                    string strResult = _context.Request.UserAgent;
                    return GetOS(strResult);
                }
                catch
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Gets the IP.
        /// </summary>
        /// <value>The IP.</value>
        public string IP
        {
            get
            {
                string result = string.Empty;
                if (_context == null) return result;

                result = _context.Request.ServerVariables["REMOTE_ADDR"];
                if (string.IsNullOrEmpty(result) == true)
                    result = _context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                return result;
            }
        }

        /// <summary>
        /// Gets the referrer.
        /// </summary>
        /// <value>The referrer.</value>
        public Uri Referrer
        {
            get
            {
                return _context.Request.UrlReferrer;
            }
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {
            get
            {
                return (_context.Request.IsAuthenticated) ? _context.User.Identity.Name : "";
            }
        }

        /// <summary>
        /// Gets the site root.
        /// </summary>
        /// <value>The site root.</value>
        public string SiteRoot
        {
            get
            {
                string Port = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                if (Port == null || Port == "80" || Port == "443")
                    Port = "";
                else
                    Port = ":" + Port;

                string Protocol = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (Protocol == null || Protocol == "0")
                    Protocol = "http://";
                else
                    Protocol = "https://";

                string sOut = Protocol + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + Port + System.Web.HttpContext.Current.Request.ApplicationPath;
                sOut = Regex.Replace(sOut, "/$", string.Empty);
                return sOut;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BrowserInfo"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BrowserInfo(HttpContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 浏览器信息
        /// </summary>
        public BrowserInfo()
        {
            this._context = HttpContext.Current;
        }



        /// <summary>
        /// Gets the OS.
        /// </summary>
        /// <param name="strPara">The STR para.</param>
        /// <returns></returns>
        private string GetOS(string strPara)
        {
            string GetInfo = string.Empty;

            if (strPara.IndexOf("NT 5.1") > 0)
            {
                GetInfo = "Windows XP";
            }
            else if (strPara.IndexOf("Tel") > 0)
            {
                GetInfo = "Telport";
            }
            else if (strPara.IndexOf("webzip") > 0)
            {
                GetInfo = "webzip";
            }
            else if (strPara.IndexOf("flashget") > 0)
            {
                GetInfo = "flashget";
            }
            else if (strPara.IndexOf("offline") > 0)
            {
                GetInfo = "offline";
            }
            else if (strPara.IndexOf("NT 5") > 0)
            {
                GetInfo = "Windows 2000";
            }
            else if (strPara.IndexOf("NT 4") > 0)
            {
                GetInfo = "Windows NT4";
            }
            else if (strPara.IndexOf("98") > 0)
            {
                GetInfo = "Windows 98";
            }
            else if (strPara.IndexOf("95") > 0)
            {
                GetInfo = "Windows 95";
            }
            else
            {
                GetInfo = strPara;
            }

            return GetInfo;

        }

        /// <summary>
        /// Gets the browser.
        /// </summary>
        /// <param name="strPara">The STR para.</param>
        /// <returns></returns>
        private string GetBrowser(string strPara)
        {
            //strPara = strPara.Replace(".0", ".x");
            //return strPara;
            string GetInfo = string.Empty;
            if (strPara.IndexOf("NetCaptor 6.5.0") > 0)
            {
                GetInfo = "NetCaptor 6.5.0";
            }
            else if (strPara.IndexOf("MyIE") > 0)
            {
                GetInfo = "MyIE";
            }
            else if (strPara.IndexOf("NetCaptor 6.5.0RC1") > 0)
            {
                GetInfo = "NetCaptor 6.5.0RC1";
            }
            else if (strPara.IndexOf("NetCaptor 6.5.PB1") > 0)
            {
                GetInfo = "NetCaptor 6.5.PB1";
            }
            else if (strPara.IndexOf("MSIE 6.0b") > 0)
            {
                GetInfo = "Internet Explorer 6.0b";
            }
            else if (strPara.IndexOf("MSIE 6.0") > 0)
            {
                GetInfo = "Internet Explorer 6.0";
            }
            else if (strPara.IndexOf("MSIE 5.5") > 0)
            {
                GetInfo = "Internet Explorer 5.5";
            }
            else if (strPara.IndexOf("MSIE 5.01") > 0)
            {
                GetInfo = "Internet Explorer 5.01";
            }
            else if (strPara.IndexOf("MSIE 5.0") > 0)
            {
                GetInfo = "Internet Explorer 5.0";
            }
            else if (strPara.IndexOf("MSIE 4.0") > 0)
            {
                GetInfo = "Internet Explorer 4.0";
            }
            else
            {
                GetInfo = strPara;
            }

            return GetInfo;
        }

        /// <summary>
        /// 获取头信息
        /// </summary>
        /// <param name="Key">信息头</param>
        /// <returns>头信息</returns>
        public string GetHttpHeader(string Key)
        {
            return _context.Request.ServerVariables[Key];
        }
    }
    #endregion
}
