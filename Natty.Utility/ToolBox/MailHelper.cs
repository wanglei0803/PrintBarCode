using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using System.Web.Configuration;


namespace Natty.Utility.ToolBox
{
    #region MailHelper
    /// <summary>
    /// 邮件发送
    /// </summary>
    public class MailHelper
    {
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="to">收件人(以分号分隔的电子邮件地址列表)</param>
        /// <param name="subject">主题</param>
        /// <param name="message">邮件体</param>
        /// <param name="ishtml">是否使用HTML发出</param>
        /// <param name="encode">编码</param>
        /// <example>SendMail("Hweiwang@yahoo.com.cn", DateTime.Now.ToString(), DateTime.Now.ToString());</example>
        public static void SendMail(string to, string subject, string message, bool ishtml, Encoding encode)
        {
            if (ishtml == false)
            {
                message = CharacterHelper.Html2Text(message);
            }
            SmtpClient smtpClient = new SmtpClient();

            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
            MailSettingsSectionGroup netSmtpMailSection = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            using (MailMessage msg = new MailMessage(netSmtpMailSection.Smtp.From, to, subject, message))
            {
                msg.SubjectEncoding = encode;//王后补
                msg.BodyEncoding = encode;
                msg.IsBodyHtml = ishtml;
                smtpClient.Send(msg);
            }
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="to">收件人(以分号分隔的电子邮件地址列表)</param>
        /// <param name="subject">主题</param>
        /// <param name="message">邮件体</param>
        /// <param name="ishtml">是否使用HTML发出</param>
        public static void SendMail(string to, string subject, string message, bool ishtml)
        {
            SendMail(to, subject, message, ishtml, Encoding.GetEncoding("GB2312"));
        }
        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="to">收件人(以分号分隔的电子邮件地址列表)</param>
        /// <param name="subject">主题</param>
        /// <param name="message">邮件体</param>
        public static void SendMail(string to, string subject, string message)
        {
            SendMail(to, subject, message, true);
        }
    }
    #endregion
}
