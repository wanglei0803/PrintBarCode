using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Microsoft.VisualBasic;


namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// ����/����
    /// </summary>
    public class Encrypt
    {
        #region ���ܹ���
        /// <summary>
        ///   DEC���ܹ���
        /// </summary>
        /// <param name="pToEncrypt">�������ַ���</param>
        /// <param name="sKey">��������</param>
        /// <returns></returns>
        public static string DECEncrypt(string pToEncrypt, string sKey)
        {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); //���ַ����ŵ�byte������  



            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

            //byte[] inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  



            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey); //�������ܶ������Կ��ƫ����  


            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey); //ԭ��ʹ��ASCIIEncoding.ASCII������GetBytes����  

            MemoryStream ms = new MemoryStream(); //ʹ�����������������Ӣ���ı�  

            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);


            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();


            StringBuilder ret = new StringBuilder();

            foreach (byte b in ms.ToArray())
            {

                ret.AppendFormat("{0:X2}", b);

            }

            ret.ToString();

            return ret.ToString();

        }
        #endregion

        #region ���ܹ���
        /// <summary>
        ///  DEC ���ܹ���  
        /// </summary>
        /// <param name="pToDecrypt">�ַ���</param>
        /// <param name="sKey">��������</param>
        /// <returns></returns>
        public static string DECDecrypt(string pToDecrypt, string sKey)
        {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();


            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];

            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {

                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));

                inputByteArray[x] = (byte)i;

            }


            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);//�������ܶ������Կ��ƫ��������ֵ��Ҫ�������޸�  

            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);



            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();


            StringBuilder ret = new StringBuilder();//����StringBuild����CreateDecryptʹ�õ��������󣬱���ѽ��ܺ���ı����������  



            return System.Text.Encoding.Default.GetString(ms.ToArray());

        }
        #endregion

        #region MD5
        /// <summary>
        /// MD5Hash
        /// </summary>
        /// <param name="strText">�ַ���</param>
        /// <returns></returns>
        public static string MD5Hash(string strText)
        {
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] result = MD5.ComputeHash(System.Text.Encoding.Default.GetBytes(strText));
            return System.Text.Encoding.Default.GetString(result);
        }
        /// <summary>
        /// MD516
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns></returns>
        public static string MD516(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
        }
        /// <summary>
        /// MD532
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns></returns>
        public static string MD532(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
        }
        #endregion

        /// <summary>
        /// Base64����
        /// </summary>
        /// <param name="code_type"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string Base64Encode(string code_type, string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }

        /// <summary>
        /// Base64����
        /// </summary>
        /// <param name="code_type"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string Base64Decode(string code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }

    }
}
