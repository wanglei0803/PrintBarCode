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
    /// 枚举帮助类
    /// </summary>
    public class EnumHelper
    {

        #region 将枚举信息绑定到DropDownList里

        /// <summary>
        /// 将枚举信息绑定到DropDownList里
        /// </summary>
        /// <typeparam name="T">枚举继承类型</typeparam>
        /// <param name="drop">DropDownList</param>
        /// <param name="enumType">枚举类型</param>
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

        #region 获得某个Enum类型的绑定列表
        /// <summary>
        /// 获得某个Enum类型的绑定列表
        /// </summary>
        /// <param name="enumType">枚举的类型，例如：typeof(Sex)</param>
        /// <returns>
        /// 返回一个DataTable
        /// DataTable 有两列：    "Text"    : System.String;
        ///                        "Value"    : System.Char
        /// </returns>
        public static DataTable EnumListTable(Type enumType)
        {
            return EnumListTable<byte>(enumType);
        }
        /// <summary>
        /// 获得某个Enum类型的绑定列表
        /// </summary>
        /// <typeparam name="T">枚举继承类型</typeparam>
        /// <param name="enumType">枚举的类型</param>
        /// <returns></returns>
        public static DataTable EnumListTable<T>(Type enumType)
        {
            if (enumType.IsEnum != true)
            {    //不是枚举的要报错
                throw new InvalidOperationException();
            }
            string cachekey = enumType.ToString();
            object o = CacheHelper.Get(cachekey);
            if (o != null && (o is DataTable))
            {
                return (DataTable)o;
            }

            //建立DataTable的列信息
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(System.String));
            dt.Columns.Add("Value", typeof(System.String));

            //获得特性Description的类型信息
            Type typeDescription = typeof(DescriptionAttribute);

            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            //检索所有字段
            string strValue = string.Empty;
            string strText = string.Empty;
            foreach (FieldInfo field in fields)
            {
                //过滤掉一个不是枚举值的，记录的是枚举的源类型
                if (field.FieldType.IsEnum == true)
                {
                    DataRow dr = dt.NewRow();

                    // 通过字段的名字得到枚举的值
                    dr["Value"] = ((T)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null));

                    //获得这个字段的所有自定义特性，这里只查找Description特性
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        dr["Text"] = aa.Description;
                    }
                    else
                    {
                        //如果没有特性描述,就显示英文的字段名
                        dr["Text"] = field.Name;
                    }
                    dt.Rows.Add(dr);
                }
            }
            CacheHelper.Insert(cachekey, dt);

            return dt;
        }

        #endregion

        #region 获得某个Enum类型的中文翻译，从description中读取
        /// <summary>
        /// 获得某个Enum类型的中文翻译，从description中读取
        /// </summary>
        /// <param name="enumType">枚举的类型</param>
        /// <param name="val">传入的值</param>
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
