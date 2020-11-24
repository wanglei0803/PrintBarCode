using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Natty.Utility.ToolBox
{
    public class CharInputCheck
    {
        /// <summary>
        /// 声明一带返回值的委托
        /// </summary>
        public delegate Boolean DelegateCheckFieldExist(String StrString);

        /// <summary>
        /// 为空检测/最小检测/最长检测/正则检测/匹配检测/存在检测
        /// </summary>
        /// <param name="StrString">所要检测的字符串</param>
        /// <param name="IntMinLength">最小长度限制(0为不检测)</param>
        /// <param name="IntMaxLength">最长长度限制(0为不检测)</param>
        /// <param name="bolChinese">对中文字符是否有效(有效则全角计2)</param>
        /// <param name="StrRegex">正则表达式(空为不检测)</param>
        /// <param name="StrMatch">标准字符串检测(是否作了修改,空为不检测)</param>
        /// <param name="CheckFieldExist">(委托)是否存在(null为不检测)</param>
        /// <returns></returns>
        public static EnumCharInputCheck CheckInput(String StrString,Boolean bolCheckEmpty, Int32 IntMinLength, Int32 IntMaxLength, Boolean bolChinese, String StrRegex, String StrMatch, DelegateCheckFieldExist CheckFieldExist)
        {
            Int32 intCharLength = 0;
            if (bolChinese == true)
            {
                intCharLength = CharacterHelper.GetLength(StrString);
            }//如果对中文字符有效则采用全角字符长计算法
            else
            {
                intCharLength = StrString.Length;
            }//如果对中文字符无效则采用一般字符长计算法
            if (string.IsNullOrEmpty(StrString) && bolCheckEmpty==true)
            {
                return EnumCharInputCheck.Empty;
            }//字符串为空
            else
            {
                if (IntMinLength != 0)
                {
                    if (intCharLength < IntMinLength && !string.IsNullOrEmpty(StrString))
                    {
                        return EnumCharInputCheck.Min;
                    }//小于最小长度
                }//最小长度作限制
                if (IntMaxLength != 0)
                {
                    if (intCharLength > IntMaxLength)
                    {
                        return EnumCharInputCheck.Max;
                    }//大于最大长度
                }//最大长度作限制
                if (!string.IsNullOrEmpty(StrRegex))
                {
                    if (!Regex.IsMatch(StrString, StrRegex))
                    {
                        return EnumCharInputCheck.Regex;
                    }
                }//正则作限制
                if (!string.IsNullOrEmpty(StrMatch))
                {
                    if (StrString.Trim() == StrMatch.Trim())
                    {
                        return EnumCharInputCheck.Match;
                    }
                }//标准字符串检测(是否作了修改)
                if (CheckFieldExist != null)
                {
                    if (!CheckFieldExist(StrString))
                    {
                        return EnumCharInputCheck.Exsit;
                    }//不通过，存在
                }//是否存在检测
            }//字符串不为空
            return EnumCharInputCheck.Pass;
        }

        /// <summary>
        /// 重载：为空检测/必填检测/最小检测/最长检测/正则检测/匹配检测/存在检测
        /// </summary>
        public static EnumCharInputCheck CheckInput(String StrString, Int32 IntMinLength, Int32 IntMaxLength, Boolean bolChinese, String StrRegex, String StrMatch, DelegateCheckFieldExist CheckFieldExist)
        {
            return CheckInput(StrString, true, IntMinLength, IntMaxLength, bolChinese, StrRegex, StrMatch, CheckFieldExist);
        }
    }
    /// <summary>
    /// 字符检测结果
    /// </summary>
    public enum EnumCharInputCheck
    {
        /// <summary>
        /// 通过检测
        /// </summary>
        Pass = 0,
        /// <summary>
        /// 字符串为空
        /// </summary>
        Empty = 1,
        /// <summary>
        /// 小于最小值
        /// </summary>
        Min = 2,
        /// <summary>
        /// 大于最大值
        /// </summary>
        Max = 3,
        /// <summary>
        /// 正则不匹配
        /// </summary>
        Regex = 4,
        /// <summary>
        /// 值相同
        /// </summary>
        Match = 5,
        /// <summary>
        /// 已存在
        /// </summary>
        Exsit = 6,
        /// <summary>
        /// 与标准字符串一致
        /// </summary>
        Standard = 7
    }
}
