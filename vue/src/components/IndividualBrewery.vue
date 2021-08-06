<template>
<div id="i-b-body">
    <h1 id="i-b-h1">{{brewery.breweryName}}</h1>
    <div>
      <div id="i-b-brewery-photo">
        <img src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" alt="brewery photo">   
      </div>
        <h2 id="i-b-generalInfo">General Information</h2>
        <ul id="i-b-breweryInfo">
          <!-- <h3>{{brewery.breweryName}}</h3> -->
          <address-detail id="i-b-address" v-bind:passedBreweryAddressId = "brewery.breweryAddressId" />
          <p id="i-b-phone">Phone: {{brewery.phoneNumber}}</p>
          <a href=#v-bind:brewery.website id="i-b-website">{{brewery.breweryName}} Website</a>
          <h4 id="i-b-about">About</h4>
          <p id="i-b-history">{{brewery.history}}</p>
          <p id="i-b-date">Date established: {{brewery.dateEstablished}}</p>
        </ul>
        <h2 id="i-b-beerList">Beer List</h2>
        <div
        id="i-b-beers"
        v-for="beer in beers"
        v-bind:key="beer.beerBreweryId">   
          <p id="i-b-beer-name">{{beer.beerName}}</p>
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
      BreweryService.getBeers(this.$route.params.breweryId).then(response => {
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
</script>

<style>
#i-b-h1{
    text-align: center;
    grid-area: header;
    background-color: goldenrod;
    font-family: 'Lobster', cursive;
    font-size: 84px;
    padding: 25px;
}
#i-b-generalInfo{
    grid-area: generalInfo;
    background-color: goldenrod;
    color: black;
    display: inline-block;
}
#i-b-about{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
#i-b-phone{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
#i-b-website{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
#i-b-address{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
#i-b-history{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
#i-b-date{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
#i-b-beerList{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
/* #i-b-beers{
  background-color: goldenrod;
  color: black;
  display: inline-block;
} */
#i-b-beer-name{
  background-color: goldenrod;
  color: black;
  display: inline-block;
}
#i-b-breweryInfo{
    grid-area:breweryInfo;
}
#i-b-firstbeer{
    grid-area: firstBeer;
}
#i-b-secondbeer{
    grid-area: secondBeer;
}
#i-b-brewery-photo {
  display: grid;
  grid-area: breweryPhoto;
  justify-content: center;
}
#i-b-body{
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