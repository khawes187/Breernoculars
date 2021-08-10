using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone_Server.Models;

namespace Capstone_Server.Controllers
{
    class BeerService
    {
        private readonly static string API_BASE_URL = "https://api.untappd.com/v4/search/beer?client_id=D9113B090D88E521D913D0E19F3130A11AF32987&client_secret=61C5AC026FA95FD250D5012066CF246D229773AA&q=";
        private readonly IRestClient client = new RestClient();


        
        public List<Beer> GetBeers(string breweryName)
        {
            RestRequest request = new RestRequest(API_BASE_URL + breweryName + "&offset=0&limit=50");
            IRestResponse <ListofBeers> response = client.Get <ListOfBeers> (request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
          
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error message was received: ");
            }

            return response.Data;
        }
    }
}
