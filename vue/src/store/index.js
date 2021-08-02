import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    breweries: [
    {
      name: 'Terrestrial Brewing Company',
      address: '7524 Father Frascati, Cleveland, OH 44102',
      phone: '(216) 465-9999',
      hours: 'Hours: Monday, 4-11 | Tuesday, 4-11 | Wednesday, 4-11 | Thursday, 4-11 | Friday, 4-11 | Saturday, 4-11 | Sunday, 4-11',
      description: 'Chic brewery & taproom with plenty of patio seating offering adventurous house beers.'
    },
    {
      name: 'Terrestrial Brewing Company',
      address: '7524 Father Frascati, Cleveland, OH 44102',
      phone: '(216) 465-9999',
      hours: 'Hours: Monday, 4-11 | Tuesday, 4-11 | Wednesday, 4-11 | Thursday, 4-11 | Friday, 4-11 | Saturday, 4-11 | Sunday, 4-11',
      description: 'Chic brewery & taproom with plenty of patio seating offering adventurous house beers.'
    }
  ]
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    }
  }
})
