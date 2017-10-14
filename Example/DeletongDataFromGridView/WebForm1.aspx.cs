using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeletongDataFromGridView
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control cntrl = e.Row.Cells[0].Controls[0];
                if (cntrl is LinkButton)
                {
                    ((LinkButton) cntrl).OnClientClick = "return confirm('Are u sure u want to delete? This cannot bd undone.')";
                }
            }
        }
    }
}