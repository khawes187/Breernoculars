import axios from 'axios';

export default {

  getBrewery(breweryId) {
      return axios.get(`/brewery/${breweryId}`);
  },

  getBreweries() {  
    return axios.get('/brewery');
  },

  getBeers(beerBreweryId) {  
    return axios.get(`/beer/brewery${beerBreweryId}`);
  },
  addBrewery(newBrewery) {  
    return axios.post('/brewery', newBrewery);
},

}