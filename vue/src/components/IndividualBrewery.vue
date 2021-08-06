<template>
<div>
    <h1>{{brewery.breweryName}}</h1>
    <div>
      <div class="brewery-photo">
        <img src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" alt="brewery photo">   
      </div>
        <h2 class="generalInfo">General Information</h2>
        <ul class="breweryInfo">
          <!-- <h3>{{brewery.breweryName}}</h3> -->
          <address-detail 
          v-bind:passedBreweryAddressId = "brewery.breweryAddressId" />
          <p class="phone">Phone: {{brewery.phoneNumber}}</p>
          <a href=#v-bind:brewery.website class="website">{{brewery.breweryName}} Website</a>
          <h4 class="about">About</h4>
          <p>{{brewery.history}}</p>
          <p class="date">Date established: {{brewery.dateEstablished}}</p>
        </ul>
        <h2 class="beerList">Beer List</h2>
        <div
        class="beers"
        v-for="beer in beers"
        v-bind:key="beer.beerBreweryId">   
          <p>{{beer.beerName}}</p>
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
     isLoading: true
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
       this.isLoading = false;
      });
    },
    retrieveBeers() {
      BreweryService.getBeers(this.$route.params.breweryId).then(response => {
        console.log(response);
        this.$store.commit("SET_BEERS", response.data);
       this.isLoading = false;
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
</script>

<style>
h1{
    text-align: center;
    grid-area: header;
    background-color: goldenrod;
    font-family: 'Lobster', cursive;
    font-size: 84px;
    padding: 25px;
}
h2{
    grid-area: generalInfo;
    background-color: goldenrod;
    color: black;
    display: inline-block;
}
h4{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
p{
  background-color: goldenrod;
  color: black;
  display: inline-block;
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
.brewery-photo {
  display: grid;
  grid-area: breweryPhoto;
  justify-content: center;
}
.body{
  margin: 0;
  background-image: url(../images/BreweryInfoPage.jpg);
  height:100%;
  width:100%;
  display: grid;
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "header header header"
    ". breweryPhoto ."
    "generalInfo . ."
    "breweryInfo firstBeer firstBeer"
    "breweryInfo firstBeer firstBeer"
    "breweryInfo secondBeer secondBeer"
    "breweryInfo secondBeer secondBeer"
}
</style>