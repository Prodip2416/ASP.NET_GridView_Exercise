using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI.WebControls;

namespace ObjectDataSource
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }   
    }
    public class ProductDataAcessLayer
    {
        public static List<Product> GetAllProduct()
        {
            List<Product>listItem= new List<Product>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con= new SqlConnection(CS);
            SqlCommand cmd= new SqlCommand("select * from Products", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Product product= new Product();
                product.Id = Convert.ToInt32(rdr["Id"]);
                product.Name = rdr["Name"].ToString();
                product.Description = rdr["Description"].ToString();
                listItem.Add(product);
            }
            return listItem;
        }
    }
}