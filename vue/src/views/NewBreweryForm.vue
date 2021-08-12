<template>
    <div id="create-brewery-form">
        <form v-on:submit.prevent="submitForm">
            <label for="breweryName">Brewery Name:</label><br>
            <input type="text" id="breweryName" name="breweryName" v-model="brewery.breweryName" size="40"><br>
            <br>
            <label for="breweryAddress">Brewery Address:</label><br>
            <textarea id="breweryAddress" name="breweryAddress" v-model="brewery.breweryAddress" rows="4" cols="40"></textarea><br>
            <br>
            <label for="breweryPhoneNumber">Brewery Phone Number:</label><br>
            <input type="text" id="breweryPhoneNumber" name="breweryPhoneNumber" v-model="brewery.breweryPhoneNumber" size="40"><br>
            <br>
            <label for="breweryWebsite">Brewery Website:</label><br>
            <input type="text" id="breweryWebsite" name="breweryWebsite" v-model="brewery.breweryWebsite" size="40"><br>
            <br>
            <label for="breweryDateEstablished">Brewery Date Established:</label><br>
            <input type="text" id="breweryDateEstablished" name="breweryDateEstablished" v-model="brewery.breweryDateEstablished" size="40"><br>
            <br>
            <label for="breweryHistory">Brewery History:</label><br>
            <textarea id="breweryHistory" name="breweryHistory" v-model="brewery.breweryHistory" rows="4" cols="40"></textarea><br>
            <br>
            <button type="submit" id="beer-submit-button" style="border: 0; background: transparent">
                <img src="@/images/editedbutton.gif" width="55" height="65" alt="add brewery" />
               <div class="add-brewery-text">Add A Brewery</div>
               </button>           
        </form>
    </div>
</template>

<script>
import BreweryService from '../services/BreweryService';

export default {
    name:'Add-a-brewery', 
    props:['newBrewery'],

    data() {
        return {
            brewery: {
                breweryName:"",
                breweryAddress: "",
                breweryPhoneNumber: "",
                breweryWebsite: "",
                breweryDateEstablished:"",
                breweryHistory: "",
                breweryApproved:false
            }
        }
    },
    methods: {
        resetForm(){
            this.newBeer = {};
            this.showForm = false;
        },
        
        submitForm(){
            const newBrewery = {
                BreweryName:this.brewery.breweryName,
                BreweryAddress: this.brewery.breweryAddress,
                PhoneNumber: this.brewery.breweryPhoneNumber,
                Website: this.brewery.breweryWebsite,
                DateEstablished: this.brewery.breweryDateEstablished,
                History: this.brewery.breweryHistory,
                Approved:this.breweryApproved
                };
                BreweryService.addBrewery(newBrewery).then(response=> {
                console.log(response); 
                this.$router.push(`/`); })
                
               
            
        },

    }//closes methods
    
}
</script>     

<style>
body{
    background-color: goldenrod;
    
}
#create-brewery-form{
    background-color: goldenrod;
    width: 100;
    padding: 10px;
    border-radius: 25px;
    text-align: center;
    margin-left: 10px;
    font-weight: bold;
    font-size: larger;
}
.beer-submit-button{
    color: black;
}
.add-brewery-text{
    font-size: larger;
    font-weight: bold;
}
</style>