using Capstone.Models;

namespace Capstone.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public string BeerType { get; set; }
        public decimal ABV { get; set; }
        public string BeerDescription { get; set; }
        public int BeerBreweryId { get; set; }
        public string Seasonal { get; set; }

    }
}
