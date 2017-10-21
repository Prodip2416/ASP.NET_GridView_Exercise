using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InsertUpdateDeleteUsingGridView
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbInsert_OnClick(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue =
                ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;

            SqlDataSource1.InsertParameters["Gender"].DefaultValue =
                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList2")).SelectedValue;
            SqlDataSource1.InsertParameters["City"].DefaultValue =
                ((TextBox) GridView1.FooterRow.FindControl("txtcity")).Text;

            SqlDataSource1.Insert();
        }
    }
}