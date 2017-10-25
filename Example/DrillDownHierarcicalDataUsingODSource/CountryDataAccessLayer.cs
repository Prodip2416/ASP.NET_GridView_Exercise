using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DrillDownHierarcicalDataUsingODSource
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int ContinentId { get; set; }
    }
    public class CountryDataAccessLayer
    {
        public static List<Country> GetCountriesByContinent(int ContinentId)
        {
            List<Country> listCountries = new List<Country>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblCountries where ContinentId = @ContinentId", con);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@ContinentId";
                parameter.Value = ContinentId;
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Country country = new Country();
                    country.CountryId = Convert.ToInt32(rdr["CountryId"]);
                    country.CountryName = rdr["CountryName"].ToString();
                    country.ContinentId = Convert.ToInt32(rdr["ContinentId"]);

                    listCountries.Add(country);
                }
            }

            return listCountries;
        }
    }
}