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

                    SqlCommand cmd = new SqlCommand("SELECT addressId, streetAddress, city, stateOrTerritoy, county, postalCode FROM BreweryAddress WHERE addressId = @addressId", conn);
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
            breweryAddress.AddressId = Convert.ToInt32(reader["breweryId"]);
            breweryAddress.StreetAddress = Convert.ToString(reader["breweryName"]);
            breweryAddress.City = Convert.ToString(reader["addressId"]);
            breweryAddress.StateOrTerritory = Convert.ToString(reader["phoneNumber"]);
            breweryAddress.County = Convert.ToString(reader["website"]);
            breweryAddress.PostalCode = Convert.ToString(reader["history"]);

            return breweryAddress;
        }
    }
}
