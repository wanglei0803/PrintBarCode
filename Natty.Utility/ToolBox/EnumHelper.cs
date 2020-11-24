using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Reflection;
using System.ComponentModel;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// ö�ٰ�����
    /// </summary>
    public class EnumHelper
    {

        #region ��ö����Ϣ�󶨵�DropDownList��

        /// <summary>
        /// ��ö����Ϣ�󶨵�DropDownList��
        /// </summary>
        /// <typeparam name="T">ö�ټ̳�����</typeparam>
        /// <param name="drop">DropDownList</param>
        /// <param name="enumType">ö������</param>
        public static void BindDropDownList<T>(DropDownList drop, Type enumType)
        {
            drop.DataSource = EnumListTable<T>(enumType);
            drop.DataTextField = "Text";
            drop.DataValueField = "Value";
            drop.DataBind();
        }
        public static void BindDropDownList(DropDownList drop, Type enumType)
        {
            BindDropDownList<int>(drop, enumType);
        }
        #endregion

        #region ���ĳ��Enum���͵İ��б�
        /// <summary>
        /// ���ĳ��Enum���͵İ��б�
        /// </summary>
        /// <param name="enumType">ö�ٵ����ͣ����磺typeof(Sex)</param>
        /// <returns>
        /// ����һ��DataTable
        /// DataTable �����У�    "Text"    : System.String;
        ///                        "Value"    : System.Char
        /// </returns>
        public static DataTable EnumListTable(Type enumType)
        {
            return EnumListTable<byte>(enumType);
        }
        /// <summary>
        /// ���ĳ��Enum���͵İ��б�
        /// </summary>
        /// <typeparam name="T">ö�ټ̳�����</typeparam>
        /// <param name="enumType">ö�ٵ�����</param>
        /// <returns></returns>
        public static DataTable EnumListTable<T>(Type enumType)
        {
            if (enumType.IsEnum != true)
            {    //����ö�ٵ�Ҫ����
                throw new InvalidOperationException();
            }
            string cachekey = enumType.ToString();
            object o = CacheHelper.Get(cachekey);
            if (o != null && (o is DataTable))
            {
                return (DataTable)o;
            }

            //����DataTable������Ϣ
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(System.String));
            dt.Columns.Add("Value", typeof(System.String));

            //�������Description��������Ϣ
            Type typeDescription = typeof(DescriptionAttribute);

            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            //���������ֶ�
            string strValue = string.Empty;
            string strText = string.Empty;
            foreach (FieldInfo field in fields)
            {
                //���˵�һ������ö��ֵ�ģ���¼����ö�ٵ�Դ����
                if (field.FieldType.IsEnum == true)
                {
                    DataRow dr = dt.NewRow();

                    // ͨ���ֶε����ֵõ�ö�ٵ�ֵ
                    dr["Value"] = ((T)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null));

                    //�������ֶε������Զ������ԣ�����ֻ����Description����
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        dr["Text"] = aa.Description;
                    }
                    else
                    {
                        //���û����������,����ʾӢ�ĵ��ֶ���
                        dr["Text"] = field.Name;
                    }
                    dt.Rows.Add(dr);
                }
            }
            CacheHelper.Insert(cachekey, dt);

            return dt;
        }

        #endregion

        #region ���ĳ��Enum���͵����ķ��룬��description�ж�ȡ
        /// <summary>
        /// ���ĳ��Enum���͵����ķ��룬��description�ж�ȡ
        /// </summary>
        /// <param name="enumType">ö�ٵ�����</param>
        /// <param name="val">�����ֵ</param>
        /// <returns></returns>
        public static string GetEnumDescription(Type enumType, object val)
        {
            string enumvalue = Enum.GetName(enumType, val);
            FieldInfo finfo = enumType.GetField(enumvalue);
            object[] cAttr = finfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (cAttr.Length > 0)
            {
                DescriptionAttribute desc = cAttr[0] as DescriptionAttribute;
                if (desc != null)
                {
                    return desc.Description;
                }
            }
            return enumvalue;
        }

        #endregion

    }
}
