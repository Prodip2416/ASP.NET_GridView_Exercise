using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsingStoredProcedureWithObjectDataSour
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }
    public class EmployeeDataAccessLayer
    {
        public static List<Employee> GetAllEmployees(int departmentId)
        {
            List<Employee> allEmployees= new List<Employee>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con= new SqlConnection(CS);
            SqlCommand cmd= new SqlCommand("spGetEmployeesByDepartmentId", con);
            con.Open();
            cmd.CommandType=CommandType.StoredProcedure;
            SqlParameter param=new SqlParameter();
            cmd.Parameters.AddWithValue("@DepartmentId", departmentId);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Employee allEmployee=new Employee();
                allEmployee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                allEmployee.EmployeeName = rdr["EmployeeName"].ToString();
                allEmployee.DepartmentName = rdr["DepartmentName"].ToString();
              allEmployees.Add(allEmployee);
            }
            return allEmployees;
        } 
    }
}