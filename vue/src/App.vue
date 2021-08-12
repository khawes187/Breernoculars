<template class="template">
  <div id="app" content="width=device-width, initial-scale=1.0">
   <div class="menuButtons">
    <div id="home">
      <router-link v-bind:to="{ name: 'home' }">
        <button class="homeButton" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Go Home" />
          <div class="homeText">Home</div>
        </button>
      </router-link>
    </div>

    <div class="addBeerButton">
      <router-link v-bind:to="{ name: 'newBreweryForm' }">
      <button class="add" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Add a beer" />
          <div class="addBeerText">Add a Brewery</div>
      </button>
      </router-link>
    
    </div>
    <!--<div class="deleteBeerButton">
      <button class="delete" style="border: 0; background: transparent">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="Delete a beer" />
        <div class="deleteBeerText">Delete a Beer</div>
      </button>
    </div> -->

   <!--  <div class="fillerSpace">
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
    

    <!-- needs linked to roe//should this be a router-link? or v-if? -->
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

    <div id="loginOrOut">
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
    <!-- <div class="search-container"> -->
   <!-- <form action="">  LINK PAGE FOR SEARCHING -->
    <!-- <input type="text" class="searchBar" placeholder="Search.." name="search">
      <button id="searchSubmit" type="submit">Submit</button> 
    </div>-->
    
   </div>
    <router-view />
  </div>
</template>

<style scoped>
/* .searchBar{
  grid-area: searchBar;
  border-color: black;
  font-size: 17px;
  align-items:left;
  margin-top: 30px;
}
#searchSubmit{
  cursor: pointer;
  margin-top: 30px;
  margin: 0;
  padding: 4px;
} */
 .menuButtons {
  justify-content:initial;
  /* border-radius: 25px;  */
  display: grid;
  grid-template-columns: auto auto auto auto;
  grid-template-rows: auto;
  grid-template-areas: 
    "home addButton deleteButton loginOrOut";
  text-align: center;
  
  background: repeating-conic-gradient(lightblue 0% 25%, white 0% 50%) 50% / 20px 20px;
  border-radius: 25px;
  border-color: black;
  border-style: groove;
   margin: 0px;
  padding:0px;
  grid-area: navBar;
}
.add{
  grid-area: addButton;
  cursor: pointer;

}
.delete{
  grid-area: deleteButton;
  cursor: pointer;
}
#loginOrOut {
  grid-area: loginOrOut;
  cursor: pointer;

}
.homeButton{
  grid-area: home;
  cursor: pointer;

}
.loginButton{
  cursor: pointer;
}
.logoutButton{
  cursor: pointer;
}
/* .divider{
    width:50px;
    height:auto;
    display:inline-block;
} */

/* @media screen and (max-width: 450px) {
  .template {
    grid-template-areas: 
      "home addButton deleteButton loginOrOut"
  ;
      grid-template-columns: auto auto auto auto;
  }
} */
</style>
