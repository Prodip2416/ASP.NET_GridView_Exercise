using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace DeleteingDataUsingObjectDataSource
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
    }
    public class EmployeeDataAccessLayer
    {
        public static List<Employee> GetAllEmployees()
        {
           List<Employee> employees= new List<Employee>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con= new SqlConnection(CS);
            SqlCommand cmd= new SqlCommand("select * from tblEmployee", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Employee employee= new Employee();
                employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                employee.EmployeeName = rdr["Name"].ToString();
                employee.Gender = rdr["Gender"].ToString();
                employee.Salary = Convert.ToInt32(rdr["salary"]);
                employees.Add(employee);
            }
            con.Close();
            return employees;
        }

        public void DeletedEmployee(int EmployeeId)
        {
            List<Employee> employees = new List<Employee>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("delete tblEmployee where EmployeeId=@EmployeeId", con);
            SqlParameter param= new SqlParameter();
            con.Open();
            cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}