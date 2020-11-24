using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Microsoft.VisualBasic;


namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// 加密/解密
    /// </summary>
    public class Encrypt
    {
        #region 加密过程
        /// <summary>
        ///   DEC加密过程
        /// </summary>
        /// <param name="pToEncrypt">加密码字符串</param>
        /// <param name="sKey">加密密码</param>
        /// <returns></returns>
        public static string DECEncrypt(string pToEncrypt, string sKey)
        {

            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); //把字符串放到byte数组中  



            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

            //byte[] inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  



            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey); //建立加密对象的密钥和偏移量  


            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey); //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  

            MemoryStream ms = new MemoryStream(); //使得输入密码必须输入英文文本  

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

        #region 解密过程
        /// <summary>
        ///  DEC 解密过程  
        /// </summary>
        /// <param name="pToDecrypt">字符串</param>
        /// <param name="sKey">解密密码</param>
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


            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);//建立加密对象的密钥和偏移量，此值重要，不能修改  

            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);



            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();


            StringBuilder ret = new StringBuilder();//建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  



            return System.Text.Encoding.Default.GetString(ms.ToArray());

        }
        #endregion

        #region MD5
        /// <summary>
        /// MD5Hash
        /// </summary>
        /// <param name="strText">字符串</param>
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
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string MD516(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
        }
        /// <summary>
        /// MD532
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string MD532(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
        }
        #endregion

        /// <summary>
        /// Base64加密
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
        /// Base64解密
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
