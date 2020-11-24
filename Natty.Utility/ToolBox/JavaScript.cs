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
    /// javascript ��ժҪ˵��
    /// </summary>
    public sealed class javascript
    {
        #region Member variables
        /// <summary>
        /// ��ʱʱ��
        /// </summary>
        public static readonly int DefaultTimeoutValue = 5000;
        #endregion
        /// <summary>
        /// ���캯��
        /// </summary>
        public javascript()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        #region ��ҳ�����һ��javascript�ű�
        /// <summary>
        /// �ű�����Form�Ŀ�ʼλ��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="key">Ҫע��Ŀͻ��˽ű��ļ�</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
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
        /// �ű�����Form�Ŀ�ʼλ��,key��ͨ��Guid�������һ��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        public static void JsFormHead(Page page, Type type, string script)
        {
            JsFormHead(page, type, Guid.NewGuid().ToString(), script);
        }

        /// <summary>
        /// �ű�����Form�Ľ���λ��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="key">Ҫע��Ŀͻ��˽ű��ļ�</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
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
        /// �ű�����Form�Ľ���λ��,key��ͨ��Guid�������һ��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        public static void JsFormFoot(Page page, Type type, string script)
        {
            JsFormFoot(page, type, Guid.NewGuid().ToString(), script);
        }
        /// <summary>
        /// �ű�����Form�Ľ���λ��,key��ͨ��Guid�������һ��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">λ��:head/foot</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
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

        #region ��ҳ�������һ��js�ļ�
        /// <summary>
        /// ��ҳ�������һ��js�ļ�
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="key">Ҫע��ͻ��˽ű������ļ�</param>
        /// <param name="url">Ҫע��ͻ��˽ű�������url</param>
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
        /// ��ҳ�������һ��js�ļ�
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="key">Ҫע��ͻ��˽ű������ļ�</param>
        /// <param name="url">Ҫע��ͻ��˽ű�������url</param>
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
        /// ��ҳ�������һ��js�ļ�,key��ͨ��Guid�������һ��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="url">Ҫע��ͻ��˽ű�������url</param>
        public static void JsInclude(Page page, string url)
        {
            JsInclude(page, Guid.NewGuid().ToString(), url);
        }
        #endregion

        #region ע��ͻ��˽ű���Դ
        /// <summary>
        /// ע��ͻ��˽ű���Դ
        /// </summary>
        /// <param name="page">ҳ��</param>
        /// <param name="type">System.Web.UI.Page</param>
        /// <param name="resourceName">Ҫע��ͻ��˽ű���Դ������</param>
        public static void JsResource(Page page, Type type, string resourceName)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            clientScript.RegisterClientScriptResource(type, resourceName);
            //clientScript.RegisterHiddenField
        }
        #endregion

        #region ע��һ������ֵ
        /// <summary>
        /// ��System.Web.UI.Page ע��һ������ֵ
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="hiddenFieldName">Ҫע��������ֶε�����</param>
        /// <param name="HiddenFieldInitialValue">Ҫע����ֶεĳ�ʼֵ</param>
        public static void JsHiddenField(Page page, string hiddenFieldName, string HiddenFieldInitialValue)
        {
            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager clientScript = page.ClientScript;
            clientScript.RegisterHiddenField(hiddenFieldName, HiddenFieldInitialValue);
        }
        #endregion

        #region �ڿؼ������js�¼�
        /// <summary>
        /// ��html�ؼ������js�¼�
        /// </summary>
        /// <param name="htmlControl">class System.Web.UI.HtmlControls.HtmlControl</param>
        /// <param name="key">�¼����� ��(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload��)</param>
        /// <param name="value">�¼�(javascript)</param>
        public static void JsAddEvent(HtmlControl htmlControl, string key, string value)
        {
            htmlControl.Attributes.Add(key, value);
        }

        /// <summary>
        /// ��asp.net�ؼ������js�¼�
        /// </summary>
        /// <param name="webControl">class System.Web.UI.HtmlControls.HtmlControl</param>
        /// <param name="key">�¼����� ��(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload��)</param>
        /// <param name="value">�¼�(javascript)</param>
        public static void JsAddEvent(WebControl webControl, string key, string value)
        {
            webControl.Attributes.Add(key, value);
        }
        #endregion

        #region js ����

        #region js ��������
        /// <summary>
        /// js ��������
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js������form��λ��</param>
        /// <param name="Msg">��Ϣ</param>
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
        /// js ��������
        /// </summary>
        /// <param name="Msg">��Ϣ</param>
        public static void JsAlert(string Msg)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "')</script>");
        }
        /// <summary>
        /// js ��������
        /// </summary>
        /// <param name="Msg">��Ϣ</param>
        public static void JsAlertAndBack(string Msg)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "');history.back()</script>");
        }
        /// <summary>
        /// js �������ڲ���ת
        /// </summary>
        /// <param name="Msg">��ʾ��Ϣ</param>
        /// <param name="JumpUrl">��תUrl</param>
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
        /// ת��url������:��
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
        /// js �������ڲ�����
        /// </summary>
        /// <param name="Msg">��ʾ��Ϣ</param>
        /// <param name="BackCount">������</param>
        public static void JsAlert(string Msg, int BackCount)
        {
            HttpContext.Current.Response.Write("<script>alert('" + Msg + "');history.go(" + BackCount + ")</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// js ��������(��form��������)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="Msg">��Ϣ</param>
        public static void JsHeadAlert(Page page, Type type, string Msg)
        {
            string AlertStr = "alert('" + Msg + "');";
            JsFormHead(page, type, AlertStr);
        }

        /// <summary>
        /// js ��������(��form��������)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="Msg">��Ϣ</param>
        public static void JsFootAlert(Page page, Type type, string Msg)
        {
            string AlertStr = "alert('" + Msg + "');";
            JsFormFoot(page, type, AlertStr);
        }
        #endregion

        #region js �����Ի���
        /// <summary>
        /// js �����Ի���
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="Control"></param>
        /// <param name="key">�¼����� ��(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload��)</param>
        /// <param name="Msg">������Ϣ</param>
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
        /// js �����Ի���(html�ؼ�)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="htmlControl"></param>
        /// <param name="key">�¼����� ��(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload��)</param>
        /// <param name="Msg">������Ϣ</param>
        public static void JsHtmlConfirm(Page page, Type type, HtmlControl htmlControl, string key, string Msg)
        {
            string ConfirmStr = "return confirm('" + Msg + "')";
            JsAddEvent(htmlControl, key, ConfirmStr);
        }

        /// <summary>
        /// js �����Ի���(asp.net�ؼ�)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="webControl"></param>
        /// <param name="key">�¼����� ��(onclick,onkeyup,onblur,oninit,onkeydown,onmousedown,onmousemove,onmouseout,onmouseover,onmouseup,onunload��)</param>
        /// <param name="Msg">������Ϣ</param>
        public static void JsWebConfirm(Page page, Type type, WebControl webControl, string key, string Msg)
        {
            string ConfirmStr = "return confirm('" + Msg + "')";
            JsAddEvent(webControl, key, ConfirmStr);
        }
        #endregion

        #region Js���ʱ�䴦��
        /// <summary>
        /// js ���ʱ�䴦��(script������ֱ�ӵ�js,������js�ĺ�����)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        /// <param name="DateTimeValue">���ʱ��ֵ(��1000,2000,3000)</param>
        public static void JsHeadSetTimeout(Page page, Type type, string script, int DateTimeValue)
        {
            string JsBody = "window.setTimeout(\"" + script + "\"," + DateTimeValue.ToString() + ")";
            JsFormHead(page, type, JsBody);
        }

        /// <summary>
        /// js ���ʱ�䴦��(script������ֱ�ӵ�js,������js�ĺ�����)Ĭ�ϼ��ʱ��5��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        public static void JsHeadSetTimeout(Page page, Type type, string script)
        {
            JsHeadSetTimeout(page, type, script, DefaultTimeoutValue);
        }

        /// <summary>
        /// js ���ʱ�䴦��(script������ֱ�ӵ�js,������js�ĺ�����)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        /// <param name="DateTimeValue">���ʱ��ֵ(��1000,2000,3000)</param>
        public static void JsFootSetTimeout(Page page, Type type, string script, int DateTimeValue)
        {
            string JsBody = "window.setTimeout(\"" + script + "\"," + DateTimeValue.ToString() + ")";
            JsFormFoot(page, type, JsBody);
        }

        /// <summary>
        /// js ���ʱ�䴦��(script������ֱ�ӵ�js,������js�ĺ�����)Ĭ�ϼ��ʱ��5��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        public static void JsFootSetTimeout(Page page, Type type, string script)
        {
            JsFootSetTimeout(page, type, script, DefaultTimeoutValue);
        }

        /// <summary>
        /// ���ʱ�䴦��(script������ֱ�ӵ�js,������js�ĺ�����)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js������form��λ��</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        /// <param name="DateTimeValue">���ʱ�䴥��</param>
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
        /// ���ʱ�䴦��(script������ֱ�ӵ�js,������js�ĺ�����)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js������form��λ��</param>
        /// <param name="script">Ҫע��Ŀͻ��˽ű��ı�</param>
        public static void JsSetTimeout(Page page, Type type, string location, string script)
        {
            JsSetTimeout(page, type, location, script, DefaultTimeoutValue);
        }
        #endregion


        #region ��תҳ��
        /// <summary>
        /// ��תҳ��
        /// </summary>      
        /// <param name="Url">��תҳ���ַ</param>     
        public static void Redirect(string Url)
        {
            System.Web.HttpContext.Current.Response.Write("<script>window.location.href='" + Url + "'</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// ˢ�¸�����
        /// </summary>
        public static void ParentReload()
        {
            System.Web.HttpContext.Current.Response.Write("<script>parent.location.reload();</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// ��������ת
        /// </summary>
        /// <param name="Url">��תҳ���ַ</param>
        public static void ParentRedirect(string Url)
        {
            System.Web.HttpContext.Current.Response.Write("<script>parent.location='" + Url + "';</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// ���ʱ����תҳ��
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js������form��λ��</param>
        /// <param name="Url">��תҳ���ַ</param>
        /// <param name="DateTimeValue">���ʱ�䴥��</param>
        public static void JsSetTimeoutRedirect(Page page, Type type, string location, string Url, int DateTimeValue)
        {
            string script = "function UrlHref(){location.href = \"" + Url + "\";}";
            JsForm(page, type, location, script);
            JsSetTimeout(page, type, location, "UrlHref()", DateTimeValue);
        }

        /// <summary>
        /// ���ʱ����תҳ��(Ĭ��ʱ��5��)
        /// </summary>
        /// <param name="page">System.Web.UI.Page</param>
        /// <param name="type">System.Type</param>
        /// <param name="location">js������form��λ��</param>
        /// <param name="Url">��תҳ���ַ</param>
        public static void JsSetTimeoutRedirect(Page page, Type type, string location, string Url)
        {
            JsSetTimeoutRedirect(page, type, location, Url, DefaultTimeoutValue);
        }
        #endregion

        /// <summary>�Ƿ�գ������ߣ���</summary>
        /// <param name="strInput">�����ַ���</param>
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
        /// <summary>�Ƿ����֣������ߣ���</summary>
        /// <param name="strInput">�����ַ���</param>
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
        /// ������Ϣ����ת���µ�URL
        /// </summary>
        /// <param name="message">��Ϣ����</param>
        /// <param name="toURL">���ӵ�ַ</param>
        public static void AlertAndRedirect(string message, string toURL)
        {
            #region
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
            #endregion
        }

        /// <summary>
        /// ��ע�룺�����ߣ���
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
            str = str.Replace("��", "");
            str = str.Replace(";", "");
            str = str.Replace("%20", "");
            str = str.Replace("==", "");
            str = str.Replace("%", "");

            return str;

        }
        #endregion

    }

}
