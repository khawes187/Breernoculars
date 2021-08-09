<template>
<div id="i-b-body">
    <div>
    <h1 id="i-b-h1">{{brewery.breweryName}}</h1>
    <div>
      <div id="i-b-brewery-photo">
        <img src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" alt="brewery photo">   
      </div>
      <div>
        <h1 id="i-b-generalInfo">General Information</h1>
      </div>
        <div id="i-b-breweryInfo">
          <!-- <h3>{{brewery.breweryName}}</h3> -->
        <div id="i-b-address">   
          <p>{{address.streetAddress}}</p>
        <p>{{address.city}}, {{address.stateOrTerritory}} {{address.postalCode}}</p> 
        </div>
        <div>
          <p id="i-b-phone">Phone: {{brewery.phoneNumber}}</p> 
        &ensp;
        &ensp;
          <a href=#v-bind:brewery.website id="i-b-website">{{brewery.breweryName}} Website</a>
        </div>
        <div>
          <h4 id="i-b-about">About</h4>
        </div>
        <div>
          <p id="i-b-history">{{brewery.history}}</p>
        </div>
        <div>
          <p id="i-b-date">Date established: {{brewery.dateEstablished}}</p>
        </div>
        </div>
      </div>
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
import AddressService from '../services/AddressService';


export default {
  name:'individual-brewery',
  components: {},
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
       this.retrieveAddresses();
      });
    },
    retrieveBeers() {
      BreweryService.getBeers(this.$route.params.breweryId).then(response => {
        console.log(response);
        this.$store.commit("SET_BEERS", response.data);
       this.isLoading = false;
    });
    },
    retrieveAddresses() {
      AddressService.getAddresses().then(response => {
        console.log(response);
        this.$store.commit("SET_ADDRESSES", response.data);
        this.isLoading = false;
      });   
    },
  },
  computed: {
      brewery() {
          return this.$store.state.brewery;
      },
      beers() {
        return this.$store.state.beers;
      },
      address() {
        return this.$store.state.addresses.find(address => address.addressId == this.$store.state.brewery.breweryAddressId);       
      },
  }
};
</script>

<style>
#i-b-h1{
  display: grid;
  text-align: center;
  grid-area: breweryName;
  background-color: goldenrod;
  font-family: 'Lobster', cursive;
  font-size: 84px;
  padding: 25px;
}
#i-b-generalInfo{
  /* display: grid;  */
  width: 40%;
  padding-left: 50px;
  grid-area: generalInfo;
  padding: 5px;
  border-radius: 25px;
  background-color: goldenrod;
  color: black;
  display: inline;
  text-align: center;
}

#i-b-phone{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 5px;
  border-radius: 25px;
  grid-area: phone;
}
#i-b-website{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 5px;
  border-radius: 25px;
  grid-area: webside;
}
#i-b-address{
  /* display: grid; */
  background-color: goldenrod;
  color: black;
  display: inline-block;
  width: 70%;width: 70%;
  text-align: center;
  padding: 5px;
  border-radius: 25px;
  grid-area: address;
}
#i-b-about{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;;
  grid-area: about;
}
#i-b-history{
  margin:0;
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  text-align: center;
  border-radius: 25px;
  padding: 15px;
  width: 50%;
  grid-area: history;
}
#i-b-date{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 5px;
  border-radius: 25px;;
  grid-area: date;
}
#i-b-beerList{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 5px;
  border-radius: 25px;
  grid-area: beerList;
}
/* #i-b-beers{
  background-color: goldenrod;
  color: black;
  display: inline-block;
} */
#i-b-beer-name{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 5px;
  border-radius: 25px;
  grid-area: beer-name;
}
#i-b-breweryInfo{
  /* display: grid; */
  width:30%;
  /* padding: 20px; */
  padding-left: 50px;
  padding-top: 20px;
  background-color: goldenrod;
  border-radius: 25px;
  grid-area:breweryInfo;
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
  grid-template-columns: auto auto;
  grid-template-areas: 
    "breweryName breweryName"
    "breweryPhoto breweryPhoto"
    "generalInfo generalInfo"
    "address website"
    "address phone"
    "about about"
    "date date"
}
</style>