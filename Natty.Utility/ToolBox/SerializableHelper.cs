/******************************************************************
 * 文件名称:            SerializableHelper.cs
 * 文件说明:            序列化Helper文件
 * 模块:                公共类库
 * 作者:                刘晓飞
 * 时间:                2007/4/19
 * 修改记录:            无修改
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
    /// 序列化Helper类
    /// </summary>
    public static class SerializableHelper {


        #region Soap 序列化工具
        /// <summary>
        /// 将对象序列化成字符串
        /// </summary>
        /// <param name="Obj">对象</param>
        /// <returns>序列化后的字符串</returns>
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
        /// 反序列化
        /// </summary>
        /// <param name="Str">系列化后的字符串</param>
        /// <returns>对象</returns>
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
                //写日志
                return null;
            }
            return Result;
        }

        #endregion

        #region Binary序列化方法
        /// <summary>
        /// 将对象序列化
        /// </summary>
        /// <param name="obj">序列化对象</param>
        /// <returns>序列化串</returns>
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
        /// 将字符串反序列化为对象
        /// </summary>
        /// <param name="str">序列化字符串</param>
        /// <returns>对象</returns>
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

        #region WCF对象的序列化与反序列化
        /// <summary>
        /// 把WCF契约对象序列化为字符串
        /// </summary>
        /// <param name="obj">WCF契约对象</param>
        /// <returns>序列化字符串</returns>
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
        /// 把字符串序列化为指定类型
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="str">序列化字符串</param>
        /// <returns>目标类型</returns>
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
        /// 把WCF契约对象序列化为字符串
        /// </summary>
        /// <param name="obj">WCF契约对象</param>
        /// <returns>序列化字符串</returns>
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
        /// 把字符串序列化为指定类型
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="str">序列化字符串</param>
        /// <returns>目标类型</returns>
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

        #region Xml序列化
        /// <summary>
        /// 将对象序列化
        /// </summary>
        /// <param name="obj">序列化的对象</param>
        /// <returns>序列化字符串</returns>
        public static string XmlSerialize(object obj) {
            StreamWriter sw = null;
            string serializeString = null;

            try {
                // 以下代码可能导致头晕，请选择观看
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
        /// 将字符串反序列化为对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="serializedString">序列化字符串</param>
        /// <returns>返回反序列化的对象</returns>
        public static T XmlDeserialize<T>(string serializedString) where T:class {

            //如果传入的是空串，直接返回
            if (serializedString.Trim().Equals(string.Empty)) {
                throw new Exception("传入的序列化字符串为空");
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