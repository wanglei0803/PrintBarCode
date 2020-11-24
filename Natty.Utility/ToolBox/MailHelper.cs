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
    /// �ʼ�����
    /// </summary>
    public class MailHelper
    {
        /// <summary>
        /// ���ʼ�
        /// </summary>
        /// <param name="to">�ռ���(�Էֺŷָ��ĵ����ʼ���ַ�б�)</param>
        /// <param name="subject">����</param>
        /// <param name="message">�ʼ���</param>
        /// <param name="ishtml">�Ƿ�ʹ��HTML����</param>
        /// <param name="encode">����</param>
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
                msg.SubjectEncoding = encode;//����
                msg.BodyEncoding = encode;
                msg.IsBodyHtml = ishtml;
                smtpClient.Send(msg);
            }
        }
        /// <summary>
        /// ���ʼ�
        /// </summary>
        /// <param name="to">�ռ���(�Էֺŷָ��ĵ����ʼ���ַ�б�)</param>
        /// <param name="subject">����</param>
        /// <param name="message">�ʼ���</param>
        /// <param name="ishtml">�Ƿ�ʹ��HTML����</param>
        public static void SendMail(string to, string subject, string message, bool ishtml)
        {
            SendMail(to, subject, message, ishtml, Encoding.GetEncoding("GB2312"));
        }
        /// <summary>
        /// ���ʼ�
        /// </summary>
        /// <param name="to">�ռ���(�Էֺŷָ��ĵ����ʼ���ַ�б�)</param>
        /// <param name="subject">����</param>
        /// <param name="message">�ʼ���</param>
        public static void SendMail(string to, string subject, string message)
        {
            SendMail(to, subject, message, true);
        }
    }
    #endregion
}
