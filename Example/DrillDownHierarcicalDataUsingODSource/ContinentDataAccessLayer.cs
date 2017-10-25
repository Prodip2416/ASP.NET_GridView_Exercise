using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrillDownHierarcicalDataUsingODSource
{
    public class Continent
    {
        public int ContinentId { get; set; }
        public string ContinentName { get; set; }
    }
    public class ContinentDataAccessLayer
    {
        public static List<Continent> GetAllContinents()
        {
            List<Continent> listContinents = new List<Continent>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblContinents", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Continent continent = new Continent();
                    continent.ContinentId = Convert.ToInt32(rdr["ContinentId"]);
                    continent.ContinentName = rdr["ContinentName"].ToString();

                    listContinents.Add(continent);
                }
            }

            return listContinents;
        }
    }
}