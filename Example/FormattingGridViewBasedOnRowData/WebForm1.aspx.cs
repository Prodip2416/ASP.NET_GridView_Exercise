using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormattingGridViewBasedOnRowData
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            //{
            //    Response.Write(ci.Name+" => "+ci.DisplayName+"</br>");
            //}
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //using code OR css file use and itemstyle and header-Style useful nameing....

            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    e.Row.Cells[4].Visible = false;
            //}
          if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int salary = Convert.ToInt32(e.Row.Cells[2].Text);
                string countryCulture = e.Row.Cells[4].Text;
                //e.Row.Cells[4].Visible = false;
                string strFormeted = string.Format(new System.Globalization.CultureInfo(countryCulture), "{0:c}", salary);
                e.Row.Cells[2].Text = strFormeted;
            }
        }
    }
}