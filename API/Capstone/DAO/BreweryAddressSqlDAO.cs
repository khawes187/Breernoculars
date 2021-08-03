using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class BreweryAddressSqlDAO : IBreweryAddressDAO
    {
        private readonly string connectionString;

        public BreweryAddressSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public BreweryAddress GetAddress(int addressId)
        {
            BreweryAddress returnBreweryAddress = new BreweryAddress();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT addressId, streetAddress, city, stateOrTerritory, country, postalCode FROM BreweryAddress WHERE addressId = @addressId", conn);
                    cmd.Parameters.AddWithValue("@addressId", addressId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnBreweryAddress = GetBreweryAddressFromReader(reader);
                        
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnBreweryAddress;
        }

        private BreweryAddress GetBreweryAddressFromReader(SqlDataReader reader)
        {
            BreweryAddress breweryAddress = new BreweryAddress();
            breweryAddress.AddressId = Convert.ToInt32(reader["addressId"]);
            breweryAddress.StreetAddress = Convert.ToString(reader["streetAddress"]);
            breweryAddress.City = Convert.ToString(reader["city"]);
            breweryAddress.StateOrTerritory = Convert.ToString(reader["stateOrTerritory"]);
            breweryAddress.Country = Convert.ToString(reader["country"]);
            breweryAddress.PostalCode = Convert.ToString(reader["postalCode"]);

            return breweryAddress;
        }
    }
}
