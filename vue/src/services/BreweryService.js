import axios from 'axios';


export default {

  getBrewery(breweryId) {
      return axios.get(`/brewery/${breweryId}`);
  },

  getBreweries() {
    return axios.get('/brewery');
  },

}