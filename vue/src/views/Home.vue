<template>
  <div class="home">
    <header>
      <h1>Working Title</h1>
    </header>
    <div class="breweries">
      <button v-for="brewery in this.$store.state.breweries" v-bind:key="brewery.name" onclick="var displayBrewery = brewery.name">{{brewery.name}}</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
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
  ;
  height: 100vh;
  grid-gap: 10px;
}
</style>