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

        public List<BreweryAddress> GetBreweryAddresses()
        {
            List<BreweryAddress> breweryAddresses = new List<BreweryAddress>();

            BreweryAddress tempBreweryAddress = new BreweryAddress();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT addressId, streetAddress, city, stateOrTerritory, country, postalCode FROM BreweryAddress", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tempBreweryAddress = GetBreweryAddressFromReader(reader);
                        breweryAddresses.Add(tempBreweryAddress);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return breweryAddresses;
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

        public int CreateAddress(BreweryAddress address)
        {
            try
            {
                int addressId;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.BreweryAddress (streetAddress, city, stateOrTerritory, " +
                        "country, postalCode) OUTPUT INSERTED.addressId VALUES (@streetAddress, @city, @stateOrTerritory, @country, @postalCode)", conn);
                    cmd.Parameters.AddWithValue("@streetAddress", address.StreetAddress);
                    cmd.Parameters.AddWithValue("@city", address.City);
                    cmd.Parameters.AddWithValue("@stateOrTerritory", address.StateOrTerritory);
                    cmd.Parameters.AddWithValue("@country", address.Country);
                    cmd.Parameters.AddWithValue("@postalCode", address.PostalCode);

                    addressId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return addressId;
            }
            catch (SqlException)
            {
                throw;
            }

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
