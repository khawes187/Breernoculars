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

                    SqlCommand cmd = new SqlCommand("SELECT breweryId, breweryName, breweryAddressId, phoneNumber, website, dateEstablished, history FROM Brewery", conn);
         
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

        public void AddBrewery(Brewery brewery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Brewery (breweryName, breweryAddressId, phoneNumber, website, " +
                        "dateEstablished, history) VALUES(@beerName, @beerType, @abv, @beerDescription, @beerBreweryId, @seasonal)", conn);
                    cmd.Parameters.AddWithValue("@breweryName", brewery.BreweryName);
                    cmd.Parameters.AddWithValue("@breweryAddressId", brewery.BreweryAddressId);
                    cmd.Parameters.AddWithValue("@phoneNumber", brewery.PhoneNumber);
                    cmd.Parameters.AddWithValue("@website", brewery.Website);
                    cmd.Parameters.AddWithValue("@dateEstablished", brewery.DateEstablished);
                    cmd.Parameters.AddWithValue("@history", brewery.History);
                    

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }

        public void UpdateBrewery(Brewery brewery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE dbo.Brewery SET breweryName = @breweryName, breweryAddressId = " +
                        "@breweryAddressId, phoneNumber = @phoneNumber, website = @website, dateEstablished = @dateEstablished, " +
                        "history = @history)", conn);
                    cmd.Parameters.AddWithValue("@breweryName", brewery.BreweryName);
                    cmd.Parameters.AddWithValue("@breweryAddressId", brewery.BreweryAddressId);
                    cmd.Parameters.AddWithValue("@phoneNumber", brewery.PhoneNumber);
                    cmd.Parameters.AddWithValue("@website", brewery.Website);
                    cmd.Parameters.AddWithValue("@dateEstablished", brewery.DateEstablished);
                    cmd.Parameters.AddWithValue("@history", brewery.History);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

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
