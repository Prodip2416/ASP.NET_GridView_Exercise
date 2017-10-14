using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConflictDetectionProperty
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            lblMessage.Visible = true;
            if (e.AffectedRows > 0)
            {
                lblMessage.Text="Employee Id Is : \""+e.Keys[0].ToString()+"\"Deleted";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMessage.Text = "Employee Id Is : \"" + e.Keys[0].ToString() + "\"not Deleted. Data Can be conflict.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}