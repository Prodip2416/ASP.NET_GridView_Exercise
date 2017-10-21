using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsertUpdateDeleteUningObjectDataSourc
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
        public static List<Employee> GetAllEmployees()
        {
            List<Employee>employees=new List<Employee>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con= new SqlConnection(CS);
            SqlCommand cmd= new SqlCommand("select * from Employee4",con);
            con.Open();
            SqlDataReader rdr= cmd.ExecuteReader();
            while (rdr.Read())
            {
                Employee emp= new Employee();
                emp.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                emp.Name = rdr["Name"].ToString();
                emp.Gender = rdr["Gender"].ToString();
                emp.City = rdr["City"].ToString();
                employees.Add(emp);
            }
            return employees;
        }

        public static void DeleteEmployee(int empDelete)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con= new SqlConnection(CS);
            SqlCommand cmd= new SqlCommand("delete from Employee4 where EmployeeId=@EmployeeId",con);
            //SqlParameter param= new SqlParameter();
            cmd.Parameters.AddWithValue("@EmployeeId", empDelete);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static int UpdateEmployee(int EmployeeId, string Name, string Gender, string City)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Update Employee4 SET Name = @Name,  " +
                    "Gender = @Gender, City = @City WHERE EmployeeId = @EmployeeId";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramOriginalEmployeeId = new
                    SqlParameter("@EmployeeId", EmployeeId);
                cmd.Parameters.Add(paramOriginalEmployeeId);
                SqlParameter paramName = new SqlParameter("@Name", Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@City", City);
                cmd.Parameters.Add(paramCity);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int InsertEmployee(string Name, string Gender, string City)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string updateQuery = "Insert into Employee4 (Name, Gender, City)" +
                    " values (@Name, @Gender, @City)";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                SqlParameter paramName = new SqlParameter("@Name", Name);
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter("@Gender", Gender);
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter("@City", City);
                cmd.Parameters.Add(paramCity);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}