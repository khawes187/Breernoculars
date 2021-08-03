import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:44315"
});

export default {

  getBrewery(breweryId) {
      return http.get(`/brewery/${breweryId}`);
  },

  getBreweries() {
    return http.get('/brewery');
  },

}