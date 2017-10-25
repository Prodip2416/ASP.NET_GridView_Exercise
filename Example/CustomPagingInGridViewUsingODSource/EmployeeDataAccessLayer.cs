using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CustomPagingInGridViewUsingODSource
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
        public static List<Employee> GetEmployees(int startRowIndex, int maximumRows)
        {
            List<Employee> listEmployees = new List<Employee>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees4", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramStartIndex = new SqlParameter();
                paramStartIndex.ParameterName = "@StartIndex";
                paramStartIndex.Value = startRowIndex;
                cmd.Parameters.Add(paramStartIndex);

                SqlParameter paramMaximumRows = new SqlParameter();
                paramMaximumRows.ParameterName = "@MaximumRows";
                paramMaximumRows.Value = maximumRows;
                cmd.Parameters.Add(paramMaximumRows);

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
        public static int GetTotalCount()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select Count(*) from Employee4", con);

                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}