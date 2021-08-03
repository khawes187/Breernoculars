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
        private readonly IBreweryAddressDAO BreweryAddressDAO;

        public BreweryController(IBreweryDAO _breweryDAO, IBreweryAddressDAO _breweryAddressDAO)
        {
            BreweryAddressDAO = _breweryAddressDAO;
            BreweryDAO = _breweryDAO;
        }
    
        [HttpGet]
        public ActionResult<List<Brewery>> SendBreweries()
        {
            List<Brewery> rawList = BreweryDAO.GetBreweries();
            List<Brewery> finalList = new List<Brewery>();


            foreach (Brewery brewery in rawList)
            {
                BreweryAddress address = BreweryAddressDAO.GetAddress(brewery.BreweryAddressId);

                brewery.BreweryAddressId = Convert.ToString(address);

                finalList.Add(brewery);
            }

            return finalList;
        
        }
    
    
    
    
    }
}
