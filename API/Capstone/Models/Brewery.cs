using Capstone.Models;

namespace Capstone.Models
{
    public class Brewery
    {
        public int BreweryId { get; set; }
        public string BreweryName { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string History { get; set; }
        public int BeerListId { get; set; }
    }
}

