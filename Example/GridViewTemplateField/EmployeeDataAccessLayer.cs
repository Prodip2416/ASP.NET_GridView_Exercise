using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EditUpdatingOnObjectDataSource
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }

    public class EmployeeDataAccessLayer
    {
        public static void UpdateEmployee(int original_EmployeeId, string original_Name, string original_Gender, string original_City, string Name, string Gender, string City)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Update Employee4 SET Name = @Name,  " +
                    "Gender = @Gender, City = @City WHERE EmployeeId = @original_EmployeeId " +
                    "AND Name = @original_Name AND Gender = @original_Gender AND City = @original_City";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramOriginalEmployeeId = new SqlParameter("@original_EmployeeId", original_EmployeeId);
                cmd.Parameters.Add(paramOriginalEmployeeId);
                SqlParameter paramOriginalName = new SqlParameter("@original_Name", original_Name);
                cmd.Parameters.Add(paramOriginalName);
                SqlParameter paramOriginalGender = new SqlParameter("@original_Gender", original_Gender);
                cmd.Parameters.Add(paramOriginalGender);
                SqlParameter paramOriginalCity = new SqlParameter("@original_City", original_City);
                cmd.Parameters.Add(paramOriginalCity);
                SqlParameter paramName = new SqlParameter("@Name", Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@City", City);
                cmd.Parameters.Add(paramCity);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listEmployees = new List<Employee>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee4", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                   employee.City = rdr["City"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }

    }
}