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

                    SqlCommand cmd = new SqlCommand("SELECT breweryId, BreweryName, (SELECT addressId FROM BreweryAddress WHERE BreweryAddress.addressId = Brewery.addressId), phoneNumber, website, history, (SELECT beerId FROM Beer WHERE Beer.beerId = Brewery.beerId) FROM Brewery", conn);
         
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
            brewery.AddressId = Convert.ToInt32(reader["addressId"]);
            brewery.PhoneNumber = Convert.ToString(reader["phoneNumber"]);
            brewery.Website = Convert.ToString(reader["website"]);
            brewery.History = Convert.ToString(reader["history"]);
            brewery.BeerListId = Convert.ToInt32(reader["beerListId"]);

            return brewery;
        }


    }

}
