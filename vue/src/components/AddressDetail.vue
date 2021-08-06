<template>
  <div>    
    <div class="address">          
        <p>{{address.streetAddress}}</p>
        <p>{{address.city}}, {{address.stateOrTerritory}} {{address.postalCode}}</p>
      </div>  
  </div>
</template>

<script>
import AddressService from '../services/AddressService';

export default {
 name:'address-details',
  data() {
    return {
      addresses: [],
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