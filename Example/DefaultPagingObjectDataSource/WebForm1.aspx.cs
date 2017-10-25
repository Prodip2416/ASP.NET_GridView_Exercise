using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DefaultPagingObjectDataSource
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            Label1.Text = "Displaying page " + (GridView1.PageIndex + 1).ToString() + " of " +
                          GridView1.PageCount.ToString();
        }
    }
}