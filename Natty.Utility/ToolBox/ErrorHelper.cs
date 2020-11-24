using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.IO;
using System.Configuration;

namespace Natty.Utility.ToolBox
{

    #region ErrorHelper
    /// <summary>
    /// ¥ÌŒÛ»’÷æ
    /// </summary>
    public class ErrorHelper
    {
        #region - WriteLog -
        /// <summary>
        /// ¥ÌŒÛ–¥»Î 
        /// </summary>
        /// <param name="app">HttpApplication</param>
        public static void WriteLog(HttpApplication app)
        {
            WriteLog(app, true);
        }
        /// <summary>
        /// ¥ÌŒÛ–¥»Î
        /// </summary>
        /// <param name="app">HttpApplication</param>
        /// <param name="IsApplication">IsApplication</param>
        public static void WriteLog(HttpApplication app, bool IsApplication)
        {
            DataSet ds = new DataSet("Error");

            string filename = ConfigurationManager.AppSettings["ErrorDirectory"] + DateTime.Now.Year + "\\" + DateTime.Now.ToString("MM") + "\\Error_" + DateTime.Now.ToString("yyyyMMdd") + ".xml";
            string model = ConfigurationManager.AppSettings["ErrorDirectory"] + "model.xml";


            FileInfo fi = new FileInfo(filename);

            DataTable oTable;

            if (fi.Exists == false)
            {
                if (fi.Directory.Exists == false)
                {
                    fi.Directory.Create();
                }
                oTable = new DataTable("Error");

                oTable.Columns.Add(new DataColumn("url", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("ip", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("message", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("source", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("dateTime", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("QueryString", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("Form", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("UrlReferrer", Type.GetType("System.String")));
                oTable.Columns.Add(new DataColumn("IsApplication", Type.GetType("System.Boolean")));
                oTable.Columns.Add(new DataColumn("UserName", Type.GetType("System.String")));


                ds.Tables.Add(oTable);
            }
            else
            {
                ds.ReadXml(filename);
                oTable = ds.Tables["Error"];
            }

            Exception ex = app.Server.GetLastError().GetBaseException();

            //if (ex.Message.ToLower().IndexOf("does not exist") == -1) //∫ˆ¬‘Œƒº˛¥ÌŒÛ
            {
                DataRow dr = oTable.NewRow();
                dr["url"] = app.Request.Url.ToString();
                dr["ip"] = app.Request.ServerVariables["REMOTE_ADDR"];
                dr["message"] = ex.Message;
                dr["source"] = ex.StackTrace;
                dr["dateTime"] = DateTime.Now.ToString();
                dr["QueryString"] = app.Request.QueryString.ToString();
                dr["Form"] = app.Request.Form.ToString();
                if (app.Request.UrlReferrer != null)
                {
                    dr["UrlReferrer"] = app.Request.UrlReferrer.ToString();
                }
                else
                {
                    dr["UrlReferrer"] = "";
                }

                dr["IsApplication"] = IsApplication;
                dr["UserName"] = (string.IsNullOrEmpty(app.User.Identity.Name) == false) ? app.User.Identity.Name : "Anonymous";



                oTable.Rows.Add(dr);


                ds.WriteXml(filename, XmlWriteMode.IgnoreSchema);
            }
        }
        #endregion
    }
    #endregion
}
