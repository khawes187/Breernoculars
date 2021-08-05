using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class BeerReviewSqlDAO : IBeerReviewDAO
    {
        private readonly string connectionString;
        public BeerReviewSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<BeerReview> GetBeerReviewsFromBeerId(int beerId)
        {
            List<BeerReview> reviews = new List<BeerReview>();
            BeerReview tempReview = new BeerReview();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT beerReviewId, userId, beerId, rating, reviewBody " +
                        "FROM dbo.UserReviews WHERE beerId = @beerId", conn);
                    cmd.Parameters.AddWithValue("@beerId", beerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tempReview = GetBeerReviewFromReader(reader);
                        reviews.Add(tempReview);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return reviews;
        }

        public void WriteBeerReview(BeerReview review)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.UserReviews (userId, beerId, rating, reviewBody)"
                        + "VALUES(@userId, @beerId, @rating, @reviewBody)", conn);
                    cmd.Parameters.AddWithValue("@userId", review.UserId);
                    cmd.Parameters.AddWithValue("@beerId", review.BeerId);
                    cmd.Parameters.AddWithValue("@rating", review.Rating);
                    cmd.Parameters.AddWithValue("@reviewBody", review.ReviewBody);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private BeerReview GetBeerReviewFromReader(SqlDataReader reader)
        {
            BeerReview review = new BeerReview();
            review.BeerReviewId = Convert.ToInt32(reader["beerReviewId"]);
            review.UserId = Convert.ToInt32(reader["userId"]);
            review.BeerId = Convert.ToInt32(reader["beerId"]);
            review.Rating = Convert.ToDecimal(reader["rating"]);
            review.ReviewBody = Convert.ToString(reader["reviewBody"]);

            return review;
        }
    }
}
