<template>
    <div id="update-brewery-form">
        <form v-on:submit.prevent="submitForm">
            <h3 id="update-brewery-name">Update Brewery</h3>
            <label for="breweryName">Brewery Name:</label><br>
            <input type="text" id="breweryName" name="breweryName" v-model="brewery.breweryName" size="40"><br>
            <br>
            <label for="breweryAddress">Brewery Address:</label><br>
            <textarea id="breweryAddress" name="breweryAddress" v-model="brewery.breweryAddress" rows="4" cols="40"></textarea><br>
            <br>
            <label for="breweryPhoneNumber">Brewery Phone Number:</label><br>
            <input type="text" id="breweryPhoneNumber" name="breweryPhoneNumber" v-model="brewery.phoneNumber" size="40"><br>
            <br>
            <label for="breweryWebsite">Brewery Website:</label><br>
            <input type="text" id="breweryWebsite" name="breweryWebsite" v-model="brewery.website" size="40"><br>
            <br>
            <label for="breweryDateEstablished">Brewery Date Established:</label><br>
            <input type="text" id="breweryDateEstablished" name="breweryDateEstablished" v-model="brewery.dateEstablished" size="40"><br>
            <br>
            <label for="breweryHistory">Brewery History:</label><br>
            <textarea id="breweryHistory" name="breweryHistory" v-model="brewery.history" rows="4" cols="40"></textarea><br>
            <br>
            <label for="breweryUrl">Brewery Image URL:</label><br>
            <input type="text" id="breweryUrl" name="breweryUrl" v-model="brewery.breweryUrl" size="40"><br>
            <br>
            <button type="submit" id="brewery-update-button" style="border: 0; background: transparent">
                <img src="@/images/editedbutton.gif" width="55" height="65" alt="add brewery" />
               <div class="add-brewery-text">Update This Brewery</div>
               </button>           
        </form>
    </div>
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
    name:'Update-a-brewery', 
    props:['updatedBrewery'],
    created() {
        this.retrieveBrewery();
    
    },
    methods: {
        resetForm(){
            this.showForm = false;
        },
        
        submitForm(){
            const updatedBrewery = {
                BreweryId:parseInt(this.$route.params.breweryId),
                BreweryName:this.brewery.breweryName,
                BreweryAddress: this.brewery.breweryAddress,
                PhoneNumber: this.brewery.phoneNumber,
                Website: this.brewery.website,
                DateEstablished: this.brewery.dateEstablished,
                History: this.brewery.history,
                Approved:this.brewery.approved,
                BreweryUrl:this.brewery.breweryUrl
                };
                BreweryService.updateBrewery(updatedBrewery,this.$route.params.breweryId).then(response=> {
                console.log(response); 
                window.location.reload();  })   
            
        },
        retrieveBrewery() {
                BreweryService.getBrewery(this.$route.params.breweryId).then(response => {
                console.log(response);
                this.$store.commit("SET_BREWERY", response.data);
                this.isLoading = false;     
            });
        },

    },
    //closes methods
    computed: {
      brewery() {
        return this.$store.state.brewery;
      }
  }
}
</script>     

<style>
#update-brewery-name{
  border-style: solid;
  border-width:thick;
  border-color: black;
  border-radius: 25px;
}
#update-brewery-form{
    background-color: goldenrod;
    width: fit-content;
    padding: 10px;
    border-radius: 25px;
    text-align: center;
    margin-left: 10px;
    font-weight: bold;
    display: table-cell;
    height: auto;
 }
.brewery-update-button{
    color: black;
}
.add-brewery-text{
    font-size: larger;
    font-weight: bold;
}
</style>
