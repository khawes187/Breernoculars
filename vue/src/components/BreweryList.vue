<template>
  <div>
    <h1>List of Breweries</h1>
    <div class="breweries">
      <div class="loading" v-if="isLoading">
        <img src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" />
      </div>
      <div
        class="board"
        v-for="board in boards"
        v-bind:key="board.id"
        v-bind:style="{ 'background-color': board.backgroundColor }"
        v-else
      >
        <router-link v-bind:to="{ name: 'Board', params: { id: board.id } }">
          {{ board.title }}
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import breweriesService from '../services/BreweryService';

export default {
  data() {
    return {
      breweries: [],
      isLoading: true
    };
  },
  created() {
    breweriesService.getBrewery().then(response => {
      this.boards = response.data;
      this.isLoading = false;
    });
  }
};
</script>

<style scoped>

</style>
