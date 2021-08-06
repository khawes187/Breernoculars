import axios from 'axios';

export default {

  getAddress(breweryAddressId) {
      return axios.get(`/address/${breweryAddressId}`);
  },

  getAddresses() {
    return axios.get(`/address`);
},
}