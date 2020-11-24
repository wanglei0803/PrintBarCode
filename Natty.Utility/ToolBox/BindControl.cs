using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// 绑定数据
    /// </summary>
    public class BindControl
    {
        #region 邦定DataList
        /// <summary>
        /// 邦定DataList
        /// </summary>
        /// <param name="DataScore">数据源</param>
        /// <param name="DL">DataList控件</param>
        public virtual void BindDataList(object DataScore,System.Web.UI.WebControls.DataList DL)
        {
            DL.DataSource = DataScore;
            DL.DataBind();
            DL.Dispose();
        }
        #endregion

        #region 邦定GridView
        /// <summary>
        /// 邦定GridView
        /// </summary>
        /// <param name="DataScore">数据源</param>
        /// <param name="GV">GridView控件</param>
        public virtual void BindDataList(object DataScore,System.Web.UI.WebControls.GridView GV)
        {
            GV.DataSource = DataScore;
            GV.DataBind();
            GV.Dispose();
        }
        #endregion

        #region 邦定Repeater
        /// <summary>
        /// 邦定Repeater
        /// </summary>
        /// <param name="DataScore">数据源</param>
        /// <param name="REP">Repeater控件</param>
        public virtual void BindRepeater(Object DataScore, System.Web.UI.WebControls.Repeater REP)
        {
            if(REP != null)
            {
                REP.DataSource = DataScore;
                REP.DataBind();
                REP.Dispose();
            }
        }
        #endregion

        #region 邦定DorpDownList
        /// <summary>
        /// 邦定DorpDownList
        /// </summary>
        /// <param name="DataScore">数据源</param>
        /// <param name="DL">DropdownList控件</param>
        /// <param name="DataTextField">Item文本</param>
        /// <param name="DataValueField">Item值</param>
        public virtual void BindDoprdownList(object DataScore, System.Web.UI.WebControls.ListControl DL, string DataTextField, string DataValueField)
        {
            DL.DataSource = DataScore;
            DL.DataTextField = DataTextField;
            DL.DataValueField = DataValueField;
            DL.DataBind();
            DL.Dispose();
        }

        /// <summary>
        /// 用枚举邦定DorpDownList
        /// </summary>
        /// <param name="EnumType">枚举类型</param>
        /// <param name="DL">DropdownList控件</param>
        /// <param name="DataTextField">Item文本</param>
        /// <param name="DataValueField">Item值</param>
        public virtual void BindDoprdownList(Type EnumType, System.Web.UI.WebControls.ListControl DL)
        {
            ArrayList List = new ArrayList();
            foreach (int i in Enum.GetValues(EnumType))
            {
                ListItem listitem = new ListItem(Enum.GetName(EnumType, i), i.ToString());
                List.Add(listitem);
            }
            DL.DataSource = List;
            DL.DataTextField = "text";
            DL.DataValueField = "value";
            DL.DataBind();
            DL.Dispose();
        }
        #endregion
    }
}
