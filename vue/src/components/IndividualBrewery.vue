<template>
<div id="i-b-body">
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
        <div>  
          <address-detail id="i-b-address" v-bind:passedBreweryAddressId = "brewery.breweryAddressId" />
        </div>
        <div>
          <p id="i-b-phone">Phone: {{brewery.phoneNumber}}</p>
        </div>
        <div>
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
  /* display: grid; 
  grid-area: generalInfo;*/
  border-radius: 25px;
  background-color: goldenrod;
  color: black;
  display: inline;
  padding: 1%;
  text-align: center;
}

#i-b-phone{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  grid-area: phone;
}
#i-b-website{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  grid-area: webside;
}
#i-b-address{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  width: 100%;
  grid-area: address;
}
#i-b-about{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  grid-area: about;
}
#i-b-history{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  text-align: center;
  grid-area: history;
}
#i-b-date{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  grid-area: date;
}
#i-b-beerList{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
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
  grid-area: beer-name;
}
#i-b-breweryInfo{
  display: grid;
  width:50%;
  padding: 20px;
  background-color: goldenrod;
  border-radius: 25px;
  grid-area:breweryInfo;
}
/* #i-b-firstbeer{
    grid-area: firstBeer;
}
#i-b-secondbeer{
    grid-area: secondBeer;
} */
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
    /* "generalInfo generalInfo" */
    "address address"
    "phone website"
    "about about"
    "date date"
}
</style>