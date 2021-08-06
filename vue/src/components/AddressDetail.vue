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
      addresses: [],
      isLoading: true
    };
  },
  created(){
    this.retrieveAddresses();
  },
  methods: {
    retrieveAddresses() {
      AddressService.getAddresses().then(response => {
        console.log(response);
        this.$store.commit("SET_ADDRESSES", response.data);
        this.isLoading = false;
      });   
    },
  },
  computed: {
      address() {
          return this.$store.state.addresses.filter(address => address.addressId == this.$store.state.brewery.breweryAddressId);
      },

  }
};  
</script>

<style>

</style>