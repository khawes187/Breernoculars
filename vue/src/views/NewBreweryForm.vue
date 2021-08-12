<template>
    <div id="create-brewery-form">
        <form v-on:submit.prevent="submitForm">
            <label for="breweryName">Brewery Name:</label><br>
            <input type="text" id="breweryName" name="breweryName" v-model="brewery.breweryName"><br>
            <br>
            <label for="breweryAddress">Brewery Address:</label><br>
            <input type="text" id="breweryAddress" name="breweryAddress" v-model="brewery.breweryAddress"><br>
            <br>
            <label for="breweryPhoneNumber">Brewery Phone Number:</label><br>
            <input type="text" id="breweryPhoneNumber" name="breweryPhoneNumber" v-model="brewery.breweryPhoneNumber"><br>
            <br>
            <label for="breweryWebsite">Brewery Website:</label><br>
            <input type="text" id="breweryWebsite" name="breweryWebsite" v-model="brewery.breweryWebsite"><br>
            <br>
            <label for="breweryDateEstablished">Brewery Date Established:</label><br>
            <input type="text" id="breweryDateEstablished" name="breweryDateEstablished" v-model="brewery.breweryDateEstablished"><br>
            <br>
            <label for="breweryHistory">Brewery History:</label><br>
            <input type="text" id="breweryHistory" name="breweryHistory" v-model="brewery.breweryHistory"><br>
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
#create-brewery-form{
    background-color: goldenrod;
    width: fit-content;
    padding: 10px;
    border-radius: 25px;
    text-align: center;
    margin-left: 10px;
    font-weight: bold;
}
.beer-submit-button{
    color: black;
}
</style>