using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

namespace Natty.Utility.ToolBox
{
    /// <summary>
    /// ������
    /// </summary>
    public class BindControl
    {
        #region �DataList
        /// <summary>
        /// �DataList
        /// </summary>
        /// <param name="DataScore">����Դ</param>
        /// <param name="DL">DataList�ؼ�</param>
        public virtual void BindDataList(object DataScore,System.Web.UI.WebControls.DataList DL)
        {
            DL.DataSource = DataScore;
            DL.DataBind();
            DL.Dispose();
        }
        #endregion

        #region �GridView
        /// <summary>
        /// �GridView
        /// </summary>
        /// <param name="DataScore">����Դ</param>
        /// <param name="GV">GridView�ؼ�</param>
        public virtual void BindDataList(object DataScore,System.Web.UI.WebControls.GridView GV)
        {
            GV.DataSource = DataScore;
            GV.DataBind();
            GV.Dispose();
        }
        #endregion

        #region �Repeater
        /// <summary>
        /// �Repeater
        /// </summary>
        /// <param name="DataScore">����Դ</param>
        /// <param name="REP">Repeater�ؼ�</param>
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

        #region �DorpDownList
        /// <summary>
        /// �DorpDownList
        /// </summary>
        /// <param name="DataScore">����Դ</param>
        /// <param name="DL">DropdownList�ؼ�</param>
        /// <param name="DataTextField">Item�ı�</param>
        /// <param name="DataValueField">Itemֵ</param>
        public virtual void BindDoprdownList(object DataScore, System.Web.UI.WebControls.ListControl DL, string DataTextField, string DataValueField)
        {
            DL.DataSource = DataScore;
            DL.DataTextField = DataTextField;
            DL.DataValueField = DataValueField;
            DL.DataBind();
            DL.Dispose();
        }

        /// <summary>
        /// ��ö�ٰDorpDownList
        /// </summary>
        /// <param name="EnumType">ö������</param>
        /// <param name="DL">DropdownList�ؼ�</param>
        /// <param name="DataTextField">Item�ı�</param>
        /// <param name="DataValueField">Itemֵ</param>
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
