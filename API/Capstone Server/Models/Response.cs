using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Server.Models
{
    class Response
    {
        public string message { get; set; }
        public decimal time_taken { get; set; }
        public int brewery_id {get; set;}
        public string search_type { get; set; }
        public int type_id { get; set; }
        public int search_version { get; set; }
        public int found { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public string term { get; set; }
        public string parsed_term { get; set; }
        public Beers Beers { get; set; }
    }
}
