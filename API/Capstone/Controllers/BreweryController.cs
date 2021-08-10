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
            return rawList;
        }

        [HttpGet("{breweryId}")]
        public ActionResult<Brewery> GetBrewery(int breweryId)
        {
            Brewery brewery = BreweryDAO.GetBreweryByBreweryId(breweryId);
            return brewery;
        }


        [HttpPut("{breweryId}")]
        public void UpdateBreweryController(Brewery brewery, int breweryId)
        {
            BreweryDAO.UpdateBrewery(brewery, breweryId);
        }

        [HttpPost]
        public void CreateBrewery(Brewery brewery, BreweryAddress address)
        {
            int addressId = BreweryAddressDAO.CreateAddress(address);
            //AddressController newAddress = BreweryAddressDAO.addAddress(breewery.address)
            BreweryDAO.AddBrewery(brewery, addressId);
            
        }
    }
}
