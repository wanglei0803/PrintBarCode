using System;
using System.Collections.Generic;
using System.Text;
using Natty.Utility.ToolBox;
using System.Text.RegularExpressions;

namespace Natty.Utility.ToolBox
{
    public class SystemEncrypt //: ISystemEncrypt
    {
        #region ��ǿ����
        /// <summary>
        /// DEC��ǿ����:ǿ��***
        /// </summary>
        /// <param name="strString">�������ַ���</param>
        /// <param name="strKey">��Կ</param>
        /// <returns></returns>
        public string DECKeyEncrypt(string strString, string strKey)
        {
            strKey = Encrypt.MD532(strKey).Substring(5, 8);
            return Encrypt.DECEncrypt(strKey + strString, strKey);
        }

        /// <summary>
        /// DEC��ǿ����
        /// </summary>
        /// <param name="strString">�������ַ���</param>
        /// <param name="strKey">��Կ</param>
        /// <returns></returns>
        public string DECKeyDecrypt(string strString, string strKey)
        {
            strKey = Encrypt.MD532(strKey).Substring(5, 8);
            strString = Encrypt.DECDecrypt(strString, strKey);
            return Regex.Replace(strString, "^" + strKey, string.Empty);
        }
        #endregion ��ǿ����

        #region DEC��ǿ�������
        /// <summary>
        /// DEC��ǿ�������:ǿ��****
        /// </summary>
        /// <param name="strString">�������ַ���</param>
        /// <param name="strKey">��Կ</param>
        /// <returns></returns>
        public string DecKeyRandomEncrypt(string strString, string strKey)
        {
            Random rd = new Random();
            int i = rd.Next(0, 9);
            strKey = Encrypt.MD532(strKey).Substring(5 + i, 8);
            return i.ToString() + Encrypt.DECEncrypt(i.ToString() + strKey + strString, strKey);
        }

        /// <summary>
        /// DEC��ǿ�������
        /// </summary>
        /// <param name="strString">�������ַ���</param>
        /// <param name="strKey">��Կ</param>
        /// <returns></returns>
        public string DecKeyRandomDecrypt(string strString, string strKey)
        {
            if (string.IsNullOrEmpty(strString))
            {
                return string.Empty;
            }
            int i = int.Parse(strString.Substring(0, 1));
            strKey = Encrypt.MD532(strKey).Substring(5 + i, 8);
            strString = strString.Substring(1, strString.Length - 1);
            strString = Encrypt.DECDecrypt(strString, strKey);
            return Regex.Replace(strString, "^" + i.ToString() + strKey, string.Empty);
        }
        #endregion DEC��ǿ�������


        #region DEC�ֳ���Կ�ӽ���
        /// <summary>
        /// �������ݵĳ��Ȼ����Կ
        /// </summary>
        /// <param name="EncryptStr"></param>
        /// <returns></returns>
        private string GetKey1(string EncryptStr)
        {
            string returnstr = string.Empty;
            if (EncryptStr.Length % 2 == 1)
            {
                returnstr = "#@#$*@%^";
            }
            else
            {
                returnstr = "%*^@!***";
            }
            return returnstr;
        }
        /// <summary>
        /// �õ�һ������ַ�
        /// </summary>
        private string GenerateCheckCode(int digit)
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
                    code = (char)('0' + (char)(number % 10));
                }
                else
                {
                    code = (char)('A' + (char)(number % 26));
                }
                checkCode += code.ToString();
            }
            return checkCode;
        }


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="EncryptStr"></param>
        /// <returns></returns>
        private String DECKeyLengthEncrypt(String EncryptStr)
        {
            String OldEncryptStr = EncryptStr;
            String ReturnEncrypt = String.Empty;
            if (!string.IsNullOrEmpty(EncryptStr))
            {
                ReturnEncrypt = Encrypt.DECEncrypt(EncryptStr, GetKey1(OldEncryptStr));
                Int32 LengthAverage = ReturnEncrypt.Length / 2;
                if (EncryptStr.Length % 2 == 1)
                {
                    ReturnEncrypt = ReturnEncrypt.Substring(LengthAverage, LengthAverage) + GenerateCheckCode(1) + ReturnEncrypt.Substring(0, LengthAverage);
                }
                else
                {
                    ReturnEncrypt = ReturnEncrypt.Substring(LengthAverage, LengthAverage) + ReturnEncrypt.Substring(0, LengthAverage);
                }
            }
            return ReturnEncrypt;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="EncryptStr"></param>
        /// <returns></returns>
        private string DECKeyLengthDecrypt(string EncryptStr)
        {
            string OldEncryptStr = EncryptStr;
            string ReturnEncrypt = string.Empty;

            int LengthAverage = EncryptStr.Length / 2;

            if (EncryptStr.Length % 2 == 1)
            {
                ReturnEncrypt = EncryptStr.Substring(LengthAverage + 1, LengthAverage) + EncryptStr.Substring(0, LengthAverage);
            }
            else
            {
                ReturnEncrypt = EncryptStr.Substring(LengthAverage, LengthAverage) + EncryptStr.Substring(0, LengthAverage);
            }
            return Encrypt.DECDecrypt(ReturnEncrypt, GetKey1(OldEncryptStr));
        }
        #endregion DEC��ǿ�������


        #region ҵ����� by hfw
        /// <summary>
        /// Cookie�ӽ���
        /// </summary>
        /// <param name="strString"></param>
        /// <param name="codeType">true���� false ����</param>
        /// <returns></returns>
        public string CookieUserIDCode(string strString, bool bolEncrypt)
        {
            if (bolEncrypt == true)
            {
                return DecKeyRandomEncrypt(strString, "www.58.com");
            }
            else
            {
                return DecKeyRandomDecrypt(strString, "www.58.com");
            }
        }

        /// <summary>
        /// ��������ӽ���
        /// </summary>
        /// <param name="strString"></param>
        /// <param name="codeType">true���� false ����</param>
        /// <returns></returns>
        public string ForgetPasswordCode(string strString, bool bolEncrypt)
        {
            if (bolEncrypt == true)
            {
                return DecKeyRandomEncrypt(strString, "***.58.###");
            }
            else
            {
                return DecKeyRandomDecrypt(strString, "***.58.###");
            }
        }

        /// <summary>
        /// ͼƬ�ӽ���
        /// </summary>
        /// <param name="strString"></param>
        /// <param name="codeType">true���� false ����</param>
        /// <returns></returns>
        public string ImageCode(string strString, bool bolEncrypt)
        {
            if (bolEncrypt == true)
            {
                return DECKeyLengthEncrypt(strString);
            }
            else
            {
                
                return DECKeyLengthDecrypt(strString);
            }
        }

        public string PayCode(string strString, bool bolEncrypt)
        {
            if (bolEncrypt)
            {
                return DecKeyRandomEncrypt(strString, "payGo##$");
            }
            else
            {
                return DecKeyRandomDecrypt(strString, "payGo##$");
            }
        }

        #endregion
    }
}
