using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IBreweryAddressDAO
    {
         List<BreweryAddress> GetBreweryAddresses();

         BreweryAddress GetAddress(int addressId);

         int CreateAddress(BreweryAddress address);
    }
}
