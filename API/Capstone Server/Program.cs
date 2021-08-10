using System;
using Capstone_Server.Controllers;
using Capstone_Server.Models;
using RestSharp;

namespace Capstone_Server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            BeerService beer = new BeerService();
            Beer test = new Beer();
            beer.GetBeers("Saucy Brew Works");
        
    
        }
    }
}
