<template class="template">
<body>
   <div class="home">
    <header>
      <h1>Working Title</h1>
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
/* .template{
  background-color: black;
} */
header {
  grid-area: header;
  text-align: center;

}
h1 {
  color: white;
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
  opacity: 0.4;
  z-index: -1;
  }
 div.home {
  display: grid;
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "header header header"
    "loading loading loading"
  ;
  height: 100vh;
  grid-gap: 10px;
 }
 .breweryList{
   background-color: blanchedalmond;
 }
  /*

div.breweries{
  background-image: "../images/beer-2439237_960_720.webp";
}*/
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