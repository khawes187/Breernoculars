<template>
<div id="i-b-body">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <div>
    <h1 id="i-b-h1">{{brewery.breweryName}}</h1>
    <div>
      <div id="i-b-photo-holder">
        <img v-bind:src="brewery.breweryUrl" id="i-b-brewery-photo" alt="brewery photo">   
      </div>
      <br>
      <div>
        <h1 id="i-b-generalInfo">General Information</h1>
      </div>
        <div id="i-b-breweryInfo">
          <!-- <h3>{{brewery.breweryName}}</h3> -->
        <div id="i-b-address">   
          <p>{{brewery.breweryAddress}}</p>
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
        <!-- <h2 id="i-b-beerList">Beer List</h2> --> 
        <div
        id="i-b-beers"
        v-for="beer in beers"
        v-bind:key="beer.beerBreweryId">  
          <h2 id="i-b-beer-name">{{beer.beerName}}</h2>
          <img v-bind:src="beer.beerUrl" id="i-b-beer-photo" alt="beer list photo"><!--  moved out of a p -->
          <p id="i-b-beer-type">Type:&ensp;{{beer.beerType}}</p>
          <p id="i-b-beer-abv">ABV:&ensp;{{beer.abv}}</p>
          <p id="i-b-beer-description">Description:&ensp;{{beer.beerDescription}}</p>
          <p id="i-b-beer-seasonal">Seasonal Brew:&ensp;{{beer.seasonal}}</p>
      </div>
      <button id="add-beer-button" v-on:click="showImage = !showImage">Brewer Options</button>
      <div v-if="showImage===true">
        <add-a-beer />
      </div>
    </div> 
      </div>
</template>



<script>
import BreweryService from '../services/BreweryService';
import AddABeer from './AddABeer.vue';


export default {
  name:'individual-brewery',
  components: {AddABeer},
  data() {
    return {
      //breweries: [],
     isLoading: true,
     showImage: false
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
    },
  },
  computed: {
      brewery() {
        return this.$store.state.brewery;
      },
      beers() {
        return this.$store.state.beers;
      },
  }
};
</script>

<style>
#add-beer-button{
  background-color: goldenrod;
  padding: 10px;
  border-radius: 25px;
  font-weight: bold;
  margin-left: 10px;
}
#i-b-h1{
  display: grid;
  text-align: center;
  grid-area: breweryName;
  background-color: goldenrod;
  font-family: 'Lobster', cursive;
  font-size: 84px;
  padding: 25px;
  background: linear-gradient(
    to right,
    transparent,
    goldenrod,
    goldenrod,
    goldenrod,
    goldenrod,
    transparent);
}
#i-b-generalInfo{
  /* display: grid;  */
  margin-left: 10px;
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
  width: 80%;
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
  width: 80%;
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
  padding: 10px;
  border-radius: 25px;
  text-align: center;
}
#i-b-beers{
  margin: 10px;
  padding: 10px;
  border-radius: 25px;
  background-color: goldenrod;
  color: black;
  width: 40%;
  
  /* display: inline-block; 
  text-align: center;
 grid-template-columns: auto auto;
   grid-template-areas: 
    "name name"
    "photo photo"
    "type type"
    "abv abv"
    "description description"
    "seasonal seasonal"; */
} 
#i-b-beer-name{ 
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 5px;
  border-radius: 25px;
  display: grid;
  grid-area: name;
  text-align: center;
}
#i-b-beer-photo{
  text-align: center;
  object-fit:contain;
  width: 400px;
  height: 200px;
  display: block;
    margin-left: auto;
    margin-right: auto
  /* display: grid;
  grid-area: photo; */
}
#i-b-beer-type{
  text-align: center;
  display: grid;
  grid-area: type;
}
#i-b-beer-abv{
  text-align: center;
  display: grid;
  grid-area: abv;
}
#i-b-beer-description{
  text-align: center;
  display: grid;
  grid-area: description;
}
#i-b-beer-seasonal{
  text-align: center;
  display: grid;
  grid-area: seasonal;
}
#i-b-breweryInfo{
  margin: 10px;
  width:30%;
  padding-left: 20px;
  padding-top: 20px;
  background-color: goldenrod;
  border-radius: 25px;
  grid-area:breweryInfo;
}
.i-b-photo-holder{
  text-align: center;
}
#i-b-photo-holder div{
  position: relative;
  display: inline-block;
  background-color: goldenrod;
  padding: 15px;
  border-radius: 25px;
  margin:100px;
  background-color: goldenrod;
  padding: 10px;
}
/* #i-b-photo-holder span {
    position: absolute;
    left: 0;
    bottom: 0;
    width: 100%;
    background: goldenrod;
} */
#i-b-brewery-photo {
  border-radius: 25px;
  object-fit:inherit;
  width:75%;
  justify-content: center;
  display: inline-block;
  border-style: solid;
  border-width:thick;
  border-color: goldenrod;
  margin-left: 10px;  
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
    /* "breweryPhoto breweryPhoto" */
    "generalInfo generalInfo"
    "address website"
    "address phone"
    "about about"
    "date date"
}
@media screen and (max-width: 800px) {
  #i-b-breweryInfo, #i-b-beers{
    width: 90%;
  }
  #i-b-breweryInfo {
    width: 90%;
    padding: 0;
    text-align: center;
  }
  #i-b-beer-photo{
    margin-left: 10%;
    margin-right: 10%;
    width: 60%;
  }
  #i-b-body{
  margin: 0;
  background-image: url(../images/BreweryInfoPage.jpg);
  height:100%;
  width:100%;
  }
}
</style>