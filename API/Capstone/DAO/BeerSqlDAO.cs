using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class BeerSqlDAO : IBeerDAO
    {
        private readonly string connectionString;
        public BeerSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Beer> GetBeersFromBreweryId(int breweryId)
        {
            List<Beer> returnBeers = new List<Beer>();

            Beer tempBeer = new Beer();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT beerId, beerName, beerType, abv, beerDescription, beerBreweryId, seasonal " +
                        "FROM dbo.Beer WHERE beerBreweryId = @beerBreweryId", conn);
                    cmd.Parameters.AddWithValue("@beerBreweryId", breweryId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tempBeer = GetBeerFromReader(reader);
                        returnBeers.Add(tempBeer);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnBeers;
        }

        public Beer GetBeer(int beerId)
        {
            Beer returnBeer = new Beer();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT beerId, beerName, beerType, abv, beerDescription, beerBreweryId, seasonal " +
                        "FROM dbo.Beer WHERE beer.beerId = @beerId", conn);
                    cmd.Parameters.AddWithValue("@beerId", beerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnBeer = GetBeerFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnBeer;
        }

        public void AddBeer(Beer beer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Beer (beerName, beerType, abv, beerDescription, beerBreweryId, seasonal)"
                        + "VALUES(@beerName, @beerType, @abv, @beerDescription, @beerBreweryId, @seasonal)", conn);
                    cmd.Parameters.AddWithValue("@beerName", beer.BeerName);
                    cmd.Parameters.AddWithValue("@beerType", beer.BeerType);
                    cmd.Parameters.AddWithValue("@abv", beer.ABV);
                    cmd.Parameters.AddWithValue("@beerDescription", beer.BeerDescription);
                    cmd.Parameters.AddWithValue("@beerBreweryId", beer.BeerBreweryId);
                    cmd.Parameters.AddWithValue("@seasonal", beer.Seasonal);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void DeleteBeer(int beerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("DELETE FROM dbo.UserReviews WHERE beerId = @beerId)", conn);
                cmd1.Parameters.AddWithValue("@beerId", beerId);
                SqlCommand cmd2 = new SqlCommand("DELETE FROM dbo.Beer WHERE beerId = @beerId)", conn);
                cmd2.Parameters.AddWithValue("@beerId", beerId);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
        }

        private Beer GetBeerFromReader(SqlDataReader reader)
        {
            Beer beer = new Beer();
            beer.BeerId = Convert.ToInt32(reader["beerId"]);
            beer.BeerName = Convert.ToString(reader["beerName"]);
            beer.BeerType = Convert.ToString(reader["beerType"]);
            beer.ABV = Convert.ToDecimal(reader["abv"]);
            beer.BeerDescription = Convert.ToString(reader["beerDescription"]);
            beer.BeerBreweryId = Convert.ToInt32(reader["beerBreweryId"]);
            beer.Seasonal = Convert.ToString(reader["seasonal"]);

            return beer;
        }

    }

}
