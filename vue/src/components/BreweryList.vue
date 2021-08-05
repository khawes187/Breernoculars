<template>
  <div>
    <h1>List of Breweries</h1>
    <div class="breweries">
     <!-- <div class="loading" v-if="isLoading">
        <img src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" />
      </div> -->
      <div
        class="brewery"
        v-for="brewery in this.$store.state.breweries"
        v-bind:key="brewery.breweryId"
        v-on:click="viewBrewery(brewery.breweryId)">   
          <h3>{{brewery.breweryName}}</h3>
          <p>{{brewery.phoneNumber}}</p>
          <a href=#v-bind:brewery.website>{{brewery.breweryName}} Website</a>
          <p>{{brewery.history}}</p>
          <p>Date established: {{brewery.dateEstablished}}</p>
        <!--<router-link v-bind:to="{ name: 'Brewery', params: { id: brewery.id } }">
          {{ brewery.title }}
        </router-link>-->
      </div>
    </div>
  </div>
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
  name:'brewery-list',
  data() {
    return {
      //breweries: [],
     // isLoading: true
    };
  },
  created() {
    this.retrieveBreweries();
  },
  methods: {
    retrieveBreweries() {
      BreweryService.getBreweries().then(response => {
        console.log(response);
        this.$store.commit("SET_BREWERIES", response.data);
       // this.isLoading = false;
      });
    },
    viewBrewery(breweryId){
      this.$router.push(`/brewery/${breweryId}`);
    }
  }
};
</script>

<style scoped>

</style>
