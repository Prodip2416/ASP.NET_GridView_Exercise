using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsingObjectDataSorceWithDetaileView
{
    public class EmployeeBasic
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
    }

    public class Employee : EmployeeBasic
    {
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public int Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string MaritalStatus { get; set; }
    }
    public class EmployeeDataAccesslayer
    {
        public static List<EmployeeBasic> GetAllEmployeesBasicDetails()
        {
            List<EmployeeBasic> listEmployees = new List<EmployeeBasic>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new
                    SqlCommand("Select Id, FirstName, City from EmployeeDetailes", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeBasic employeeBasic = new EmployeeBasic();
                    employeeBasic.Id = Convert.ToInt32(rdr["Id"]);
                    employeeBasic.FirstName = rdr["FirstName"].ToString();
                    employeeBasic.City = rdr["City"].ToString();

                    listEmployees.Add(employeeBasic);
                }
            }

            return listEmployees;
        }
        public static Employee GetAllEmployeesFullDetailsById(int Id)
        {
            Employee employee = new Employee();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new
                    SqlCommand("Select * from EmployeeDetailes where Id = @Id", con);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = Id;
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    employee.Country = rdr["Country"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.DateOfJoining = Convert.ToDateTime(rdr["DateOfJoining"]);
                    employee.MaritalStatus = rdr["MaritalStatus"].ToString();
                }
            }

            return employee;
        }
    }
}

