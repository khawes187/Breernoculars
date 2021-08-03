<template class="template">
<body>
   <div class="home">
    <header>
      <h1>Working Title</h1>
    </header>
    
    <img class="background" src="../images/beer-2439237_960_720.webp" width="100%" height="100%" alt="homepage image">

    <div class="loading" v-if="isLoading">
      <img class="lazy" src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" />
    </div>
    <div>
      <breweryList />
    </div>  
    <!--<div class="breweries">
      <button v-for="brewery in this.$store.state.breweries" v-bind:key="brewery.name" onclick="var displayBrewery = brewery.name">{{brewery.name}}</button>
    </div>-->
  </div>
  </body>
</template>

<script>
/* import breweryList from '@/components/BreweryList' */
export default {
  /* components: {breweryList}, */
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
.template{
  background-color: black;
}
header {
  grid-area: header;
  text-align: center;

}
h1 {
  color: white;
}
.background {
  grid-area: backgroundPic;
}
div.home {
  display: grid;
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "header header header"
    "backgroundPic backgroundPic backgroundPic"
    "loading loading loading"
  ;
  height: 100vh;
  grid-gap: 10px;
  background-color: black;
  
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