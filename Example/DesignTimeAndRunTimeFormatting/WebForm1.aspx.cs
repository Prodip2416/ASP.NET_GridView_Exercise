using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesignTimeAndRunTimeFormatting
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int salary1 = Convert.ToInt32(e.Row.Cells[2].Text);
                string countryCulture = e.Row.Cells[4].Text;
                string strFormeted = string.Format(new System.Globalization.CultureInfo(countryCulture), "{0:c}", salary1);
                e.Row.Cells[2].Text = strFormeted;

                int salary = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AnnualSalary"));
                if (salary > 7500)
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }

            }
        }
    }
}