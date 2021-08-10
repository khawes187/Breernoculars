import axios from 'axios';

export default {

  getBeer(beerId) {
    return axios.get(`/brewery/${beerId}`);
  },

  postBeer() {  
    return axios.post('/brewery');
  },

  deleteBeer(beerId) {  
    return axios.delete(`/beer/${beerId}`);
  },

  getBeerReviews(beerId) {
    return axios.get(`/beerReview/${beerId}`)
  },
  postBeerReview() {
    return axios.post(`/beerReview`)
  }
}