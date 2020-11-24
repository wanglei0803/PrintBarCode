using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using Microsoft.VisualBasic;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// �ַ�������
    /// </summary>
    public sealed class CharacterHelper
    {
        #region Generate random value
        /// <summary>
        /// Generate random value 
        /// </summary> 
        /// <param name="digit">generate length</param>
        /// <returns></returns>
        public string GenerateCheckCode(int digit)
        {
            int number;
            char code;
            string checkCode = String.Empty;

            System.Random random = new Random();

            for (int i = 0; i < digit; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                {
                    code = (char)('1' + (char)(number % 9));
                    if (code == '8')
                        code = '7';
                }
                else
                {
                    code = (char)('A' + (char)(number % 26));
                    if (code == 'B')
                        code = 'A';
                    if (code == 'O')
                        code = 'P';
                }

                checkCode += code.ToString();
            }

            return checkCode;
        }
        #endregion

        #region �����������
        public static string RandomNumber(int RanLength)
        {
            string RanNum = string.Empty;
            char[] Nums = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Random r = new Random();
            for (int i = 0; i < RanLength; i++)
            {
                RanNum += Nums[r.Next(0, Nums.Length)].ToString();
            }

            return RanNum;
        }
        #endregion

        #region �滻�ַ����г��ֵ��ַ�
        /// <summary>
        /// �滻�ַ����е��ַ�
        /// </summary>
        /// <param name="source">Դ�ַ���</param>
        /// <param name="chars">Ҫ���˵��ַ�</param>
        /// <returns>���˺���ַ���</returns>
        public static string Filter(string source, char[] chars)
        {
            string strCheck = new string(chars);
            char[] charSource = source.ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char c in charSource)
            {
                if (strCheck.IndexOf(c) < 0)
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// �滻�ַ����г��ֵ��ַ�
        /// </summary>
        /// <param name="source">Դ�ַ���</param>
        /// <param name="strs">Ҫ���˵��ַ���</param>
        /// <returns>���˺���ַ���</returns>
        public static string Filter(string source, string[] strs)
        {
            StringBuilder sb = new StringBuilder(source);
            foreach (string str in strs)
            {
                sb = sb.Replace(str, string.Empty);
            }
            return sb.ToString();
        }
        #endregion

        #region = IsNumeric =
        /// <summary>
        /// ���� Boolean ֵָ�����ʽ��ֵ�Ƿ�Ϊ���֡�
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  IsNumeric(expression)
        /// </remarks>
        /// <param name="Str">����������������ʽ��</param>
        /// <returns>���ʽ��ֵ�Ƿ�Ϊ����</returns>
        public static bool IsNumeric(string Str)
        {
            if (string.IsNullOrEmpty(Str) == true)
            {
                return false;
            }

            int result = 0;

            return (int.TryParse(Str, out result));
        }
        #endregion

        #region = Left =
        /// <summary>
        /// ����ָ����Ŀ�Ĵ��ַ��������������ַ���
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Left(string, length)
        /// </remarks>
        /// <param name="s">�ַ������ʽ��������ߵ��ַ������ء���� string �����а��� Null���򷵻� Null��</param>
        /// <param name="n">
        /// ��ֵ���ʽ��ָ��Ҫ���ص��ַ���Ŀ������� 0�������㳤���ַ��� ("")��������ڻ���� string �����е��ַ�������
        /// �򷵻������ַ�����
        /// </param>
        /// <returns>����ָ����Ŀ���ַ���</returns>
        public static string Left(string s, int n)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            else
            {
                return Strings.Left(s, n);
            }
        }
        #endregion

        #region = Right =
        /// <summary>
        /// ���ַ����ұ߷���ָ����Ŀ���ַ���
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Right(string, length)
        /// </remarks>
        /// <param name="s">�ַ������ʽ�������ұߵ��ַ������ء���� string �����а��� Null���򷵻� Null��</param>
        /// <param name="n">
        /// ��ֵ���ʽ��ָ��Ҫ���ص��ַ���Ŀ�����Ϊ 0�������㳤���ַ�����
        /// ����������ڻ���� string �����е������ַ���Ŀ���򷵻������ַ�����
        /// </param>
        /// <returns>����ָ����Ŀ���ַ���</returns>
        public static string Right(string s, int n)
        {
            if (s == "" || s == null)
            {
                return null;
            }

            if (n <= 0 || n > s.Length) return s;

            return s.Substring(s.Length - n);
        }
        #endregion

        #region = Html2Text =
        /// <summary>
        /// HTML2s the text.
        /// </summary>
        /// <param name="strHTML">The STR HTML.</param>
        /// <returns></returns>
        public static string Html2Text(string strHTML)
        {
            strHTML = Regex.Replace(strHTML, @"<br.+>", "\n");
            strHTML = Regex.Replace(strHTML, @"&\s+;", string.Empty);
            //����HTML
            strHTML = RemoveHtml(strHTML);

            return strHTML;
        }

        #endregion

        #region = HtmlEncode =
        /// <summary>
        /// ��������Ԫת�� HTML ��ʽ��
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            if (str == null)
            {
                return string.Empty;
            }

            string chrChang;

            str = HttpUtility.HtmlEncode(str);

            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("&", "&amp;");
            chrChang = ((char)13).ToString();
            str = str.Replace(chrChang, "<br/>");

            chrChang = ((char)34).ToString();
            str = str.Replace(chrChang, "&quot;");

            chrChang = ((char)32).ToString();
            str = str.Replace(chrChang, "&nbsp;");

            chrChang = ((char)10).ToString();
            str = str.Replace(chrChang, string.Empty);

            return str;
        }
        #endregion

        #region = ��ȡ��ҳ���� =
        /// <summary>
        /// ��ȡ��ҳ����
        /// </summary>
        /// <param name="sUrl">һ����׼��URL</param>    
        /// <returns>���ظ���ҳ��HTML����</returns>
        public static string GetWebPage(string sUrl)
        {
            return GetWebPage(sUrl, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sUrl"></param>
        /// <param name="compress"></param>
        /// <returns></returns>
        public static string GetWebPage(string sUrl, bool compress)
        {
            Encoding enc = Encoding.GetEncoding("GB2312");
            return GetWebPage(sUrl, compress, enc);
        }
        /// <summary>
        /// ץȡҳ��
        /// </summary>
        /// <param name="sUrl">URL��ַ</param>
        /// <param name="compress">ѹ��</param>
        /// <param name="enc">����</param>
        /// <returns></returns>
        public static string GetWebPage(string sUrl, bool compress, Encoding enc)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sUrl);
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; Q312461; .NET CLR 1.0.3705)";
                req.Timeout = 5000;
                HttpWebResponse res;
                res = (HttpWebResponse)req.GetResponse();

                if (res.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(res.GetResponseStream(), enc);
                    string sHtml = sr.ReadToEnd();
                    sr.Close();
                    res.Close();

                    if (compress == true)
                    {
                        sHtml = CompressHTML(sHtml);
                    }

                    return sHtml;
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region = ѹ��HTML =
        /// <summary>
        /// ѹ��HTML
        /// </summary>
        /// <param name="sHtml">����</param>
        /// <returns></returns>
        public static string CompressHTML(string sHtml)
        {
            sHtml = Regex.Replace(sHtml, @"<!--\S*?-->", "");

            sHtml = Regex.Replace(sHtml, @"", "");

            sHtml = Regex.Replace(sHtml, " {2,}", " ");
            sHtml = Regex.Replace(sHtml, @"\s{2,}", "\n");
            sHtml = Regex.Replace(sHtml, @">\s+?<", "><");

            return sHtml;
        }
        #endregion

        #region = ��ȡHTML�ؼ���ָ������ =
        /// <summary>
        /// Pickups the HTML control attribute.
        /// </summary>
        /// <param name="HTML">The HTML.</param>
        /// <param name="TagName">Name of the tag.</param>
        /// <param name="AttributeName">Name of the attribute.</param>
        /// <param name="RemoteUri">The remote URI.</param>
        /// <returns></returns>
        public static string[] PickupHTMLControlAttribute(string HTML, string TagName, string AttributeName, Uri RemoteUri)
        {
            Regex re = new Regex("<" + TagName + " .*?" + AttributeName + "=(?<" + AttributeName + ">.+?) .*?>", RegexOptions.IgnoreCase);

            MatchCollection matches = re.Matches(HTML);

            string[] string_array = new string[matches.Count];

            int i = 0;
            foreach (Match match in matches)
            {
                string word = match.Groups["src"].Value.Replace("\"", "").ToLower();

                if (word.StartsWith("http") == true)
                {

                }
                else if (word.StartsWith("/") == true) //root ����
                {
                    word = RemoteUri.ToString().Replace(RemoteUri.AbsolutePath, string.Empty) + word;
                }
                else
                {
                }

                string_array[i] = word;
                i++;
            }

            return string_array;
        }
        #endregion

        #region = GB2Big5 =
        /// <summary>
        /// ����ת��Ϊ����
        /// </summary>       
        /// <param name="gb2312">����</param>
        /// <returns>������Ӧ�ķ����ַ���</returns>
        public static string GB2Big5(string gb2312)
        {
            return Microsoft.VisualBasic.Strings.StrConv(gb2312, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, System.Globalization.CultureInfo.CurrentCulture.LCID);
        }
        #endregion

        #region = �ַ��ض� =
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="text">����</param>
        /// <param name="length">����</param>
        /// <returns></returns>
        public static string Truncate(string text, int length)
        {
            StringBuilder str = new StringBuilder();

            if (length < 1 || string.IsNullOrEmpty(text) == true)
            {
                return text;
            }

            char[] TextDir = RemoveHtml(text).ToCharArray();
            char[] CharDir = text.ToCharArray(); //�ַ���

            int index = 0; //�ַ���Ķ�λ
            int count = 0; //Ŀǰ��λ��
            foreach (char c in TextDir)
            {
                while (c != CharDir[index])
                {
                    str.Append(CharDir[index]);
                    index++;
                    if (CharDir.Length < index) //��ֹ�������
                    {
                        break;
                    }
                }
                count += FindCharWidth(c);

                if (count / 12 > length)
                {
                    str.Append("��");
                    break;
                }
                str.Append(c);

                index++;
                if (CharDir.Length < index) //��ֹ�������
                {
                    break;
                }
            }

            return str.ToString();
        }

        private static int FindCharWidth(char c)
        {
            int[] charcode = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 224, 225, 232, 233, 234, 236, 237, 242, 243, 249, 250, 252, 257, 275, 283, 299, 324, 328, 333, 363, 462, 464, 466, 468, 470, 472, 474, 476, 593, 609, 913, 914, 915, 916, 917, 918, 919, 920, 921, 922, 923, 925, 926, 927, 928, 929, 931, 932, 933, 934, 935, 936, 937, 945, 946, 947, 948, 949, 950, 951, 952, 953, 954, 955, 956, 957, 958, 959, 960, 961, 963, 964, 965, 966, 967, 968, 969, 1025, 1040, 1041, 1042, 1043, 1044, 1045, 1046, 1047, 1048, 1049, 1050, 1051, 1053, 1054, 1055, 1056, 1057, 1058, 1059, 1060, 1061, 1062, 1063, 1066, 1067, 1068, 1069, 1071, 1072, 1073, 1074, 1075, 1076, 1077, 1078, 1079, 1080, 1081, 1082, 1083, 1084, 1085, 1086, 1087, 1088, 1089, 1090, 1091, 1092, 1093, 1094, 1095, 1096, 1097, 1098, 1099, 1100, 1101, 1102, 1103, 1105, 8364, 59335, 59336, 59393, 59394, 59395, 59396, 59397 };
            int[] charlangth = new int[] { 8, 8, 8, 8, 8, 8, 8, 8, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 0, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 5, 5, 5, 5, 5, 3, 3, 8, 8, 8, 8, 8, 5, 5, 5, 3, 8, 8, 8, 8, 5, 3, 8, 8, 8, 8, 8, 8, 8, 8, 9, 8, 7, 8, 7, 8, 9, 9, 8, 9, 9, 9, 8, 9, 9, 7, 7, 8, 8, 8, 9, 9, 9, 8, 8, 5, 8, 5, 5, 8, 8, 3, 8, 8, 8, 8, 5, 8, 8, 8, 8, 5, 8, 7, 8, 8, 8, 7, 9, 7, 8, 7, 8, 7, 11, 8, 9, 9, 8, 8, 9, 9, 9, 7, 8, 8, 9, 9, 9, 9, 8, 8, 10, 7, 8, 8, 5, 8, 8, 5, 8, 5, 8, 5, 8, 8, 8, 8, 7, 8, 8, 8, 7, 5, 5, 7, 8, 5, 8, 8, 9, 9, 8, 8, 8, 5, 9, 8, 5, 8, 8, 8, 5, 7, 7, 7, 7 };

            int asc = (int)c;

            for (int i = 0; i < charcode.Length; i++)
            {
                if (asc == charcode[i])
                {
                    return charlangth[i];
                }
            }

            return 12;
        }
        #endregion

        #region = UBB���봦���� =
        /// <summary>
        /// UBB���봦����
        /// </summary>
        /// <param name="sDetail">�����ַ���</param>
        /// <returns>����ַ���</returns>
        public static string UBBToHTML(string sDetail)
        {
            Regex r;
            Match m;
            #region ����ո�
            r = new Regex("(<.+) (.+>)", RegexOptions.IgnoreCase);

            do
            {
                m = r.Match(sDetail);
                sDetail = r.Replace(sDetail, "$1&nbspII;$2");
            } while (m.Success == true);


            sDetail = sDetail.Replace(" ", "&nbsp;");
            sDetail = sDetail.Replace("&nbspII;", " ");

            //sDetail = sDetail.Replace(" ", "&nbsp;");
            #endregion
            #region ��������
            //sDetail = sDetail.Replace("'", "��");
            #endregion
            #region ����˫����
            //sDetail = sDetail.Replace("\"", "&quot;");
            #endregion
            #region html��Ƿ�
            //sDetail = sDetail.Replace("<", "&lt;");
            //sDetail = sDetail.Replace(">", "&gt;");

            #endregion
            #region ������
            //�����У���ÿ�����е�ǰ���������ȫ�ǿո�
            r = new Regex(@"(\r\n((&nbsp;)|��)+)(?<����>\S+)", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<BR>����" + m.Groups["����"].ToString());
            }
            //�����У���ÿ�����е�ǰ���������ȫ�ǿո�
            sDetail = sDetail.Replace("\r\n", "<BR>");
            #endregion
            #region ��[b][/b]���
            sDetail = Regex.Replace(sDetail, @"\[b\]", "<b>", RegexOptions.IgnoreCase);
            sDetail = Regex.Replace(sDetail, @"\[\/b\]", "</b>", RegexOptions.IgnoreCase);

            //r = new Regex(@"(\[b\])([ \S\t]*?)(\[\/b\])", RegexOptions.IgnoreCase);
            //for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            //{
            //    sDetail = sDetail.Replace(m.Groups[0].ToString(), "<B>" + m.Groups[2].ToString() + "</B>");
            //}
            #endregion
            #region ��[i][/i]���
            r = new Regex(@"(\[i\])([ \S\t]*?)(\[\/i\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<I>" + m.Groups[2].ToString() + "</I>");
            }
            #endregion
            #region ��[u][/u]���
            r = new Regex(@"(\[U\])([ \S\t]*?)(\[\/U\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<U>" + m.Groups[2].ToString() + "</U>");
            }
            #endregion
            #region ��[p][/p]���
            //��[p][/p]���
            r = new Regex(@"((\r\n)*\[p\])(.*?)((\r\n)*\[\/p\])", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<P class=\"pstyle\">" + m.Groups[3].ToString() + "</P>");
            }
            #endregion
            #region ��[sup][/sup]���
            //��[sup][/sup]���
            r = new Regex(@"(\[sup\])([ \S\t]*?)(\[\/sup\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<SUP>" + m.Groups[2].ToString() + "</SUP>");
            }
            #endregion
            #region ��[sub][/sub]���
            //��[sub][/sub]���
            r = new Regex(@"(\[sub\])([ \S\t]*?)(\[\/sub\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<SUB>" + m.Groups[2].ToString() + "</SUB>");
            }
            #endregion
            #region ��[url][/url]���
            //��[url][/url]���
            r = new Regex(@"(\[url\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[2].ToString() + "</A>");
            }
            #endregion
            #region ��[url=xxx][/url]���
            //��[url=xxx][/url]���
            r = new Regex(@"(\[url=([ \S\t]+)\])([ \S\t]*?)(\[\/url\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[3].ToString() + "</A>");
            }
            #endregion
            #region ��[email][/email]���
            //��[email][/email]���
            r = new Regex(@"(\[email\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"mailto:" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[2].ToString() + "</A>");
            }
            #endregion
            #region ��[email=xxx][/email]���
            //��[email=xxx][/email]���
            r = new Regex(@"(\[email=([ \S\t]+)\])([ \S\t]*?)(\[\/email\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"mailto:" + m.Groups[2].ToString() + "\" target=\"_blank\">" +
                 m.Groups[3].ToString() + "</A>");
            }
            #endregion
            #region ��[size=x][/size]���
            //��[size=x][/size]���
            sDetail = Regex.Replace(sDetail, @"\[size=([1-7])\]", "<font size=\"$1\">");
            sDetail = Regex.Replace(sDetail, @"\[\/size\]", "</font>");

            //r = new Regex(@"(\[size=([1-7])\])([ \S\t]*?)(\[\/size\])", RegexOptions.IgnoreCase);
            //for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            //{
            //    sDetail = sDetail.Replace(m.Groups[0].ToString(),
            //     "<font size=" + m.Groups[2].ToString() + ">" +
            //     m.Groups[3].ToString() + "</font>");
            //}
            #endregion
            #region ��[color=x][/color]���
            //��[color=x][/color]���
            sDetail = Regex.Replace(sDetail, @"\[color=([\S]+?)\]", "<font color=\"$1\">");
            sDetail = Regex.Replace(sDetail, @"\[\/color\]", "</font>");
            //r = new Regex(@"(\[color=([\S]+)\])([\S\s]*?)(\[\/color\])", RegexOptions.IgnoreCase);
            //for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            //{
            //    sDetail = sDetail.Replace(m.Groups[0].ToString(),
            //     "<font color=" + m.Groups[2].ToString() + ">" +
            //     m.Groups[3].ToString() + "</font>");
            //}
            #endregion
            #region ��[font=x][/font]���
            //��[font=x][/font]���
            r = new Regex(@"(\[font=([\S]+)\])([ \S\t]*?)(\[\/font\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<font face=" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</font>");
            }
            #endregion
            #region ����ͼƬ����
            //����ͼƬ����
            r = new Regex("\\[picture\\](\\d+?)\\[\\/picture\\]", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<A href=\"ShowImage.aspx?Type=ALL&Action=forumImage&ImageID=" + m.Groups[1].ToString() +
                 "\" target=\"_blank\"><IMG border=0 Title=\"������´��ڲ鿴\" src=\"ShowImage.aspx?Action=forumImage&ImageID=" + m.Groups[1].ToString() +
                 "\"></A>");
            }
            #endregion
            #region ����[align=x][/align]
            //����[align=x][/align]
            r = new Regex(@"(\[align=([\S]+)\])([ \S\t]*?)(\[\/align\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<P align=" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</P>");
            }
            #endregion
            #region ��[H=x][/H]���
            //��[H=x][/H]���
            r = new Regex(@"(\[H=([1-6])\])([ \S\t]*?)(\[\/H\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<H" + m.Groups[2].ToString() + ">" +
                 m.Groups[3].ToString() + "</H" + m.Groups[2].ToString() + ">");
            }
            #endregion
            #region ����[list=x][*][/list]
            //����[list=x][*][/list]
            r = new Regex(@"(\[list(=(A|a|I|i| ))?\]([ \S\t]*)\r\n)((\[\*\]([ \S\t]*\r\n))*?)(\[\/list\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                string strLI = m.Groups[5].ToString();
                Regex rLI = new Regex(@"\[\*\]([ \S\t]*\r\n?)", RegexOptions.IgnoreCase);
                Match mLI;
                for (mLI = rLI.Match(strLI); mLI.Success; mLI = mLI.NextMatch())
                {
                    strLI = strLI.Replace(mLI.Groups[0].ToString(), "<LI>" + mLI.Groups[1]);
                }
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<UL TYPE=\"" + m.Groups[3].ToString() + "\"><B>" + m.Groups[4].ToString() + "</B>" +
                 strLI + "</UL>");
            }

            #endregion
            #region ��[SHADOW=x][/SHADOW]���
            //��[SHADOW=x][/SHADOW]���
            r = new Regex(@"(\[SHADOW=)(\d*?),(\w*?),(\d*?)\]([\S\t]*?)(\[\/SHADOW\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<TABLE WIDTH=" + m.Groups[2].ToString() + "  STYLE=FILTER:SHADOW(COLOR=" + m.Groups[3].ToString() + ", STRENGTH=" + m.Groups[4].ToString() + ")>" +
                 m.Groups[5].ToString() + "</TABLE>");
            }
            #endregion
            #region ��[glow=x][/glow]���
            //��[glow=x][/glow]���
            r = new Regex(@"(\[glow=)(\d*?),(#*\w*?),(\d*?)\]\[([\S\t]*?)\](\[\/glow\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<TABLE WIDTH=" + m.Groups[2].ToString() + "  STYLE=FILTER:GLOW(COLOR=" + m.Groups[3].ToString() + ", STRENGTH=" + m.Groups[4].ToString() + ")>" +
                 m.Groups[5].ToString() + "</TABLE>");
            }
            #endregion
            #region ��[center][/center]���
            r = new Regex(@"(\[center\])([ \S\t]*?)(\[\/center\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<CENTER>" + m.Groups[2].ToString() + "</CENTER>");
            }
            #endregion
            #region ��[IMG][/IMG]���
            r = new Regex(@"(\[IMG\])(http|https|ftp):\/\/([ \S\t]*?)(\[\/IMG\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<br><a onfocus=this.blur() href=" + m.Groups[2].ToString() + "://" + m.Groups[3].ToString() + " target=_blank><IMG SRC=" + m.Groups[2].ToString() + "://" + m.Groups[3].ToString() + " border=0 alt=�������´������ͼƬ onload=javascript:if(screen.width-333<this.width)this.width=screen.width-333></a>");
            }
            #endregion
            #region ��[em]���
            r = new Regex(@"(\[em([\S\t]*?)\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<img src=pic/em" + m.Groups[2].ToString() + ".gif border=0 align=middle>");
            }
            #endregion
            #region ��[flash=x][/flash]���
            //��[mp=x][/mp]���
            r = new Regex(@"(\[flash=)(\d*?),(\d*?)\]\[([\S\t]*?)\](\[\/flash\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<a href=" + m.Groups[4].ToString() + " TARGET=_blank><IMG SRC=pic/swf.gif border=0 alt=������´������͸�FLASH����!> [ȫ������]</a><br><br><OBJECT codeBase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0 classid=clsid:D27CDB6E-AE6D-11cf-96B8-444553540000 width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "><PARAM NAME=movie VALUE=" + m.Groups[4].ToString() + "><PARAM NAME=quality VALUE=high><param name=menu value=false><embed src=" + m.Groups[4].ToString() + " quality=high menu=false pluginspage=http://www.macromedia.com/go/getflashplayer type=application/x-shockwave-flash width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + ">" + m.Groups[4].ToString() + "</embed></OBJECT>");
            }
            #endregion
            #region ��[dir=x][/dir]���
            //��[dir=x][/dir]���
            r = new Regex(@"(\[dir=)(\d*?),(\d*?)\]\[([\S\t]*?)\](\[\/dir\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<object classid=clsid:166B1BCA-3F9C-11CF-8075-444553540000 codebase=http://download.macromedia.com/pub/shockwave/cabs/director/sw.cab#version=7,0,2,0 width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "><param name=src value=" + m.Groups[4].ToString() + "><embed src=" + m.Groups[4].ToString() + " pluginspage=http://www.macromedia.com/shockwave/download/ width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "></embed></object>");
            }
            #endregion
            #region ��[rm=x][/rm]���
            //��[rm=x][/rm]���
            r = new Regex(@"(\[rm=)(\d*?),(\d*?)\]\[([\S\t]*?)\](\[\/rm\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "><PARAM NAME=SRC VALUE=" + m.Groups[4].ToString() + "><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=32 id=video2 width=" + m.Groups[2].ToString() + "><PARAM NAME=SRC VALUE=" + m.Groups[4].ToString() + "><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>");
            }
            #endregion
            #region ��[mp=x][/mp]���
            //��[mp=x][/mp]���
            r = new Regex(@"(\[mp=)(\d*?),(\d*?)\]\[([\S\t]*?)\](\[\/mp\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<object align=middle classid=CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95 class=OBJECT id=MediaPlayer width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + " ><param name=ShowStatusBar value=-1><param name=Filename value=" + m.Groups[4].ToString() + "><embed type=application/x-oleobject codebase=http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701 flename=mp src=" + m.Groups[4].ToString() + "  width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + "></embed></object>");
            }
            #endregion
            #region ��[qt=x][/qt]���
            //��[qt=x][/qt]���
            r = new Regex(@"(\[qt=)(\d*?),(\d*?)\]\[([\S\t]*?)\](\[\/qt\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<embed src=" + m.Groups[4].ToString() + " width=" + m.Groups[2].ToString() + " height=" + m.Groups[3].ToString() + " autoplay=true loop=false controller=true playeveryframe=false cache=false scale=TOFIT bgcolor=#000000 kioskmode=false targetcache=false pluginspage=http://www.apple.com/quicktime/>");
            }
            #endregion
            #region ��[QUOTE][/QUOTE]���
            r = new Regex(@"(\[QUOTE\])\[([ \S\t]*?)\](\[\/QUOTE\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<table cellpadding=0 cellspacing=0 border=1 WIDTH=94% bordercolor=#000000 bgcolor=#F2F8FF align=center  style=FONT-SIZE: 9pt><tr><td  ><table width=100% cellpadding=5 cellspacing=1 border=0><TR><TD >" + m.Groups[2].ToString() + "</table></table><br>");
            }
            #endregion
            #region ��[move][/move]���
            r = new Regex(@"(\[move\])\[([ \S\t]*?)\](\[\/move\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<MARQUEE scrollamount=3>" + m.Groups[2].ToString() + "</MARQUEE>");
            }
            #endregion
            #region ��[FLY][/FLY]���
            r = new Regex(@"(\[FLY\])\[([ \S\t]*?)\](\[\/FLY\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(), "<MARQUEE width=80% behavior=alternate scrollamount=3>" + m.Groups[2].ToString() + "</MARQUEE>");
            }
            #endregion
            #region ��[image][/image]���
            //��[image][/image]���
            r = new Regex(@"(\[image\])\[([ \S\t]*?)\](\[\/image\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<img src=\"" + m.Groups[2].ToString() + "\" border=0 align=middle onload=\"javascript:if(this.width>screen.width-333)this.width=screen.width-333\"><br>");
            }
            #endregion
            #region ��[upload][/upload]���
            //��[upload][/upload]���
            r = new Regex(@"(\[upload\])([ \S\t]*?)(\[\/upload\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<img src=\"" + m.Groups[2].ToString() + "\" border=0 align=middle onload=\"javascript:if(this.width>screen.width-333)this.width=screen.width-333\"><br>");
            }
            #endregion
            #region ��[upload][/upload]���
            //��[upload][/upload]���
            r = new Regex(@"(\[uploadzip\])([ \S\t]*?)(\[\/uploadzip\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<a href=\"" + m.Groups[2].ToString() + "\" border=0 align=middle><img src=\"/images/Fileico/rar.gif\" border=\"0\"></a><br>");
            }
            #endregion

            #region ��[UPLOADpdf][/UPLOADpdf]���
            //��[UPLOADpdf][/UPLOADpdf]���
            r = new Regex(@"(\[UPLOADpdf\])([ \S\t]*?)(\[\/UPLOADpdf\])", RegexOptions.IgnoreCase);
            for (m = r.Match(sDetail); m.Success; m = m.NextMatch())
            {
                sDetail = sDetail.Replace(m.Groups[0].ToString(),
                 "<a href=\"" + m.Groups[2].ToString() + "\" border=0 align=middle><img src=\"/images/Fileico/rar.gif\" border=\"0\"></a><br>");
            }
            #endregion



            return sDetail;
        }
        #endregion

        #region = Replicate =
        /// <summary>
        /// ��ָ���Ĵ����ظ��ַ����ʽ
        /// </summary>
        /// <param name="character">���ַ�������ɵ���ĸ���ֱ��ʽ��</param>
        /// <param name="number">�������������Ϊ�����򷵻ؿ��ַ�����</param>
        /// <returns>���ؾ���ָ�����ȵġ��ظ��ַ���ɵ��ַ�����</returns>
        public static string Replicate(string character, int number)
        {
            if (number < 1)
            {
                return string.Empty;
            }

            StringBuilder str = new StringBuilder(character, number);

            return str.ToString();
        }
        #endregion

        #region = Html =

        #region = Filter HTML =
        /// <summary>
        /// Filters the script.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static string FilterScript(string content)
        {
            if (string.IsNullOrEmpty(content) == true)
            {
                return content;
            }
            string regexstr = @"(?i)<script([^>])*>(\w|\W)*?</script([^>])*>";//@"<script.*</script>";
            content = Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
            content = Regex.Replace(content, "<script([^>])*?>", string.Empty, RegexOptions.IgnoreCase);
            content = Regex.Replace(content, "</script>", string.Empty, RegexOptions.IgnoreCase);

            regexstr = @" href *= *[\s\S]*?script *:.+?""";
            //content = Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);

            regexstr = @" on\w+?="".+?"" ";
            content = Regex.Replace(content, regexstr, " ", RegexOptions.IgnoreCase);

            return content;
        }
        /// <summary>
        /// ����iframe
        /// </summary>
        /// <param name="content">�ַ���</param>
        /// <returns></returns>
        public static string FilterIFrame(string content)
        {
            if (string.IsNullOrEmpty(content) == true)
            {
                return content;
            }
            string regexstr = @"(?i)<iframe([^>])*>(\w|\W)*</iframe([^>])*>";//@"<script.*</script>";
            content = Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
            content = Regex.Replace(content, "<iframe([^>])*>", string.Empty, RegexOptions.IgnoreCase);
            return Regex.Replace(content, "</iframe>", string.Empty, RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// ����frameset
        /// </summary>
        /// <param name="content">�ַ���</param>
        /// <returns></returns>
        public static string FilterFrameset(string content)
        {
            if (string.IsNullOrEmpty(content) == true)
            {
                return content;
            }
            string regexstr = @"(?i)<iframe([^>])*>(\w|\W)*</frameset([^>])*>";//@"<script.*</script>";
            content = Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
            content = Regex.Replace(content, "<frameset([^>])*>", string.Empty, RegexOptions.IgnoreCase);
            return Regex.Replace(content, "</frameset>", string.Empty, RegexOptions.IgnoreCase);
        }
        #endregion

        /// <summary>
        /// Removes the HTML.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public static string RemoveHtml(string html)
        {
            html = Regex.Replace(html, "<br>", " ");
            html = Regex.Replace(html, @"<[\s|\S]+?>", string.Empty);
            html = Regex.Replace(html, "&nbsp;", " ");
            html = Regex.Replace(html, " {2,}", " ");
            html = Regex.Replace(html, @"\s", "");
            return html;
        }
        /// <summary>
        /// �Ƴ�HTML���
        /// </summary>
        /// <param name="content">�ַ���</param>
        /// <param name="tags">�������</param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string content, string[] tags)
        {
            string regexstr1, regexstr2;
            foreach (string tag in tags)
            {
                if (string.IsNullOrEmpty(tag) == false)
                {
                    regexstr1 = string.Format(@"<{0}([^>])*>", tag);
                    regexstr2 = string.Format(@"</{0}([^>])*>", tag);
                    content = Regex.Replace(content, regexstr1, string.Empty, RegexOptions.IgnoreCase);
                    content = Regex.Replace(content, regexstr2, string.Empty, RegexOptions.IgnoreCase);
                }
            }
            return content;

        }
        /// <summary>
        /// �Ƴ�HTML���
        /// </summary>
        /// <param name="content">�ַ���</param>
        /// <param name="tag">���</param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string content, string tag)
        {
            string returnStr;
            string regexstr1 = string.Format(@"<{0}([^>])*>", tag);
            string regexstr2 = string.Format(@"</{0}([^>])*>", tag);
            returnStr = Regex.Replace(content, regexstr1, string.Empty, RegexOptions.IgnoreCase);
            returnStr = Regex.Replace(returnStr, regexstr2, string.Empty, RegexOptions.IgnoreCase);
            return returnStr;

        }

        #endregion

        #region = DecodingBigEndianUnicode =
        /// <summary>
        /// Decodings the big endian unicode.
        /// </summary>
        ///  /// <remarks>
        /// ���������ҳ��JS�ļ��е����ı��������С���� 
        /// http://thinhunan.cnblogs.com/archive/2005/12/27/305590.html
        /// </remarks>
        /// <param name="encodedString">The encoded string.</param>
        /// <returns></returns>
        public static string DecodingBigEndianUnicode(string encodedString)
        {
            Regex regUnicode = new Regex(@"\\u(?<1>[a-zA-Z0-9]{2})(?<2>[a-zA-Z0-9]{2})");
            MatchCollection mc = regUnicode.Matches(encodedString);
            string s = string.Empty;
            foreach (Match m in mc)
            {
                byte b1 = byte.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
                byte b2 = byte.Parse(m.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
                s += Encoding.BigEndianUnicode.GetString(new byte[] { b1, b2 });
            }
            return s;
        }
        #endregion

        #region = EncodingBigEndianUnicode =
        /// <summary>
        /// Encodings the big endian unicode.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <remarks>
        /// ���������ҳ��JS�ļ��е����ı��������С���� 
        /// http://thinhunan.cnblogs.com/archive/2005/12/27/305590.html
        /// </remarks>
        /// <returns></returns>
        public static string EncodingBigEndianUnicode(string text)
        {
            string s = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                string s1 = text.Substring(i, 1);
                byte[] bs = Encoding.BigEndianUnicode.GetBytes(s1);
                s1 = @"\u";
                foreach (byte b in bs)
                {
                    string s2 = b.ToString("x");
                    if (s2.Length == 1)
                        s2 = "0" + s2;
                    s1 += s2;
                }
                s += s1;
            }
            return s;
        }
        #endregion

        #region = ArrayToString =
        
        public static string ArrayToString(ICollection array, string separateChar)
        {
            StringBuilder str = new StringBuilder();
            foreach (object obj in array)
            {
                str.Append(obj);
                str.Append(separateChar);
            }
            return Regex.Replace(str.ToString(), separateChar + "$", string.Empty);
        }

        public static string ArrayToString(ICollection array, string separateChar,int startIndex,int endIndex)
        {
            IList list = (IList)array;
            StringBuilder str = new StringBuilder();
            for (int i = startIndex; i < endIndex && i < array.Count; i++)
            {
                object obj = list[i];
                str.Append(obj);
                str.Append(separateChar);
            }
            return Regex.Replace(str.ToString(), separateChar + "$", string.Empty);
        }

        public static string ArrayToString(ICollection array)
        {
           return ArrayToString(array, ",");
        }
       
        #endregion

        #region �����ֶ�-��ȡ�ַ���
        /// <summary>
        /// �����ֶ�-��ȡ�ַ���
        /// </summary>
        /// <param name="source">�ַ���</param>
        /// <param name="field">�ֶ�</param>
        /// <returns></returns>
        public static string GetSringByField(string source, string field)
        {
            return GetSringByField(source, field, '$');
        }
        /// <summary>
        /// �����ֶ�-��ȡ�ַ���
        /// </summary>
        /// <param name="source">�ַ���</param>
        /// <param name="field">�ַ�</param>
        /// <param name="split">�ָ��</param>
        /// <returns></returns>
        public static string GetSringByField(string source, string field, char split)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            string RV = string.Empty;
            string[] keyAndvalues = source.Split(split);
            foreach (string keyAndvalue in keyAndvalues)
            {
                string[] kv = keyAndvalue.Split('|');
                if (string.Equals(kv[0], field, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (kv.Length > 1)
                        RV = kv[1];
                    break;
                }
            }
            return RV;
        }
        #endregion

        #region ������������ר����������
        public static string ConvertNum(int Num)
        {
            string Result = string.Empty;
            switch (Num)
            { 
                case 1:
                    Result = "һ";
                    break;
                case 2:
                    Result = "��";
                    break;
                case 3:
                    Result = "��";
                    break;
                case 4:
                    Result = "��";
                    break;
                case 5:
                    Result = "��";
                    break;
                case 6:
                    Result = "��";
                    break;
                case 7:
                    Result = "��";
                    break;
                case 8:
                    Result = "��";
                    break;
                case 9:
                    Result = "��";
                    break;
                case 0:
                    Result = "��";
                    break;
                default:
                    Result = "";
                    break;
            }
            return Result;
        }
        #endregion

        #region ����IP���һλ
        public static string ShieldIP(string ip)
        {
            if (string.IsNullOrEmpty(ip))
                return string.Empty;
            string ipReg=@"^(\d+)\.(\d+)\.(\d+)\.(\d+)$";
            if (Regex.IsMatch(ip, ipReg, RegexOptions.IgnoreCase))
                return Regex.Replace(ip, ipReg, "$1.$2.$3.*");
            return ip;
        }
        #endregion

        /// <summary>
        /// �����ַ�������(�����ַ���2)
        /// </summary>
        /// <param name="StrString">������ַ���</param>
        /// <returns>�ַ�����</returns>
        public static Int32 GetLength(String StrString)
        {
            if (StrString.Length != 0)
            {
                Int32 intLen = StrString.Length;
                Char[] chars = StrString.ToCharArray();
                for (Int32 i = 0; i < chars.Length; i++)
                {
                    if (System.Convert.ToInt32(chars[i]) > 255)
                    {
                        intLen++;
                    }
                }
                return intLen;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ת��ǵĺ���(DBC case)
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <returns>����ַ���</returns>
        ///<remarks>
        ///ȫ�ǿո�Ϊ12288����ǿո�Ϊ32
        ///�����ַ����(33-126)��ȫ��(65281-65374)�Ķ�Ӧ��ϵ�ǣ������65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// �õ����׵�Html����
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetSimHtmlCode(string strText)
        {
            if (!string.IsNullOrEmpty(strText))
            {
                strText = strText.Replace(" ", "&nbsp;");
                strText = Regex.Replace(strText, "<.+?>", string.Empty, RegexOptions.IgnoreCase);
                strText = strText.Replace(Convert.ToChar(13).ToString(), "<br>");
            }
            return strText;
        }

        /// <summary>
        /// �õ����׵�Text����
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string GetSimTextCode(string strHtml)
        {
            if (!string.IsNullOrEmpty(strHtml))
            {
                strHtml = strHtml.Replace("&nbsp;", " ");
                strHtml = strHtml.Replace("<br>", Convert.ToChar(13).ToString());
            }
            return strHtml;
        }

        /// <summary>
        /// �õ��������
        /// </summary>
        /// <returns></returns>
        public static string GetRegexGroup(String StrString, String StrRegex, String StrGrouBName)
        {
            Match match = Regex.Match(StrString, StrRegex);
            return match.Groups[StrGrouBName].Value;
        }

        public static System.Collections.Hashtable StringToHashtable(string input, string ParentSplitStr, string ChildSplit)
        {
            System.Collections.Hashtable Result = new System.Collections.Hashtable();
            string[] items = input.Split(new string[] { ParentSplitStr }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                string[] keyValue = item.Split(new string[] { ChildSplit }, StringSplitOptions.None);
                if (!Result.ContainsKey(keyValue[0]))
                {
                    Result.Add(keyValue[0], keyValue.Length > 1 ? keyValue[1] : string.Empty);
                }
            }
            return Result;
        }

        public static string GetTimeStr(DateTime date,string formatString)
        {
            TimeSpan ts = DateTime.Now - date;
            if (ts.TotalDays > 1)
                return date.ToString(formatString);
            else
            {
                if (ts.TotalHours > 1)
                    return Convert.ToInt32(ts.TotalHours).ToString() + "Сʱǰ";
                else if (ts.TotalMinutes > 1)
                    return Convert.ToInt32(ts.TotalMinutes).ToString() + "����ǰ";
                else if (ts.TotalSeconds > 0)
                    return Convert.ToInt32(ts.TotalSeconds).ToString() + "��ǰ";
                else
                    return "1��ǰ";
            }
        }

        public static String ConvertHour2Day(int intHour)
        {
            String str = string.Empty;
            if (intHour >= 24)
            {
                str = Convert.ToString(intHour / 24) + "��";
            }
            if ((intHour % 24 != 0) && (intHour != 0))
            {
                str += Convert.ToString(intHour % 24) + "Сʱ";
            }
            return str;
        }

        /// <summary>
        /// ��ĳ��������ת���С����+��λ �罫100000ת��10+��
        /// </summary>
        /// <param name="num">����</param>
        /// <param name="unit">�Զ���Ϊ�ָ�</param>
        /// <returns>����ת���������</returns>
        public static decimal ConvertUnit(decimal num, int unit)
        {
           
            if (num> (decimal)Math.Pow(10,unit))
                return num / (decimal)Math.Pow(10, unit);
            else
                return num;
        }


    }
}
