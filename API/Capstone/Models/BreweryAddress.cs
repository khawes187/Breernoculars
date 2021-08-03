using Capstone.Models;

namespace Capstone.Models
{
    public class BreweryAddress
    {
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateOrTerritory { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
    }
}
