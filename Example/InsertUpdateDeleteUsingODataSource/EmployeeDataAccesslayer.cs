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

        public static void InsertEmployee(string firstName, string lastName,
                 string city, string gender, DateTime dateOfBirth, string country,
                 int salary, DateTime dateOfJoining, string maritalStatus)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string insertQuery = "Insert into EmployeeDetailes values (@FirstName, " +
                    "@LastName, @City, @Gender, @DateOfBirth, @Country, @Salary, " +
                    "@DateOfJoining, @MaritalStatus)";

                SqlCommand cmd = new SqlCommand(insertQuery, con);

                #region Parameters

                SqlParameter parameter_FirstName = new SqlParameter();
                parameter_FirstName.ParameterName = "@FirstName";
                parameter_FirstName.Value = firstName;
                cmd.Parameters.Add(parameter_FirstName);

                SqlParameter parameter_LastName = new SqlParameter();
                parameter_LastName.ParameterName = "@LastName";
                parameter_LastName.Value = lastName;
                cmd.Parameters.Add(parameter_LastName);

                SqlParameter parameter_city = new SqlParameter();
                parameter_city.ParameterName = "@City";
                parameter_city.Value = city;
                cmd.Parameters.Add(parameter_city);

                SqlParameter parameter_Gender = new SqlParameter();
                parameter_Gender.ParameterName = "@Gender";
                parameter_Gender.Value = gender;
                cmd.Parameters.Add(parameter_Gender);

                SqlParameter parameter_DateOfBirth = new SqlParameter();
                parameter_DateOfBirth.ParameterName = "@DateOfBirth";
                parameter_DateOfBirth.Value = dateOfBirth;
                cmd.Parameters.Add(parameter_DateOfBirth);

                SqlParameter parameter_Country = new SqlParameter();
                parameter_Country.ParameterName = "@Country";
                parameter_Country.Value = country;
                cmd.Parameters.Add(parameter_Country);

                SqlParameter parameter_Salary = new SqlParameter();
                parameter_Salary.ParameterName = "@Salary";
                parameter_Salary.Value = salary;
                cmd.Parameters.Add(parameter_Salary);

                SqlParameter parameter_DateOfJoining = new SqlParameter();
                parameter_DateOfJoining.ParameterName = "@DateOfJoining";
                parameter_DateOfJoining.Value = dateOfJoining;
                cmd.Parameters.Add(parameter_DateOfJoining);

                SqlParameter parameter_MaritalStatus = new SqlParameter();
                parameter_MaritalStatus.ParameterName = "@MaritalStatus";
                parameter_MaritalStatus.Value = maritalStatus;
                cmd.Parameters.Add(parameter_MaritalStatus);

                #endregion

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateEmployee(int id, string firstName, string lastName,
              string city, string gender, DateTime dateOfBirth, string country,
              int salary, DateTime dateOfJoining, string maritalStatus)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Update EmployeeDetailes set FirstName = @FirstName, " +
                    "LastName = @LastName, City = @City, Gender = @Gender, " +
                    "DateOfBirth = @DateOfBirth, Country = @Country, Salary = @Salary," +
                    "DateOfJoining = @DateOfJoining, MaritalStatus = @MaritalStatus where Id = @Id";

                SqlCommand cmd = new SqlCommand(updateQuery, con);

                #region Parameters

                SqlParameter parameter_Id = new SqlParameter();
                parameter_Id.ParameterName = "@Id";
                parameter_Id.Value = id;
                cmd.Parameters.Add(parameter_Id);

                SqlParameter parameter_FirstName = new SqlParameter();
                parameter_FirstName.ParameterName = "@FirstName";
                parameter_FirstName.Value = firstName;
                cmd.Parameters.Add(parameter_FirstName);

                SqlParameter parameter_LastName = new SqlParameter();
                parameter_LastName.ParameterName = "@LastName";
                parameter_LastName.Value = lastName;
                cmd.Parameters.Add(parameter_LastName);

                SqlParameter parameter_city = new SqlParameter();
                parameter_city.ParameterName = "@City";
                parameter_city.Value = city;
                cmd.Parameters.Add(parameter_city);

                SqlParameter parameter_Gender = new SqlParameter();
                parameter_Gender.ParameterName = "@Gender";
                parameter_Gender.Value = gender;
                cmd.Parameters.Add(parameter_Gender);

                SqlParameter parameter_DateOfBirth = new SqlParameter();
                parameter_DateOfBirth.ParameterName = "@DateOfBirth";
                parameter_DateOfBirth.Value = dateOfBirth;
                cmd.Parameters.Add(parameter_DateOfBirth);

                SqlParameter parameter_Country = new SqlParameter();
                parameter_Country.ParameterName = "@Country";
                parameter_Country.Value = country;
                cmd.Parameters.Add(parameter_Country);

                SqlParameter parameter_Salary = new SqlParameter();
                parameter_Salary.ParameterName = "@Salary";
                parameter_Salary.Value = salary;
                cmd.Parameters.Add(parameter_Salary);

                SqlParameter parameter_DateOfJoining = new SqlParameter();
                parameter_DateOfJoining.ParameterName = "@DateOfJoining";
                parameter_DateOfJoining.Value = dateOfJoining;
                cmd.Parameters.Add(parameter_DateOfJoining);

                SqlParameter parameter_MaritalStatus = new SqlParameter();
                parameter_MaritalStatus.ParameterName = "@MaritalStatus";
                parameter_MaritalStatus.Value = maritalStatus;
                cmd.Parameters.Add(parameter_MaritalStatus);

                #endregion

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteEmployee(int id)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("delete from EmployeeDetailes where Id = @Id", con);

                SqlParameter parameter_Id = new SqlParameter();
                parameter_Id.ParameterName = "@Id";
                parameter_Id.Value = id;
                cmd.Parameters.Add(parameter_Id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

