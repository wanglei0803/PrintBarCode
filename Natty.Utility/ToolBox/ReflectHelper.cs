using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// 
    /// </summary>
    public class ReflectHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Enum"></param>
        /// <returns></returns>
        public static IList<string> ReflectEnum(object Enum)
        {
            IList<string> iList = new List<string>();
            Type enumType = Enum.GetType();
            if (enumType.IsEnum != true)
            {    //不是枚举的要报错
                throw new InvalidOperationException();
            }

            //获得枚举的字段信息（因为枚举的值实际上是一个static的字段的值）
            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            //检索所有字段
            foreach (FieldInfo field in fields)
            {
                //过滤掉一个不是枚举值的，记录的是枚举的源类型
                if (field.FieldType.IsEnum == true)
                {
                    iList.Add(field.Name);
                }
            }
            return iList;
        }
    }
}
