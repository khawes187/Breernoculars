<template>
  <div>    
    <div class="address">
     <div class="loading" v-if="isLoading">
        <img src="../images/9dc2a9af62e5d06ac0b9dce59e5b1d64.gif" />
      </div>
      <div v-else>
        
        <p>{{address.streetAddress}}</p>
        <p>{{address.city}}, {{address.stateOrTerritory}} {{address.postalCode}}</p>
      </div>
    </div>  
  </div>
</template>

<script>
import AddressService from '../services/AddressService';

export default {
 name:'address-details',
 props: ['passedBreweryAddressId'],
  data() {
    return {
      isLoading: true
    };
  },
  created(){
    this.retrieveAddress();
  },
  methods: {
    retrieveAddress() {
      AddressService.getAddress(this.$store.state.brewery.breweryAddressId).then(response => {
        console.log(response);
        this.$store.commit("SET_ADDRESS", response.data);
        this.isLoading = false;
      });   
    },
  },
  computed: {
      address() {
          return this.$store.state.address;
      },
           
  }
};  
</script>

<style>

</style>