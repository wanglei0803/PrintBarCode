using System;
using System.Text;

using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Natty.Utility.ToolBox
{
    #region Sort Comparer
    /// <summary>
    /// 通用的List排序器
    /// </summary>
    /// <typeparam name="T">泛型类</typeparam>
    public class SortComparer<T> : IComparer<T>
    {
        /// <summary>
        /// 复合排序字段集合
        /// </summary>
        private ListSortDescriptionCollection m_SortCollection = null;

        /// <summary>
        /// 单一排序
        /// </summary>
        private PropertyDescriptor m_PropDesc = null;

        /// <summary>
        /// 排序方向
        /// </summary>
        private ListSortDirection m_Direction = ListSortDirection.Ascending;

        /// <summary>
        /// 对象属性集合
        /// </summary>
        private PropertyDescriptorCollection m_PropertyDescriptors = null;

        #region 构造函数
        /// <summary>
        /// 建立一个排序器实例
        /// </summary>
        /// <param name="propDesc">排序属性</param>
        /// <param name="direction">排序方向</param>
        public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
        {
            Initialize();
            m_PropDesc = propDesc;
            m_Direction = direction;
        }

        /// <summary>
        ///建立一个排序器实例
        /// </summary>
        /// <param name="sortCollection">排序字段集合</param>
        public SortComparer(ListSortDescriptionCollection sortCollection)
        {
            Initialize();
            m_SortCollection = sortCollection;
        }

        /// <summary>
        /// 建立一个排序器实例
        /// </summary>
        /// <param name="orderBy">支持像Sql一样的排序子句</param>
        /// <remarks><i>orderBy</i> 格式必须像如下形式:
        /// <para>PropertyName[[ [[ASC]|DESC]][, PropertyName[ [[ASC]|DESC]][,...]]]</para></remarks>
        /// <example><c>list.Sort("Property1, Property2 DESC, Property3 ASC");</c></example>
        public SortComparer(string orderBy)
        {
            Initialize();
            m_SortCollection = ParseOrderBy(orderBy);
        }

        #endregion
        
        #region IComparer<T> Members

        /// <summary>
        /// 比较两个对象
        /// </summary>
        /// <param name="x">对象X</param>
        /// <param name="y">对象Y</param>
        /// <returns>Value is less than zero: <c>x</c> is less than <c>y</c>
        /// <para>Value is equal to zero: <c>x</c> equals <c>y</c></para>
        /// <para>Value is greater than zero: <c>x</c> is greater than <c>y</c></para>
        /// </returns>
        public int Compare(T x, T y)
        {
            if (m_PropDesc != null) //简单排序
            {
                object xValue = m_PropDesc.GetValue(x);
                object yValue = m_PropDesc.GetValue(y);
                return CompareValues(xValue, yValue, m_Direction);
            }
            else if (m_SortCollection != null && m_SortCollection.Count > 0)//复合排序
            {
                return RecursiveCompareInternal(x, y, 0);
            }
            else return 0;
        }
        #endregion

        #region Private Methods

        /// <summary>
        ///比较两个对象
        /// </summary>
        /// <param name="xValue">对象X</param>
        /// <param name="yValue">对象Y</param>
        /// <param name="direction">排序方向</param>
        /// <returns>排序结果</returns>
        private int CompareValues(object xValue, object yValue, ListSortDirection direction)
        {

            int retValue = 0;
            if (xValue != null && yValue == null)
            {
                retValue = 1;
            }
            else if (xValue == null && yValue != null)
            {
                retValue = -1;

            }
            else if (xValue == null && yValue == null)
            {
                retValue = 0;
            }
            else if (xValue is IComparable) // 实现了IComparable,就按此排序
            {
                retValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (yValue is IComparable) //实现了IComparable,就按此排序
            {
                retValue = ((IComparable)yValue).CompareTo(xValue);
            }
            else if (!xValue.Equals(yValue)) // 没有实现排序器，转成字符串排序
            {
                retValue = xValue.ToString().CompareTo(yValue.ToString());
            }
            if (direction == ListSortDirection.Ascending)//排序方向
            {
                return retValue;
            }
            else
            {
                return retValue * -1;
            }
        }

        private int RecursiveCompareInternal(T x, T y, int index)
        {
            if (index >= m_SortCollection.Count)//递归比较结束条件
                return 0; 

            ListSortDescription listSortDesc = m_SortCollection[index];
            object xValue = listSortDesc.PropertyDescriptor.GetValue(x);
            object yValue = listSortDesc.PropertyDescriptor.GetValue(y);

            int retValue = CompareValues(xValue, yValue, listSortDesc.SortDirection);
            if (retValue == 0)
            {
                return RecursiveCompareInternal(x, y, ++index);
            }
            else
            {
                return retValue;
            }
        }

        /// <summary>
        /// 解析orderby字符串到ListSortDescription中
        /// </summary>
        /// <param name="orderBy">类似Sql排序的排序串</param>
        /// <returns></returns>
        private ListSortDescriptionCollection ParseOrderBy(string orderBy)
        {
            if (orderBy == null || orderBy.Length == 0)
                throw new ArgumentNullException("orderBy");

            string[] props = orderBy.Split(',');
            ListSortDescription[] sortProps = new ListSortDescription[props.Length];
            string prop;
            ListSortDirection sortDirection = ListSortDirection.Ascending;

            for (int i = 0; i < props.Length; i++)
            {
                //Default to Ascending
                sortDirection = ListSortDirection.Ascending;
                prop = props[i].Trim();

                if (prop.ToUpper().EndsWith(" DESC"))
                {
                    sortDirection = ListSortDirection.Descending;
                    prop = prop.Substring(0, prop.ToUpper().LastIndexOf(" DESC"));
                }
                else if (prop.ToUpper().EndsWith(" ASC"))
                {
                    prop = prop.Substring(0, prop.ToUpper().LastIndexOf(" ASC"));
                }

                prop = prop.Trim();

                //Get the appropriate descriptor
                PropertyDescriptor propertyDescriptor = m_PropertyDescriptors[prop];

                if (propertyDescriptor == null)
                {
                    throw new ArgumentException(string.Format("The property \"{0}\" is not a valid property.", prop));
                }
                sortProps[i] = new ListSortDescription(propertyDescriptor, sortDirection);

            }

            return new ListSortDescriptionCollection(sortProps);
        }

        /// <summary>
        ///初始化SortCompare
        /// </summary>
        private void Initialize()
        {
            Type instanceType = typeof(T);

            if (!instanceType.IsPublic)
                throw new ArgumentException(string.Format("Type \"{0}\" is not public.", typeof(T).FullName));

            m_PropertyDescriptors = TypeDescriptor.GetProperties(typeof(T));

        }

        #endregion
    }
    #endregion
}
