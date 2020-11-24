using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Natty.Utility.ToolBox
{
    public class CharInputCheck
    {
        /// <summary>
        /// ����һ������ֵ��ί��
        /// </summary>
        public delegate Boolean DelegateCheckFieldExist(String StrString);

        /// <summary>
        /// Ϊ�ռ��/��С���/����/������/ƥ����/���ڼ��
        /// </summary>
        /// <param name="StrString">��Ҫ�����ַ���</param>
        /// <param name="IntMinLength">��С��������(0Ϊ�����)</param>
        /// <param name="IntMaxLength">���������(0Ϊ�����)</param>
        /// <param name="bolChinese">�������ַ��Ƿ���Ч(��Ч��ȫ�Ǽ�2)</param>
        /// <param name="StrRegex">������ʽ(��Ϊ�����)</param>
        /// <param name="StrMatch">��׼�ַ������(�Ƿ������޸�,��Ϊ�����)</param>
        /// <param name="CheckFieldExist">(ί��)�Ƿ����(nullΪ�����)</param>
        /// <returns></returns>
        public static EnumCharInputCheck CheckInput(String StrString,Boolean bolCheckEmpty, Int32 IntMinLength, Int32 IntMaxLength, Boolean bolChinese, String StrRegex, String StrMatch, DelegateCheckFieldExist CheckFieldExist)
        {
            Int32 intCharLength = 0;
            if (bolChinese == true)
            {
                intCharLength = CharacterHelper.GetLength(StrString);
            }//����������ַ���Ч�����ȫ���ַ������㷨
            else
            {
                intCharLength = StrString.Length;
            }//����������ַ���Ч�����һ���ַ������㷨
            if (string.IsNullOrEmpty(StrString) && bolCheckEmpty==true)
            {
                return EnumCharInputCheck.Empty;
            }//�ַ���Ϊ��
            else
            {
                if (IntMinLength != 0)
                {
                    if (intCharLength < IntMinLength && !string.IsNullOrEmpty(StrString))
                    {
                        return EnumCharInputCheck.Min;
                    }//С����С����
                }//��С����������
                if (IntMaxLength != 0)
                {
                    if (intCharLength > IntMaxLength)
                    {
                        return EnumCharInputCheck.Max;
                    }//������󳤶�
                }//��󳤶�������
                if (!string.IsNullOrEmpty(StrRegex))
                {
                    if (!Regex.IsMatch(StrString, StrRegex))
                    {
                        return EnumCharInputCheck.Regex;
                    }
                }//����������
                if (!string.IsNullOrEmpty(StrMatch))
                {
                    if (StrString.Trim() == StrMatch.Trim())
                    {
                        return EnumCharInputCheck.Match;
                    }
                }//��׼�ַ������(�Ƿ������޸�)
                if (CheckFieldExist != null)
                {
                    if (!CheckFieldExist(StrString))
                    {
                        return EnumCharInputCheck.Exsit;
                    }//��ͨ��������
                }//�Ƿ���ڼ��
            }//�ַ�����Ϊ��
            return EnumCharInputCheck.Pass;
        }

        /// <summary>
        /// ���أ�Ϊ�ռ��/������/��С���/����/������/ƥ����/���ڼ��
        /// </summary>
        public static EnumCharInputCheck CheckInput(String StrString, Int32 IntMinLength, Int32 IntMaxLength, Boolean bolChinese, String StrRegex, String StrMatch, DelegateCheckFieldExist CheckFieldExist)
        {
            return CheckInput(StrString, true, IntMinLength, IntMaxLength, bolChinese, StrRegex, StrMatch, CheckFieldExist);
        }
    }
    /// <summary>
    /// �ַ������
    /// </summary>
    public enum EnumCharInputCheck
    {
        /// <summary>
        /// ͨ�����
        /// </summary>
        Pass = 0,
        /// <summary>
        /// �ַ���Ϊ��
        /// </summary>
        Empty = 1,
        /// <summary>
        /// С����Сֵ
        /// </summary>
        Min = 2,
        /// <summary>
        /// �������ֵ
        /// </summary>
        Max = 3,
        /// <summary>
        /// ����ƥ��
        /// </summary>
        Regex = 4,
        /// <summary>
        /// ֵ��ͬ
        /// </summary>
        Match = 5,
        /// <summary>
        /// �Ѵ���
        /// </summary>
        Exsit = 6,
        /// <summary>
        /// ���׼�ַ���һ��
        /// </summary>
        Standard = 7
    }
}
