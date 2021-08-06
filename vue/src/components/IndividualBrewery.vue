<template>
<div>
    <h2>Brewery Information</h2>
    <div>
        <h2>This is changed</h2>
        <ul class="breweryInfo">
          <h3>{{brewery.breweryName}}</h3>
          <address-detail v-bind:individualPassedBreweryAddressId = "brewery.breweryAddressId" />
          <p>{{brewery.phoneNumber}}</p>
          <a href=#v-bind:brewery.website>{{brewery.breweryName}} Website</a>
          <p>{{brewery.history}}</p>
          <p>Date established: {{brewery.dateEstablished}}</p>
        </ul>
        <div
        class="beers"
        v-for="beer in beers"
        v-bind:key="beer.beerBreweryId">   
          <p>Beer: {{beer.beerName}}</p>
      </div>
    </div> 
</div>       
</template>



<script>
import BreweryService from '../services/BreweryService';
import AddressDetail from '../components/AddressDetail';

export default {
  name:'individual-brewery',
  components: {AddressDetail},
  data() {
    return {
      //breweries: [],
     // isLoading: true
    };
  },
  created() {
    this.retrieveBrewery();
    this.retrieveBeers();
  },
  methods: {
    retrieveBrewery() {
      BreweryService.getBrewery(this.$route.params.breweryId).then(response => {
        console.log(response);
        this.$store.commit("SET_BREWERY", response.data);
       // this.isLoading = false;
      });
    },
    retrieveBeers() {
      BreweryService.getBeers(this.$route.params.beersBreweryId).then(response => {
        console.log(response);
        this.$store.commit("SET_BEERS", response.data);
       // this.isLoading = false;
    });
    }
  },
  computed: {
      brewery() {
          return this.$store.state.brewery;
      },
      beers() {
        return this.$store.state.beers;
      }
  }
};

//test test
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