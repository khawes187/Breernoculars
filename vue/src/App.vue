<template>
  <div id="app">
    <div id="nav">
      <div id="home">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link><!-- |&nbsp; -->
    </div>
    <div id="beerLoverButtons">
      <button class="add">Add a Beer</button>
      <div class="divider"/>
      <button class="delete">Delete a Beer</button>
    </div>
  
    <div id="brewerButtons" > <!-- needs linked to role//should this be a router-link? or v-if?-->
      <button class="add">Add beer to brewery</button>
      <div class="divider"/>
      <button class="delete">Delete beer from brewery</button>
    </div>
    
    <div id="adminButtons"> <!-- needs linked to role//should this be a router-link? or v-if?-->
      <button class="add">Add a Brewer</button>
      <div class="divider"/>
      <button class="delete">Delete a Brewer</button>
    </div>
    <div id="loginOrOut">
      <router-link v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''">Login</router-link>
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    </div>
    <router-view />
  </div>
</template>

<style scoped>
div#loginOrOut {
  grid-area: loginOrOut;
  text-align: end;
}
div#home{
  grid-area: home;
}
.divider{
    width:50px;
    height:auto;
    display:inline-block;
}
div#nav {
  display: grid;
  grid-template-columns: auto auto auto auto;
  grid-template-areas: 
    "home addButton deleteButton loginOrOut" /* Need to be linked to the right roles */
  ;
  grid-gap: 10px;
  /* text-align: right; */
}
button.add{
  background-color: #4CAF50; 
  color: black;
  padding: 15px 15px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 14px;
  grid-area: addButton;
}
button.delete{
  background-color: #f44336;
  color: black;
  padding: 15px 15px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 14px;
  grid-area: deleteButton;
}
</style>
