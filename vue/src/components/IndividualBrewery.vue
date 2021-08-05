<template>
<div>
    <div v-for="brewery in this.$store.state.brewery" v-bind:key="brewery.breweryId">
        
        <h2>Brewery Information</h2>
        <ul class="breweryInfo">
          <h3>{{brewery.breweryName}}</h3>
          <p>{{brewery.phoneNumber}}</p>
          <a href=#v-bind:brewery.website>{{brewery.breweryName}} Website</a>
          <p>{{brewery.history}}</p>
          <p>Date established: {{brewery.dateEstablished}}</p>
        </ul>
        <p class="firstbeer">First Beer Name</p>
        <p class="secondbeer">Second Beer Name</p>
        
    </div> 
</div>       
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
  name:'individual-brewery',
  data() {
    return {
      //breweries: [],
     // isLoading: true
    };
  },
  created() {
    this.retrieveBrewery();
  },
  methods: {
    retrieveBrewery() {
      BreweryService.getBrewery().then(response => {
        console.log(response);
        this.$store.commit("SET_BREWERIES", response.data);
       // this.isLoading = false;
      });
    },
  }
};
</script>

<style>
h1{
    text-align: center;
    grid-area: header;
}
h2{
    grid-area: breweryName;
}
.breweryInfo{
    grid-area:breweryInfo;
}
.firstbeer{
    grid-area: firstBeer;
}
.secondbeer{
    grid-area: secondBeer;
}
body{
  display: grid;
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "header header header"
    "breweryName . ."
    "breweryInfo firstBeer firstBeer"
    "breweryInfo firstBeer firstBeer"
    "breweryInfo secondBeer secondBeer"
    "breweryInfo secondBeer secondBeer"

}
</style>