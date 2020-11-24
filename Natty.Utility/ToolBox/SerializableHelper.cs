/******************************************************************
 * �ļ�����:            SerializableHelper.cs
 * �ļ�˵��:            ���л�Helper�ļ�
 * ģ��:                �������
 * ����:                ������
 * ʱ��:                2007/4/19
 * �޸ļ�¼:            ���޸�
 *****************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// ���л�Helper��
    /// </summary>
    public static class SerializableHelper {


        #region Soap ���л�����
        /// <summary>
        /// ���������л����ַ���
        /// </summary>
        /// <param name="Obj">����</param>
        /// <returns>���л�����ַ���</returns>
        public static string SoapSerializable(object Obj)
        {
            string Rsult = string.Empty;
            try
            {
                IFormatter Formatter = new SoapFormatter();
                Stream MS = new MemoryStream();
                Formatter.Serialize(MS, Obj);
                byte[] B = new byte[MS.Length];
                MS.Position = 0;
                MS.Read(B, 0, B.Length);
                Rsult = Convert.ToBase64String(B);
                MS.Close();
                MS.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Rsult;
        }

        /// <summary>
        /// �����л�
        /// </summary>
        /// <param name="Str">ϵ�л�����ַ���</param>
        /// <returns>����</returns>
        public static T SoapDeserialize<T>(string Str) where T:class
        {
            T Result = null;
            try
            {
                IFormatter Formatter = new SoapFormatter();
                byte[] B = Convert.FromBase64String(Str);
                Stream MS = new MemoryStream(B);
                Result = Formatter.Deserialize(MS) as T;
                MS.Close();
                MS.Dispose();
            }
            catch(Exception)
            {
                //д��־
                return null;
            }
            return Result;
        }

        #endregion

        #region Binary���л�����
        /// <summary>
        /// ���������л�
        /// </summary>
        /// <param name="obj">���л�����</param>
        /// <returns>���л���</returns>
        public static string BinarySerialize(object obj) {
            string result = default(string);
            if (obj != null) {
                try {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream stream = new MemoryStream();
                    formatter.Serialize(stream, obj);
                    result = Encoding.Unicode.GetString(stream.GetBuffer());
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
            return result;

    
        }



        /// <summary>
        /// ���ַ��������л�Ϊ����
        /// </summary>
        /// <param name="str">���л��ַ���</param>
        /// <returns>����</returns>
        public static T BinaryDeserialize<T>(string str) where T:class  {
            T result = null;
            if (str.Length > 0)
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(str));
                    stream.Position = 0;
                    stream.Seek(0, System.IO.SeekOrigin.Begin);
                    result = formatter.Deserialize(stream) as T;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        #endregion

        #region WCF��������л��뷴���л�
        /// <summary>
        /// ��WCF��Լ�������л�Ϊ�ַ���
        /// </summary>
        /// <param name="obj">WCF��Լ����</param>
        /// <returns>���л��ַ���</returns>
        public static string DataContractSerialize(object obj)
        {
            string result = default(string);
            if (obj != null)
            {
                try
                {
                    MemoryStream stream = new MemoryStream();
                    System.Runtime.Serialization.DataContractSerializer se = new DataContractSerializer(obj.GetType());
                    se.WriteObject(stream, obj);
                    stream.Position = 0;
                    StreamReader sr = new StreamReader(stream);

                    result = sr.ReadToEnd(); 

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        /// <summary>
        /// ���ַ������л�Ϊָ������
        /// </summary>
        /// <typeparam name="T">�����л�����</typeparam>
        /// <param name="str">���л��ַ���</param>
        /// <returns>Ŀ������</returns>
        public static T DataContractDeSerialize<T>(string str) where T : class
        {
            T result = default(T);
            if (str.Length > 0)
            {
                try
                {
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                    stream.Position = 0;
                    stream.Seek(0, System.IO.SeekOrigin.Begin);

                    DataContractSerializer ser = new DataContractSerializer(typeof(T));
                    result = (T)ser.ReadObject(stream);
                    stream.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }


        /// <summary>
        /// ��WCF��Լ�������л�Ϊ�ַ���
        /// </summary>
        /// <param name="obj">WCF��Լ����</param>
        /// <returns>���л��ַ���</returns>
        public static string NetDataContractSerialize(object obj)
        {
            string result = default(string);
            if (obj != null)
            {
                try
                {
                    MemoryStream stream = new MemoryStream();
                    System.Runtime.Serialization.NetDataContractSerializer se = new NetDataContractSerializer();
                    se.WriteObject(stream, obj);
                    stream.Position = 0;
                    StreamReader sr = new StreamReader(stream);

                    result = sr.ReadToEnd();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        /// <summary>
        /// ���ַ������л�Ϊָ������
        /// </summary>
        /// <typeparam name="T">�����л�����</typeparam>
        /// <param name="str">���л��ַ���</param>
        /// <returns>Ŀ������</returns>
        public static T NetDataContractDeSerialize<T>(string str) where T : class
        {
            T result = default(T);
            if (str.Length > 0)
            {
                try
                {
                    MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                    stream.Position = 0;
                    stream.Seek(0, System.IO.SeekOrigin.Begin);

                    NetDataContractSerializer ser = new NetDataContractSerializer();
                    result = (T)ser.ReadObject(stream);
                    stream.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        #endregion

        #region Xml���л�
        /// <summary>
        /// ���������л�
        /// </summary>
        /// <param name="obj">���л��Ķ���</param>
        /// <returns>���л��ַ���</returns>
        public static string XmlSerialize(object obj) {
            StreamWriter sw = null;
            string serializeString = null;

            try {
                // ���´�����ܵ���ͷ�Σ���ѡ��ۿ�
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                MemoryStream memStream = new MemoryStream();
                sw = new StreamWriter(memStream);
                xmlSerializer.Serialize(sw, obj);
                memStream.Position = 0;
                serializeString = Encoding.UTF8.GetString(memStream.GetBuffer());
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                if (sw != null) {
                    sw.Close();
                }
            }

            return serializeString;
        }


        /// <summary>
        /// ���ַ��������л�Ϊ����
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="serializedString">���л��ַ���</param>
        /// <returns>���ط����л��Ķ���</returns>
        public static T XmlDeserialize<T>(string serializedString) where T:class {

            //���������ǿմ���ֱ�ӷ���
            if (serializedString.Trim().Equals(string.Empty)) {
                throw new Exception("��������л��ַ���Ϊ��");
            }

            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StringReader stringReader = new StringReader(serializedString);
                T obj = xmlSerializer.Deserialize(stringReader) as T ;

                return obj;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
}