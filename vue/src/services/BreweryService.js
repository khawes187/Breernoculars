import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  getBrewery(breweryId) {
      return axios.get(`/brewery/${breweryId}`);
  },

  getBreweries() {
    //return http.get('/brewery');
    return axios.get('/brewery');
  },

}