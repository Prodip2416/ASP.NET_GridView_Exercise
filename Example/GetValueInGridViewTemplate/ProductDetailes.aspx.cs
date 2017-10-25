using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetValueInGridViewTemplate
{
    public partial class ProductDetailes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string productId = Request.QueryString["ID"];

                if (productId == null)
                {
                    Response.Redirect("Products.aspx");
                }

                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetProductDetailsByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("@ID", productId);
                    cmd.Parameters.Add(parameter);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            lblID.Text = rdr["ID"].ToString();
                            lblName.Text = rdr["Name"].ToString();
                            lblPrice.Text = rdr["Price"].ToString();
                            lblColor.Text = rdr["Color"].ToString();
                            lblSize.Text = rdr["Size"].ToString();
                            lblWeight.Text = rdr["Weight"].ToString();
                            lblQuantityInStock.Text = rdr["QuantityInStock"].ToString();
                            lblDiscontinued.Text = rdr["Discontinued"].ToString();
                            lblSupplier.Text = rdr["Supplier"].ToString();
                        }
                    }
                }
            }
        }
    }

}