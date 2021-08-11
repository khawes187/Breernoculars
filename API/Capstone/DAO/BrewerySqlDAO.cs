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

                    SqlCommand cmd = new SqlCommand("SELECT breweryId, breweryName, breweryAddress, phoneNumber, " +
                        "website, dateEstablished, history, approved FROM Brewery", conn);
         
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
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

        public Brewery GetBreweryByBreweryId(int breweryId)
        {
            Brewery tempBrewery = new Brewery();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT breweryId, breweryName, breweryAddress, phoneNumber, website, dateEstablished, history, approved " +
                        "FROM Brewery WHERE breweryId = @breweryId", conn);
                    cmd.Parameters.AddWithValue("@breweryId", breweryId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tempBrewery = GetBreweryFromReader(reader);

                        return tempBrewery;
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return tempBrewery;
        }

        public void AddBrewery(Brewery brewery)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // need to change breweryAddressId
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Brewery (breweryName, breweryAddress, phoneNumber, website, breweryUrl " +
                        "dateEstablished, history, approved) VALUES(@breweryName, @breweryAddress, @phoneNumber, @website, @dateEstablished, @history, @approved, @BreweryUrl)", conn);
                    cmd.Parameters.AddWithValue("@breweryName", brewery.BreweryName);
                    cmd.Parameters.AddWithValue("@breweryAddress", brewery.BreweryAddress);
                    cmd.Parameters.AddWithValue("@phoneNumber", brewery.PhoneNumber);
                    cmd.Parameters.AddWithValue("@website", brewery.Website);
                    cmd.Parameters.AddWithValue("@dateEstablished", brewery.DateEstablished);
                    cmd.Parameters.AddWithValue("@history", brewery.History);
                    cmd.Parameters.AddWithValue("@approved", brewery.Approved);
                    cmd.Parameters.AddWithValue("@breweryUrl", brewery.BreweryUrl);



                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

        }

        public void UpdateBrewery(Brewery brewery, int breweryId) // WHEN BREWER UPDATES A BREWERY, HAVE FIELDS IN VUE POPULATE WITH ORIGINAL VALUES
        {                                          // SO THAT THINGS THAT DON'T NEED TO BE OVERWRITTEN AREN'T CHANGED?
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE dbo.Brewery SET breweryName = @breweryName, breweryAddress = @breweryAddress," +
                        " phoneNumber = @phoneNumber, website = @website, dateEstablished = @dateEstablished, " +
                        "history = @history WHERE breweryId = @breweryId", conn);
                    cmd.Parameters.AddWithValue("@breweryId", breweryId);
                    cmd.Parameters.AddWithValue("@breweryName", brewery.BreweryName);
                    cmd.Parameters.AddWithValue("@breweryAddress", brewery.BreweryAddress);
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
            brewery.BreweryAddress = Convert.ToString(reader["breweryAddress"]);
            brewery.PhoneNumber = Convert.ToString(reader["phoneNumber"]);
            brewery.Website = Convert.ToString(reader["website"]);
            brewery.DateEstablished = Convert.ToString(reader["dateEstablished"]);
            brewery.History = Convert.ToString(reader["history"]);
            brewery.Approved = Convert.ToBoolean(reader["approved"]);
            brewery.BreweryUrl= Convert.ToString(reader["breweryUrl"]);


            return brewery;
        }


    }

}
