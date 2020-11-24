using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// javascript 的摘要说明
    /// </summary>
    public sealed class javascript
    {
        #region Member variables
        /// <summary>
        /// 超时时间
        /// </summary>
        public static readonly int DefaultTimeoutValue = 5000;
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public javascript()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 在页面加入一段javascript脚本
        /// <summary>
        /// 脚本加在Form的开始位置
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="key">要注册的客户端脚本的键</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsFormHead(Page page, Type type, string key, string script)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            if (!clientScript.IsStartupScriptRegistered(type, key))
            {
                clientScript.RegisterClientScriptBlock(type, key, script, true);
            }
        }

        /// <summary>
        /// 脚本加在Form的开始位置,key者通过Guid随机产生一个
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsFormHead(Page page, Type type, string script)
        {
            JsFormHead(page, type, Guid.NewGuid().ToString(), script);
        }

        /// <summary>
        /// 脚本加在Form的结束位置
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="key">要注册的客户端脚本的键</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsFormFoot(Page page, Type type, string key, string script)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            if (!clientScript.IsClientScriptBlockRegistered(type, key))
            {
                clientScript.RegisterStartupScript(type, key, script, true);
            }
        }

        /// <summary>
        /// 脚本加在Form的结束位置,key者通过Guid随机产生一个
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsFormFoot(Page page, Type type, string script)
        {
            JsFormFoot(page, type, Guid.NewGuid().ToString(), script);
        }
        /// <summary>
        /// 脚本加在Form的结束位置,key者通过Guid随机产生一个
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">位置:head/foot</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsForm(Page page, Type type, string location, string script)
        {
            if (!string.IsNullOrEmpty(location))
            {
                if (location.ToLower() == "head")
                {
                    JsFormHead(page, type, script);
                }
                else if (location.ToLower() == "foot")
                {
                    JsFormFoot(page, type, script);
                }
            }
        }
        #endregion

        #region 在页面里加入一个js文件
        /// <summary>
        /// 在页面里加入一个js文件
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="key">要注册客户端脚本包含的键</param>
        /// <param name="url">要注册客户端脚本包含的url</param>
        public static void JsInclude(Page page, Type type, string key, string url)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            if (!clientScript.IsClientScriptIncludeRegistered(type, key))
            {
                clientScript.RegisterClientScriptInclude(type, key, url);
            }
        }

        /// <summary>
        /// 在页面里加入一个js文件
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="key">要注册客户端脚本包含的键</param>
        /// <param name="url">要注册客户端脚本包含的url</param>
        public static void JsInclude(Page page, string key, string url)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            if (!clientScript.IsClientScriptIncludeRegistered(key))
            {
                clientScript.RegisterClientScriptInclude(key, url);
            }
        }

        /// <summary>
        /// 在页面里加入一个js文件,key者通过Guid随机产生一个
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="url">要注册客户端脚本包含的url</param>
        public static void JsInclude(Page page, string url)
        {
            JsInclude(page, Guid.NewGuid().ToString(), url);
        }
        #endregion

        #region 注册客户端脚本资源
        /// <summary>
        /// 注册客户端脚本资源
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="type">System.Web.UI.Page</param>
        /// <param name="resourceName">要注册客户端脚本资源的名称</param>
        public static void JsResource(Page page, Type type, string resourceName)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            clientScript.RegisterClientScriptResource(type, resourceName);
            //clientScript.RegisterHiddenField
        }
        #endregion

        #region 注册一个隐藏值
        /// <summary>
        /// 向System.Web.UI.Page 注册一个隐藏值
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="hiddenFieldName">要注册的隐藏字段的名称</param>
        /// <param name="HiddenFieldInitialValue">要注册的字段的初始值</param>
        public static void JsHiddenField(Page page, string hiddenFieldName, string HiddenFieldInitialValue)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            clientScript.RegisterHiddenField(hiddenFieldName, HiddenFieldInitialValue);
        }
        #endregion

        #region 在控件中添加js事件
        /// <summary>
        /// 在html控件中添加js事件
        /// </summary>
        /// <param name="htmlControl">class System.Web.UI.HtmlControls.HtmlControl</param>
        /// <param name="key">事件名称 如(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload等)</param>
        /// <param name="value">事件(javascript)</param>
        public static void JsAddEvent(HtmlControl htmlControl, string key, string value)
        {
            htmlControl.Attributes.Add(key, value);
        }

        /// <summary>
        /// 在asp.net控件中添加js事件
        /// </summary>
        /// <param name="webControl">class System.Web.UI.HtmlControls.HtmlControl</param>
        /// <param name="key">事件名称 如(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload等)</param>
        /// <param name="value">事件(javascript)</param>
        public static void JsAddEvent(WebControl webControl, string key, string value)
        {
            webControl.Attributes.Add(key, value);
        }
        #endregion

        #region js 函数

        #region js 弹出窗口
        /// <summary>
        /// js 弹出窗口
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js函数在form的位置</param>
        /// <param name="Msg">消息</param>
        public static void JsAlert(Page page, Type type, string location, string Msg)
        {
            if (!string.IsNullOrEmpty(location))
            {
                if (location.ToLower() == "head")
                {
                    JsHeadAlert(page, type, Msg);
                }
                else if (location.ToLower() == "foot")
                {
                    JsFootAlert(page, type, Msg);
                }
            }
        }
        /// <summary>
        /// js 弹出窗口
        /// </summary>
        /// <param name="Msg">信息</param>
        public static void JsAlert(string Msg)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "')</script>");
        }
        /// <summary>
        /// js 弹出窗口
        /// </summary>
        /// <param name="Msg">信息</param>
        public static void JsAlertAndBack(string Msg)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "');history.back()</script>");
        }
        /// <summary>
        /// js 弹出窗口并跳转
        /// </summary>
        /// <param name="Msg">提示信息</param>
        /// <param name="JumpUrl">跳转Url</param>
        public static void JsAlert(string Msg, string JumpUrl)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "');window.location=\"" + JumpUrl + "\"</script>");
            HttpContext.Current.Response.End();
        }
        public static void JsAlert(string Msg, string JumpUrl,bool parentJump)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "');parent.window.location=\"" + JumpUrl + "\"</script>");
            //HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 转向url加入者:王
        /// </summary>
        /// <param name="JumpUrl"></param>
        public static void JsGoUrl(string JumpUrl)
        {
            HttpContext.Current.Response.Write("<script>window.location='" + JumpUrl + "'</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        public static void JsAlertClose(string Msg)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            HttpContext.Current.Response.Write("alert(\"" + Msg + "\");");
            HttpContext.Current.Response.Write("window.close();");
            HttpContext.Current.Response.Write("</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// js 弹出窗口并后退
        /// </summary>
        /// <param name="Msg">提示信息</param>
        /// <param name="BackCount">后退数</param>
        public static void JsAlert(string Msg, int BackCount)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "');history.go(" + BackCount + ")</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// js 弹出窗口(在form的最上面)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="Msg">消息</param>
        public static void JsHeadAlert(Page page, Type type, string Msg)
        {
            string AlertStr = "alert('" + Msg + "');";
            JsFormHead(page, type, AlertStr);
        }

        /// <summary>
        /// js 弹出窗口(在form的最下面)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="Msg">消息</param>
        public static void JsFootAlert(Page page, Type type, string Msg)
        {
            string AlertStr = "alert('" + Msg + "');";
            JsFormFoot(page, type, AlertStr);
        }
        #endregion

        #region js 弹出对话框
        /// <summary>
        /// js 弹出对话框
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="Control"></param>
        /// <param name="key">事件名称 如(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload等)</param>
        /// <param name="Msg">警告消息</param>
        public static void JsConfirm(Page page, Type type, Object Control, string key, string Msg)
        {
            HtmlControl htmlControl = Control as HtmlControl;
            WebControl webControl = Control as WebControl;
            if (htmlControl != null)
            {
                JsHtmlConfirm(page, type, htmlControl, key, Msg);
            }
            else if (webControl != null)
            {
                JsWebConfirm(page, type, webControl, key, Msg);
            }
            else
            {
                JsFootAlert(page, type, "Error");
            }
        }

        public static void JsConfirm(string msg, string yesCommand, string noCommand)
        {
            StringBuilder js = new StringBuilder("<script>");
            js.Append("if(confirm('" + msg + "')){");
            js.Append(yesCommand + ";}");
            js.Append("else{");
            js.Append(noCommand + ";}");
            js.Append("</script>");
            HttpContext.Current.Response.Write(js.ToString());
        }

        /// <summary>
        /// js 弹出对话框(html控件)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="htmlControl"></param>
        /// <param name="key">事件名称 如(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload等)</param>
        /// <param name="Msg">警告消息</param>
        public static void JsHtmlConfirm(Page page, Type type, HtmlControl htmlControl, string key, string Msg)
        {
            string ConfirmStr = "return confirm('" + Msg + "')";
            JsAddEvent(htmlControl, key, ConfirmStr);
        }

        /// <summary>
        /// js 弹出对话框(asp.net控件)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="webControl"></param>
        /// <param name="key">事件名称 如(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload等)</param>
        /// <param name="Msg">警告消息</param>
        public static void JsWebConfirm(Page page, Type type, WebControl webControl, string key, string Msg)
        {
            string ConfirmStr = "return confirm('" + Msg + "')";
            JsAddEvent(webControl, key, ConfirmStr);
        }
        #endregion

        #region Js间隔时间处理
        /// <summary>
        /// js 间隔时间处理(script可以是直接的js,或者是js的函数名)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        /// <param name="DateTimeValue">间隔时间值(如1000,2000,3000)</param>
        public static void JsHeadSetTimeout(Page page, Type type, string script, int DateTimeValue)
        {
            string JsBody = "window.setTimeout(\"" + script + "\"," + DateTimeValue.ToString() + ")";
            JsFormHead(page, type, JsBody);
        }

        /// <summary>
        /// js 间隔时间处理(script可以是直接的js,或者是js的函数名)默认间隔时间5秒
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsHeadSetTimeout(Page page, Type type, string script)
        {
            JsHeadSetTimeout(page, type, script, DefaultTimeoutValue);
        }

        /// <summary>
        /// js 间隔时间处理(script可以是直接的js,或者是js的函数名)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        /// <param name="DateTimeValue">间隔时间值(如1000,2000,3000)</param>
        public static void JsFootSetTimeout(Page page, Type type, string script, int DateTimeValue)
        {
            string JsBody = "window.setTimeout(\"" + script + "\"," + DateTimeValue.ToString() + ")";
            JsFormFoot(page, type, JsBody);
        }

        /// <summary>
        /// js 间隔时间处理(script可以是直接的js,或者是js的函数名)默认间隔时间5秒
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsFootSetTimeout(Page page, Type type, string script)
        {
            JsFootSetTimeout(page, type, script, DefaultTimeoutValue);
        }

        /// <summary>
        /// 间隔时间处理(script可以是直接的js,或者是js的函数名)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js函数在form的位置</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        /// <param name="DateTimeValue">间隔时间触发</param>
        public static void JsSetTimeout(Page page, Type type, string location, string script, int DateTimeValue)
        {
            if (!string.IsNullOrEmpty(location))
            {
                if (location.ToLower() == "head")
                {
                    JsHeadSetTimeout(page, type, script, DateTimeValue);
                }
                else if (location.ToLower() == "foot")
                {
                    JsFootSetTimeout(page, type, script, DateTimeValue);
                }
            }
        }

        /// <summary>
        /// 间隔时间处理(script可以是直接的js,或者是js的函数名)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js函数在form的位置</param>
        /// <param name="script">要注册的客户端脚本文本</param>
        public static void JsSetTimeout(Page page, Type type, string location, string script)
        {
            JsSetTimeout(page, type, location, script, DefaultTimeoutValue);
        }
        #endregion


        #region 跳转页面
        /// <summary>
        /// 跳转页面
        /// </summary>      
        /// <param name="Url">跳转页面地址</param>     
        public static void Redirect(string Url)
        {
            System.Web.HttpContext.Current.Response.Write("<script>window.location.href='" + Url + "'</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void ParentReload()
        {
            System.Web.HttpContext.Current.Response.Write("<script>parent.location.reload();</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 父窗口跳转
        /// </summary>
        /// <param name="Url">跳转页面地址</param>
        public static void ParentRedirect(string Url)
        {
            System.Web.HttpContext.Current.Response.Write("<script>parent.location='" + Url + "';</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 间隔时间跳转页面
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js函数在form的位置</param>
        /// <param name="Url">跳转页面地址</param>
        /// <param name="DateTimeValue">间隔时间触发</param>
        public static void JsSetTimeoutRedirect(Page page, Type type, string location, string Url, int DateTimeValue)
        {
            string script = "function UrlHref(){location.href = \"" + Url + "\";}";
            JsForm(page, type, location, script);
            JsSetTimeout(page, type, location, "UrlHref()", DateTimeValue);
        }

        /// <summary>
        /// 间隔时间跳转页面(默认时间5秒)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js函数在form的位置</param>
        /// <param name="Url">跳转页面地址</param>
        public static void JsSetTimeoutRedirect(Page page, Type type, string location, string Url)
        {
            JsSetTimeoutRedirect(page, type, location, Url, DefaultTimeoutValue);
        }
        #endregion

        /// <summary>是否空，加入者：王</summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>true/false</returns>
        public static bool isBlank(string strInput)
        {
            if (strInput == null || strInput.Trim() == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>是否数字：加入者：王</summary>
        /// <param name="strInput">输入字符串</param>
        /// <returns>true/false</returns>
        public static bool isNumeric(string strInput)
        {

            char[] ca = strInput.ToCharArray();
            bool found = true;
            for (int i = 0; i < ca.Length; i++)
            {
                if ((ca[i] < '0' || ca[i] > '9') && ca[i] != '.')
                {

                    found = false;
                    break;

                };

            };
            return found;

        }
        /// <summary>
        /// 弹出消息框并且转向到新的URL
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="toURL">连接地址</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            #endregion
        }

        /// <summary>
        /// 防注入：加入者：王
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CheckStr(string str)
        {

            str = str.Replace("'", "");
            str = str.Replace("<script", "");
            str = str.Replace("</script>", "");
            str = str.Replace("&", "");
            str = str.Replace(" ", "");
            str = str.Replace("　", "");
            str = str.Replace(";", "");
            str = str.Replace("%20", "");
            str = str.Replace("==", "");
            str = str.Replace("%", "");

            return str;

        }
        #endregion

    }

}
