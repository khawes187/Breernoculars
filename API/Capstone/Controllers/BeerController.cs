using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerDAO BeerDAO;

        public BeerController(IBeerDAO _beerDAO)
        {
            BeerDAO = _beerDAO;
        }

        [HttpGet("brewery{beerBreweryId}")]
        public List<Beer> GetBreweryBeers(int beerBreweryId)
        {
            List<Beer> beerList = BeerDAO.GetBeersFromBreweryId(beerBreweryId);
            return beerList;
        }

        [HttpGet("{beerId}")]
        public Beer GetBeer(int beerId)
        {
            Beer beer = BeerDAO.GetBeer(beerId);
            return beer;
        }

        [HttpPost]
        public void CreateBeer(Beer beer)
        {
            BeerDAO.AddBeer(beer);
        }

        [HttpDelete("{beerId}")]
        public void RemoveBeer(int beerId)
        {
            BeerDAO.DeleteBeer(beerId);
        }


    }
}
