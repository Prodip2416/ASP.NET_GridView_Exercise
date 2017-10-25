using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NestedGridView
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }

    public class CityDataAccessLayer
    {
        public static List<City> GetCitiesByCountryId(int CountryId)
        {
            List<City> listCities = new List<City>();

            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from tblCities where CountryId = @CountryId", con);
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@CountryId";
                parameter.Value = CountryId;
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    City city = new City();
                    city.CityId = Convert.ToInt32(rdr["CityId"]);
                    city.CityName = rdr["CityName"].ToString();
                    city.CountryId = Convert.ToInt32(rdr["CountryId"]);

                    listCities.Add(city);
                }
            }

            return listCities;
        }
    }
}