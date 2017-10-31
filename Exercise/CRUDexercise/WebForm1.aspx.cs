using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDexercise
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue
                = ((TextBox) GridView1.FooterRow.FindControl("txtName")).Text;

            SqlDataSource1.InsertParameters["Gender"].DefaultValue =
                ((DropDownList) GridView1.FooterRow.FindControl("ddlGender")).SelectedValue;

            SqlDataSource1.InsertParameters["City"].DefaultValue =
                ((TextBox) GridView1.FooterRow.FindControl("txtCity")).Text;

            SqlDataSource1.Insert();
        }
    }
}