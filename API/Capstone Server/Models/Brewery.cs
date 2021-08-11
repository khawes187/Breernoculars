using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Server.Models
{
    class Brewery
    { 
        public double brewery_id { get; set; }
        public string brewery_name { get; set; }
        public string brewery_slug { get; set; }
        public string brewery_page_url { get; set; }
        public string brewery_type { get; set; }
        public string brewery_label { get; set; }
        public string country_name { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public bool brewery_active { get; set; }

    }
}
