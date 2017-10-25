using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SortingDataUsingObjectDataSource
{
    public class EmployeeDataAccessLayer
    {
        public static DataSet GetAllEmployees()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblEmployee", con);

                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
        }
    }
}