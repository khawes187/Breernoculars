<template class="template">
<body>

   <div class="home">
    <header>
      <h1 id="home-h1">Beernoculars</h1>
    </header>
    
    <img class="backgroundimage" src="../images/beer-2439237_960_720.webp" width="100%" height="100%" alt="homepage image">

    <div class="loading" v-if="isLoading">
      <img class="lazy" src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" />
    </div>
    <div class="breweryList">
      <brewery-list />
    </div>  
    <!--<div class="breweries">
      <button v-for="brewery in this.$store.state.breweries" v-bind:key="brewery.name" onclick="var displayBrewery = brewery.name">{{brewery.name}}</button>
    </div>-->
  </div>
  </body>
</template>

<script>
import BreweryList from '@/components/BreweryList';
export default {
  components: {BreweryList},
  name: "home",
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
  },
  data() {
    return {
      isLoading: true
    }
  },
  created(){
    this.isLoading = false;
  }

};
</script>

<style scoped>

@import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');

@import url('https://fonts.googleapis.com/css2?family=Lobster&family=Open+Sans&display=swap');

header {
  font-family: 'Lobster', cursive;
  grid-area: header;
  text-align: center;
}
#home-h1 {
  color: black;
  background-color: goldenrod;
  font-family: 'Lobster', cursive;
  font-size: 84px;
}
/* .background {
  grid-area: backgroundPic;
} */
.backgroundimage {
  min-height: 100%;
  min-width: 1024px;
  width:100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  opacity: 0.8;
  z-index: -1;
  }
 div.home {
  cursor: pointer;
  /* display: grid; */
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "header header header"
    /* "loading loading loading" */
    ". breweryList ."
  ;
  height: 100vh;
  grid-gap: 10px;
 }
 .breweryList{
   background-color: goldenrod;
   opacity: 0.9;
   grid-area: breweryList;
   font-family: 'Open Sans', sans-serif;
   /* padding: 0px 25px 25px 25px; */
   padding: 10px;
   width: 25%;
   border-radius: 25px;
   text-align: center;
   
 }
div.loading {
  flex: 3;
  
}
img.lazy {
  position: absolute;
  top: 100px;
  left: 240px;
  z-index: 100;
}

@media screen and (max-width: 450px) {
  .template {
    grid-template-areas: 
      "header"
      "breweryList"
  ;
      grid-template-columns: auto;
  }
}
</style>