<template>
  <div id="app">
    <div id="nav">
      <div id="home">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link><!-- |&nbsp; -->
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

div#nav {
  display: grid;
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "home . loginOrOut"
    
  ;
  grid-gap: 10px;
  /* text-align: right; */
}
</style>
