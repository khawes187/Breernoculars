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
    public class AddressController : Controller
    {
        private readonly IBreweryAddressDAO BreweryAddressDAO;

        public AddressController(IBreweryAddressDAO _breweryAddressDAO)
        {
            BreweryAddressDAO = _breweryAddressDAO;
        }

        [HttpGet("{breweryAddressId}")]
        public BreweryAddress GetBreweryAddress(int breweryAddressId)
        {
            BreweryAddress address = BreweryAddressDAO.GetAddress(breweryAddressId);
            return address;
        }

        [HttpPost]
        public void CreateBreweryAddress(BreweryAddress address)
        {
            BreweryAddressDAO.CreateAddress(address);
        }

    }
}
