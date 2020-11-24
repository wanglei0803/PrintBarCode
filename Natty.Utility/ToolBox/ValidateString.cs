using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Natty.Utility.ToolBox
{
    public class ValidateString
    {
        /// <summary>
        ///SQL注入过滤
        /// </summary>
        /// <param name="InText">要过滤的字符串</param>
        /// <returns>如果参数存在不安全字符，则返回true</returns>
        public static string SqlFilter(string InText)
        {
            if (InText == null) { return null; }
            //string word = "(insert)|(select)|(delete)|(update)|(or)|(exec)|(chr)|(master)|(truncate)|(char)|(declare)|(join)";
            string word = "(insert)|(select)|(delete)|(update)|(exec)|(chr)|(master)|(truncate)|(char)|(declare)|(join)";
            if (InText != null)
            {
                InText = Regex.Replace(InText, "'", "''");
                foreach (string i in word.Split('|'))
                {
                    if (Regex.IsMatch(InText, i, RegexOptions.IgnoreCase))
                    {
                        InText =  Regex.Replace(InText, i, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    }
                }
            }
            return InText;
        }
        /// <summary>
        /// 输入文字过滤
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToInsertText(string text)
        {
            if (text == null) { return null; }
            string tmp = text;
            if (text != "")
            {
                tmp = Regex.Replace(tmp, "<span.*?>((\n|\r|.)*?)<\\/span>", "");
                tmp = Regex.Replace(tmp, "<script.*?>((\n|\r|.)*?)<\\/script>", "");
                tmp = Regex.Replace(tmp, "<iframe.*?>((\n|\r|.)*?)<\\/iframe>", "");
                tmp = Regex.Replace(tmp, "<textarea.*?>((\n|\r|.)*?)<\\/textarea>", "");
                tmp = Regex.Replace(tmp, "<form.*?>((\n|\r|.)*?)<\\/form>", "");
                tmp = Regex.Replace(tmp, "<input[^>]*>", "");
                tmp = Regex.Replace(tmp, "<INPUT[^>]*>", "");
                tmp = Regex.Replace(tmp, "<[^>]*>", "{}");
                //空格
                //tmp = System.Text.RegularExpressions.Regex.Replace(tmp, "\\s|&nbsp;", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Multiline);
            }
            return tmp;
        }

        public static string matchValue(string sContent, string sPattern, string sValueName)
        {
            Regex r = new Regex(sPattern, RegexOptions.IgnoreCase);
            Match m = r.Match(sContent);
            string sContentTemp = string.Empty;
            if (m.Success)
            {
                sContentTemp = m.Groups[sValueName].ToString();
            }
            return sContentTemp;
        }

        #region 全局过滤字符串

        public static string FilterValue(string sContent)
        {
            string tmp = sContent;
            tmp = SqlFilter(tmp);
            tmp = ToInsertText(tmp);
            return tmp;
        }


        /// <summary> 
        /// 验证是否存在注入代码 
        /// </summary> 
        /// <param name="inputData"></param> 
        /// <returns></returns> 
        public static bool ValidData(string inputData)
        {
            //验证inputData是否包含恶意集合
            if (inputData != FilterValue(inputData))
            {
                //HttpContext.Current.Response.Write(inputData + "<br />");
                //HttpContext.Current.Response.Write(FilterValue(inputData) + "<br />");
                return true;
            }
            else
            {
                return false;
            }
        }




        #endregion

    }
}
