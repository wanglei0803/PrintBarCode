using System;
using System.Collections.Generic;
using System.Text;

namespace Natty.Utility.ToolBox
{
    public class ArrayHelper
    {
        /// <summary>
        /// 求一个集合中的最大和最小值
        /// </summary>
        /// <param name="array">集合</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        public static void GetLimitValue(ICollection<long> array, out long minValue,out long maxValue)
        {
            minValue = 0; maxValue = 0;
            foreach (long num in array)
            {
                maxValue = System.Math.Max(maxValue, num);
                minValue = System.Math.Min(minValue, num);
            }
        }
    }
}
