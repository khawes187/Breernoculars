<template class="template">
<body>
<!--   <div class="menuButtons">
    <div id="home">
      <router-link v-bind:to="{ name: 'home' }">
        <button class="homeButton" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Go Home" />
          <div class="homeText">Home</div>
        </button>
      </router-link>
    </div>

    <div class="addBeerButton">
      <button class="add" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Add a beer" />
          <div class="addBeerText">Add a Beer</div>
      </button>
    </div>
    <div class="deleteBeerButton">
      <button class="delete" style="border: 0; background: transparent">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="Delete a beer" />
        <div class="deleteBeerText">Delete a Beer</div>
      </button>
    </div> -->

     <!--  needs linked to role//should this be a router-link? or v-if? -->
<!--       <div class="addBeerFromBreweryButton">
      <button class="add" style="border: 0; background: transparent">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="Delete a beer" />
        <div class="addBeerToBreweryText">Add Beer to Brewery</div>
      </button>
      </div>
      <div class="deleteBeerFromBreweryButton">
      <button class="delete" style="border: 0; background: transparent">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="Delete a beer" />
        <div class="deleteBeerFromBreweryText">Delete a Beer from Brewery</div>
      </button>
      </div> -->
    

    <!-- needs linked to role//should this be a router-link? or v-if? -->
<!--     <div class="addBrewer">
      <button class="add" style="border: 0; background: transparent">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="Delete a beer" />
        <div class="addBrewer">Add Brewer</div>
      </button>
      </div>
    <div class="deleteBrewer">
      <button class="delete" style="border: 0; background: transparent">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="Delete a beer" />
        <div class="deleteBrewer">Delete a Brewer</div> 
      </button>
    </div> -->

    <!-- <div id="loginOrOut">
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''">
        <button class="loginButton" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Login" />
          <div class="loginText">Login</div>
        </button>
      </router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">
        <button class="logoutButton" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="logout" />
          <div class="logoutText">Logout</div>
        </button>
      </router-link>
    </div>
  </div> -->
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

@import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');

@import url('https://fonts.googleapis.com/css2?family=Lobster&family=Open+Sans&display=swap');

/* .menuButtons{
  height:100px;
  width: 1000px; */
  /* display: flex;
  flex-direction: row;
  justify-content:space-between; */
  /* background: repeating-conic-gradient(lightblue 0% 25%, white 0% 50%) 50% / 20px 20px;
  border-radius: 25px;
  border-color: black;
  border-style: groove;
  display: grid;
  grid-template-columns: auto auto auto auto;
  grid-template-areas: 
    "home add delete logInOrOut";
  grid-area: menuBar;
}
.homebutton{
  grid-area: home;
}
.add{
  grid-area: add;
}
.delete{
  grid-area: delete;
}
#loginOrOUt{
  grid-area: logInOrOut;
} */
header {
  font-family: 'Lobster', cursive;
  grid-area: header;
  text-align: center;

}
h1 {
  color: goldenrod;
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
  display: grid;
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "header header header"
    "loading loading loading"
    ". breweryList ."
  ;
  height: 100vh;
  grid-gap: 10px;
 }
 .breweryList{
   background-color: blanchedalmond;
   opacity: 0.5;
   grid-area: breweryList;
   font-family: 'Open Sans', sans-serif;
   padding: 0px 25px 25px 25px;
   border-radius: 25px;
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