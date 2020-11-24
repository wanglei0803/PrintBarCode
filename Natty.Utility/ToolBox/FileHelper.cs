using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// file helper class
    /// </summary>
    public class FileHelper
    {
        #region - ReadText -
        /// <summary>
        /// Read file content
        /// </summary>
        /// <param name="FileName_FullPath">file name</param>
        /// <param name="encode">encode</param>
        /// <returns></returns>
        public static string ReadText(string FileName_FullPath, Encoding encode)
        {
            FileInfo fi = new FileInfo(FileName_FullPath);
            StringBuilder str = new StringBuilder();

            if (fi.Exists == true)
            {
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    using (StreamReader sr = new StreamReader(FileName_FullPath, encode))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            str.Append(line + "\n");
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    str.Append("The file could not be read:");
                    str.Append(e.Message);
                }
                return str.ToString();
            }

            return "File is not Exists";

        }

        public static void WriteTextLog(string strLoginUserID, string strPage, string strError)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------------------------------------------------------------------------");
            sb.AppendLine("登录用户：" + strLoginUserID);
            sb.AppendLine("执行页面：" + strPage);
            sb.AppendLine("执行时间：" + DateTime.Now.ToString());
            sb.AppendLine("错误信息：");
            sb.AppendLine(strError);
            ToolBox.FileHelper.WriteText(ConfigurationManager.AppSettings["TextLogDirectory"] + DateTime.Today.ToString("yyyyMMdd") + ".txt", sb.ToString(), true, System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// Read file content 
        /// </summary>
        /// <param name="FileName_FullPath">file name</param>
        /// <returns></returns>
        public static string ReadText(string FileName_FullPath)
        {
            return ReadText(FileName_FullPath, Encoding.GetEncoding("GB2312"));
        }
        #endregion

        #region - WriteText -
        /// <summary>
        /// write file content
        /// </summary>
        /// <param name="FileName_FullPath">file name</param>
        /// <param name="strContent">write content</param>
        /// <param name="IsAppend">is append</param>
        public static void WriteText(string FileName_FullPath, string strContent, bool IsAppend)
        {
            WriteText(FileName_FullPath, strContent, IsAppend, Encoding.GetEncoding("gb2312"));
        }

        /// <summary>
        /// write file content
        /// </summary>
        /// <param name="FileName_FullPath">file name</param>
        /// <param name="strContent">write content</param>
        /// <param name="IsAppend">is append</param>
        /// <param name="encoding">encoding</param>
        public static void WriteText(string FileName_FullPath, string strContent, bool IsAppend, Encoding encoding)
        {
            FileInfo fi = new FileInfo(FileName_FullPath);

            if (fi.Exists == false)
            {
                DirectoryInfo di = new DirectoryInfo(fi.DirectoryName);

                if (di.Exists == false)
                {
                    di.Create();
                }
                using (FileStream fs = fi.Create())
                {
                }

                IsAppend = false;
            }

            if (IsAppend == true)
            {
                using (StreamWriter sw = fi.AppendText())
                {
                    sw.Write(strContent);
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(FileName_FullPath, false, encoding))
                {
                    sw.Write(strContent);
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// write file content
        /// </summary>
        /// <param name="FileName_FullPath">file name</param>
        /// <param name="strContent">write content</param>
        public static void WriteText(string FileName_FullPath, string strContent)
        {
            WriteText(FileName_FullPath, strContent, false);
        }
        #endregion


        #region 流到字节

        public static byte[] ToByte(Stream stream)
        {
            byte[] buffer = null;
            buffer = new byte[(int)stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            return buffer;
        }
        #endregion
    }
}
