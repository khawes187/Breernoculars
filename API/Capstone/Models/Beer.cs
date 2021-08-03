using Capstone.Models;

namespace Capstone.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public string BeerType { get; set; }
        public int ABV { get; set; }
        public string BeerDescription { get; set; }
        public string BeerBreweryId { get; set; }
        public string Seasonal { get; set; }

    }
}
