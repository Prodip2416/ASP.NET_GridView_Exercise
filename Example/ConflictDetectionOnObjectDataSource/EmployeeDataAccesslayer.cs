using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConflictDetectionOnObjectDataSource
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
    }

    public class EmployeeDataAccesslayer
    {
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("select * from tblEmployee", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Employee employee = new Employee();
                employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                employee.EmployeeName = rdr["Name"].ToString();
                employee.Gender = rdr["Gender"].ToString();
                employee.Salary = Convert.ToInt32(rdr["salary"]);
                employees.Add(employee);
            }
            con.Close();
            return employees;
        }

        public static void DeleteEmployee(int original_EmployeeId, string original_Name,
            string original_Gender, string original_City)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string deleteQuery = "DELETE FROM tblEmployee WHERE EmployeeId = @original_EmployeeId " +
                                     "AND Name = @original_Name AND Gender = @original_Gender AND City = @original_City";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                SqlParameter paramEmployeeId = new SqlParameter("@original_EmployeeId", original_EmployeeId);
                cmd.Parameters.Add(paramEmployeeId);
                SqlParameter paramName = new SqlParameter("@original_Name", original_Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@original_Gender", original_Gender);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@original_City", original_City);
                cmd.Parameters.Add(paramCity);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}