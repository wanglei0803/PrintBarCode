using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
namespace Natty.Utility.ToolBox 
{
    public static class ErrLogHelper 
    {
        /// <summary>
        /// 页面错误日志记录
        /// </summary>
        /// <param name="ex">错误</param>
        /// <param name="hr">错误页面</param>
        public static void ErrLogWrite(Exception ex, HttpRequest hr) {
            string LogFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
            StreamWriter SW;
            string FileName = DateTime.Now.ToString("yy-MM-dd") + ".log";
            string FilePath = LogFilePath + FileName;
            try {
                if (!Directory.Exists(LogFilePath)) {
                    Directory.CreateDirectory(LogFilePath);
                }
                if (!File.Exists(FilePath)) {
                    SW = File.CreateText(FilePath);
                }
                else {
                    SW = File.AppendText(FilePath);
                }
                SW.WriteLine("==================================================页面错误信息====================================================");
                SW.WriteLine("错误时间：" + DateTime.Now.ToString());
                SW.WriteLine("错误页面：" + hr.RawUrl.ToString());
                SW.WriteLine("错误消息：" + ex.Message.ToString());
                SW.WriteLine("导致错误的应用程序或对象的名称:" + ex.Source.ToString());
                SW.WriteLine("堆栈内容:" + ex.StackTrace.ToString());
                SW.WriteLine("引发异常的方法:" + ex.TargetSite.ToString());
                SW.WriteLine("===================================================================================================================");
                SW.WriteLine(" ");
                SW.Close();
            }
            catch { }
        }
        /// <summary>
        /// 类错误日志记录
        /// </summary>
        /// <param name="ex">错误</param>
        /// <param name="ErrClassName">发生错误的类名</param>
        public static void ErrLogWrite(Exception ex, string ErrClassName) {
            string LogFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
            StreamWriter SW;
            string FileName = DateTime.Now.ToString("yy-MM-dd") + ".Log";
            string FilePath = LogFilePath + FileName;
            try {
                if (!Directory.Exists(LogFilePath)) {
                    Directory.CreateDirectory(LogFilePath);
                }
                if (!File.Exists(FilePath)) {
                    SW = File.CreateText(FilePath);
                }
                else {
                    SW = File.AppendText(FilePath);
                }
                SW.WriteLine("==================================================页面错误信息====================================================");
                SW.WriteLine("错误时间：" + DateTime.Now.ToString());
                SW.WriteLine("错误类名：" + ErrClassName.ToString());
                SW.WriteLine("错误消息：" + ex.Message.ToString());
                SW.WriteLine("导致错误的应用程序或对象的名称:" + ex.Source.ToString());
                SW.WriteLine("堆栈内容:" + ex.StackTrace.ToString());
                SW.WriteLine("引发异常的方法:" + ex.TargetSite.ToString());
                SW.WriteLine("===================================================================================================================");
                SW.WriteLine(" ");
                SW.Close();
            }
            catch { }
        }

        public static void DeleteInfoLog(string URL) {
            string LogFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
            StreamWriter SW;
            string FileName = DateTime.Now.ToString("yy-MM-dd") + "_DeleteInfo.Log";
            string FilePath = LogFilePath + FileName;
            try {
                if (!Directory.Exists(LogFilePath)) {
                    Directory.CreateDirectory(LogFilePath);
                }
                if (!File.Exists(FilePath)) {
                    SW = File.CreateText(FilePath);
                }
                else {
                    SW = File.AppendText(FilePath);
                }
                SW.WriteLine("==================================================删除信息日志信息====================================================");
                SW.WriteLine("删除时间：" + DateTime.Now.ToString());
                SW.WriteLine("信息地址：" + URL.ToString());
                SW.WriteLine("===================================================================================================================");
                SW.WriteLine(" ");
                SW.Close();
            }
            catch { }
        }

        public static void WriteLog(string LogText) {
            string LogFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
            StreamWriter SW;
            string FileName = DateTime.Now.ToString("yy-MM-dd") + "_RunLog.Log";
            string FilePath = LogFilePath + FileName;
            try {
                if (!Directory.Exists(LogFilePath)) {
                    Directory.CreateDirectory(LogFilePath);
                }
                if (!File.Exists(FilePath)) {
                    SW = File.CreateText(FilePath);
                }
                else {
                    SW = File.AppendText(FilePath);
                }
                SW.WriteLine("==================================================日志信息====================================================");
                SW.WriteLine("出错时间：" + DateTime.Now.ToLongTimeString());
                SW.WriteLine(LogText.ToString());
                SW.WriteLine("==============================================================================================================");
                SW.WriteLine(" ");
                SW.Close();
               
            }
            catch { }
        }
        public static void WriteLogs(string LogText) {
            string LogFilePath = System.Configuration.ConfigurationManager.AppSettings["LogFilePath"];
            StreamWriter SW;
            string FileName = DateTime.Now.ToString("yy-MM-dd") + "_RunLog.Log";
            string FilePath = LogFilePath + FileName;
            try {
                if (!Directory.Exists(LogFilePath)) {
                    Directory.CreateDirectory(LogFilePath);
                }
                if (!File.Exists(FilePath)) {
                    SW = File.CreateText(FilePath);
                }
                else {
                    SW = File.AppendText(FilePath);
                }
                //SW.WriteLine("==================================================日志信息====================================================");
                SW.WriteLine(LogText.ToString());
                //SW.WriteLine("==============================================================================================================");
                SW.Close();
            }
            catch { }
        }

        public static void WriteSearchTheme(string SearchTheme) {
            string LogFilePath = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["SearchTheme"]);
            //StreamWriter SW;
            string FileName = "TestTheme.txt";
            string FilePath = LogFilePath + FileName;
            try {
                if (!Directory.Exists(LogFilePath)) {
                    Directory.CreateDirectory(LogFilePath);
                }
                File.Delete(FilePath);
                //if (!File.Exists(FilePath))
                //{
                //   File.CreateText(FilePath);
                //}
                File.AppendAllText(FilePath, SearchTheme, System.Text.Encoding.UTF8);

                //SW.WriteLine(SearchTheme.ToString());
            }
            catch { }
        }
    }
}

