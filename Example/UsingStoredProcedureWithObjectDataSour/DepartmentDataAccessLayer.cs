using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsingStoredProcedureWithObjectDataSour
{
    public class Department
    {

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
    public class DepartmentDataAccessLayer
    {

        public static List<Department> GetAllDepartments()
        {
            List<Department> allDepartments= new List<Department>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con= new SqlConnection(CS);

            SqlCommand cmd= new SqlCommand("spGetDepartments", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Department daDepartment= new Department();
                daDepartment.DepartmentId =Convert.ToInt32(rdr["DepartmentId"]);
                daDepartment.DepartmentName = rdr["Name"].ToString();
                allDepartments.Add(daDepartment);
            }
            return allDepartments;
            con.Close();
        } 
    }
}