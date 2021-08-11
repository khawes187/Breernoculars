import axios from 'axios';

export default {

  getBeer(breweryId, beerId) {
    return axios.get(`/brewery/${breweryId}/${beerId}`);
  },

  postBeer(beer) {  
    return axios.post('/brewery', beer);
  },

  deleteBeer(beerId) {  
    return axios.delete(`/beer/${beerId}`);
  },

  getBeerReviews(beerId) {
    return axios.get(`/beerReview/${beerId}`)
  },

  postBeerReview(review) {
    return axios.post(`/beerReview`, review)
  }
}