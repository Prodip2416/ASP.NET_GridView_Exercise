using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SortingGridViewWithOutDataSource
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees("EmployeeId");
                GridView1.DataBind();
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string strSortDirection =
        e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";

            GridView1.DataSource = EmployeeDataAccessLayer.GetAllEmployees
                (e.SortExpression + " " + strSortDirection);
            GridView1.DataBind();
        }
    }
}