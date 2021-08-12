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
    public class BreweryController : ControllerBase
    {
        private readonly IBreweryDAO BreweryDAO;
        

        public BreweryController(IBreweryDAO _breweryDAO)
        {           
            BreweryDAO = _breweryDAO;
        }

        [HttpGet]
        public ActionResult<List<Brewery>> SendBreweries()
        {
            List<Brewery> rawList = BreweryDAO.GetBreweries();
            return rawList;
        }

        [HttpGet("{breweryId}")]
        public ActionResult<Brewery> GetBrewery(int breweryId)
        {
            Brewery brewery = BreweryDAO.GetBreweryByBreweryId(breweryId);
            return brewery;
        }


        [HttpPut("{breweryId}")]
        public void UpdateBreweryController(Brewery brewery)
        {
            BreweryDAO.UpdateBrewery(brewery);
        }
        
        
        [HttpPost]
        public void CreateBrewery(Brewery brewery)
        {         
            BreweryDAO.AddBrewery(brewery);
            
        }
    }
}
