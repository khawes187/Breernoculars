using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Server.Models
{
    class ListOfBeers
    {
        public string message { get; set; }
        public List<string> BeerName { get; set; }
        public string BeerLabel { get; set; }
        public decimal ABV { get; set; }
        public string BeerSlug { get; set; }
        public int BeerIbu { get; set; }
        public string BeerDescription { get; set; }
        public string CreatedAt { get; set; }
        public string BeerStyle { get; set; }
        public string InProduction { get; set; }
        public string AuthRating { get; set; }
        public string WishList { get; set; }
    }
}
