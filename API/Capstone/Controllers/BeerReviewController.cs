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
    public class BeerReviewController : ControllerBase
    {
        private readonly IBeerReviewDAO BeerReviewDAO;

        public BeerReviewController(IBeerReviewDAO _beerReviewDAO)
        {
            BeerReviewDAO = _beerReviewDAO;
        }

        [HttpGet("{beerId}")]
        public List<BeerReview> GetBeerReviews(int beerId)
        {
            List<BeerReview> reviews = BeerReviewDAO.GetBeerReviewsFromBeerId(beerId);
            return reviews;
        }

        [HttpPost]
        public void CreateBeerReview(BeerReview review)
        {
            BeerReviewDAO.WriteBeerReview(review);
        }

    }
}
