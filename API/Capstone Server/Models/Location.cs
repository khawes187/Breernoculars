using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Server.Models
{
    class Location
    {
        public string brewery_city { get; set; }
        public string brewery_state { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}
