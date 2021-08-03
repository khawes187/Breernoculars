using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    interface IBeerDAO
    {
        List<Beer> GetBeersFromBreweryId(int breweryId);

        Beer GetBeer(int beerId);

        void AddBeer(Beer beer);

        void DeleteBeer(int beerId);
    }
}
