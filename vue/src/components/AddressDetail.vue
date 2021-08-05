<template>
  <div>    
    <div class="address">
     <div class="loading" v-if="isLoading">
        <img src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" />
      </div>
      <div
        class="brewery"
        v-for="brewery in this.$store.state.breweries"
        v-bind:key="brewery.breweryId">   
        <h3>{{brewery.breweryName}}</h3>
        <p>{{brewery.phoneNumber}}</p>
        <a href=#v-bind:brewery.website>{{brewery.breweryName}} Website</a>
        <p>{{brewery.history}}</p>
        <p>Date established: {{brewery.dateEstablished}}</p>
      </div>
  </div>
</template>

<script>
import AddressService from '../services/AddressService';

export default {
 name:'address-details',
  data() {
    return {
      address: {},
      isLoading: true
    };
  },
  created() {
    this.retrieveAddress();
  },
  methods: {
    retrieveAddress() {
      AddressService.get().then(response => {
        console.log(response);
        this.$store.commit("SET_BREWERIES", response.data);
        this.isLoading = false;
      });
    },
  }
};
</script>

<style>

</style>