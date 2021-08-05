<template>
  <div id="app">
    <div id="nav">
      <div id="home">
      <router-link v-bind:to="{ name: 'home' }">
        <button class="homeButton" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Go Home" />
          <div class="homeText">Home</div>
      </button>
      </router-link><!-- |&nbsp; -->
    </div>

    
      <div class="addBeerButton">
      <button class="add" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Add a beer" />
          <div class="addBeerText">Add a Beer</div>
      </button>
      </div>
      <!-- <div class="divider"/> -->
      <div class="deleteBeerButton">
      <button class="delete" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Delete a beer" />
          <div class="deleteBeerText">Delete a Beer</div>
      </button>
      </div>
 
  
    <!-- <div id="brewerButtons" >  needs linked to role//should this be a router-link? or v-if?
      <button class="add">Add beer to brewery</button>
      <div class="divider"/>
      <button class="delete">Delete beer from brewery</button>
    </div>
    
    <div id="adminButtons">  needs linked to role//should this be a router-link? or v-if?
      <button class="add">Add a Brewer</button>
      <div class="divider"/>
      <button class="delete">Delete a Brewer</button>
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
    </div>
    <router-view />
  </div>
</template>

<style scoped>
#app{
  background: repeating-conic-gradient(lightblue 0% 25%, white 0% 50%) 50% / 20px 20px;
  border-radius: 25px; 

}
#nav {
/*   display: flex;
  flex-direction: row;
  justify-content: space-between;*/
  border-radius: 25px; 
  display: grid;
  grid-template-columns: auto auto auto auto;
  grid-template-areas: 
    "home addButton deleteButton loginOrOut"
  ;
  text-align: center;
}
.add{
  grid-area: addButton;

}
.delete{
  grid-area: deleteButton;
}
#loginOrOut {
  grid-area: loginOrOut;

}
#home{
  grid-area: home;

}
/* .divider{
    width:50px;
    height:auto;
    display:inline-block;
} */
</style>
