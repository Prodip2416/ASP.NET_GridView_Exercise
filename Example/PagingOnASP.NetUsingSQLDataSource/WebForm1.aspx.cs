using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PagingOnASP.NetUsingSQLDataSource
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView2_PreRender(object sender, EventArgs e)
        {
            Label1.Text = "Displaying Page " + (GridView2.PageIndex + 1).ToString()
        + " of " + GridView2.PageCount.ToString();
        }
    }
}