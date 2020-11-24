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
            {    //����ö�ٵ�Ҫ����
                throw new InvalidOperationException();
            }

            //���ö�ٵ��ֶ���Ϣ����Ϊö�ٵ�ֵʵ������һ��static���ֶε�ֵ��
            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            //���������ֶ�
            foreach (FieldInfo field in fields)
            {
                //���˵�һ������ö��ֵ�ģ���¼����ö�ٵ�Դ����
                if (field.FieldType.IsEnum == true)
                {
                    iList.Add(field.Name);
                }
            }
            return iList;
        }
    }
}
