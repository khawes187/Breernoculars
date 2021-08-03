<template>

  <div class="home">
    <header>
      <h1>Working Title</h1>
    </header>
  
    <div class="loading" v-if="isLoading">
      <img class="lazy" src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" />
    </div>
    <div>
      <breweriesList />
    </div>  
      <!-- The code above this is working with the "= true" how do we get it to work without it? -->
    <!--<div class="breweries">
      <button v-for="brewery in this.$store.state.breweries" v-bind:key="brewery.name" onclick="var displayBrewery = brewery.name">{{brewery.name}}</button>
    </div>-->
  </div>
  
</template>

<script>
import breweryList from '@/components/BreweryList'
export default {
  components: {breweryList},
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

};
</script>

<style scoped>
header {
  grid-area: header;
}

div.home {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-areas: 
    ". header ."
    "loading loading loading"
  ;
  height: 100vh;
  grid-gap: 10px;
  background-image: "../images/beer-2439237_960_720.webp";
  /* Background-image does not work */
  
}
div.breweries{
  background-image: "../images/beer-2439237_960_720.webp";
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
</style>