using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DisplayingGridViewInGridView
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
    public class EmployeeDataAccessLayer
    {
        public static List<Employee> GetAllEmployees(int DepartmentId)
        {
            List<Employee> listEmployees = new List<Employee>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee6 where DeptId = @DepartmentId", con);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@DepartmentId";
                parameter.Value = DepartmentId;
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.EmployeeName = rdr["Name"].ToString();

                    listEmployees.Add(employee);
                }
            }

            return listEmployees;
        }
    }
}