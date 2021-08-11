using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Server.Models
{
    class Item
    {
        public int CheckinCount { get; set; }

        public bool HaveHad { get; set; }

        public int YourCount { get; set; }

        public Beer Beer { get; set; }

        public Brewery Brewery { get; set; }


    }
}
