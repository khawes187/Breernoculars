import axios from 'axios';

export default {

  getAddress(breweryAddressId) {
      return axios.get(`/address/${breweryAddressId}`);
  },

}