using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class BrewerySqlDAO: IBreweryDAO
    {
        private readonly string connectionString;

        public BrewerySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Brewery> GetBreweries()
        {
            List<Brewery> returnBreweries = new List<Brewery>();

            Brewery tempBrewery = new Brewery();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT breweryId, breweryName, (SELECT addressId FROM BreweryAddress WHERE BreweryAddress.addressId = Brewery.breweryAddressId), phoneNumber, website, dateEstablished, history FROM Brewery", conn);
         
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tempBrewery = GetBreweryFromReader(reader);
                        returnBreweries.Add(tempBrewery);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnBreweries;
        }

        private Brewery GetBreweryFromReader(SqlDataReader reader)
        {
            Brewery brewery = new Brewery();
            brewery.BreweryId = Convert.ToInt32(reader["breweryId"]);
            brewery.BreweryName = Convert.ToString(reader["breweryName"]);
            brewery.BreweryAddressId = Convert.ToInt32(reader["breweryAddressId"]);
            brewery.PhoneNumber = Convert.ToString(reader["phoneNumber"]);
            brewery.Website = Convert.ToString(reader["website"]);
            brewery.DateEstablished = Convert.ToString(reader["dateEstablished"]);
            brewery.History = Convert.ToString(reader["history"]);

            return brewery;
        }


    }

}
