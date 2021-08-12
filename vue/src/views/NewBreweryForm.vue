<template>
<div id="page-layout">
    <img class="backgroundimage" src="../images/newBreweryFormBackground.jpg" width="100%" height="100%" alt="beer and hops on top">
    <div>
    <h1 id="nbf-brewery-name">Add A Brewery</h1>
    </div>
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
            <label for="breweryUrl">Brewery Image URL:</label><br>
            <input type="text" id="breweryUrl" name="breweryUrl" v-model="brewery.breweryUrl" size="40"><br>
            <br>
            <button type="submit" id="beer-submit-button" style="border: 0; background: transparent">
                <img id="beer-mug" src="@/images/editedbutton.gif" width="55" height="65" alt="add brewery" />
               <div class="add-brewery-text">Add Brewery</div>
               </button>           
        </form>
    </div>
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
                breweryApproved:false,
                breweryUrl:""
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
                Approved:this.brewery.breweryApproved,
                BreweryUrl:this.brewery.breweryUrl
                };
                BreweryService.addBrewery(newBrewery).then(response=> {
                console.log(response); 
                this.$router.push(`/`); })
                
               
            
        },

    }//closes methods
    
}
</script>     

<style>
#nbf-brewery-name{
  text-align: center;
  background-color: goldenrod;
  font-family: 'Lobster', cursive;
  font-size: 84px;
  padding: 25px;
  background: linear-gradient(
    to right,
    transparent,
    goldenrod,
    goldenrod,
    goldenrod,
    goldenrod,
    transparent);
}
.backgroundimage{
  margin: 0;
  min-height: 100%;
  min-width: 1024px;
  width:100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  opacity: 0.8;
  z-index: -1;
}
#page-layout{
    text-align: center;
    display:block;
}
#create-brewery-form{
    margin: 10px;
    background-color: goldenrod;
    width:max-content;
    padding: 10px;
    border-radius: 25px;
    text-align: center;
    margin-left: 10px;
    font-weight: bold;
    font-size: larger;
    display: inline-block;
    
}
#beer-submit-button, #beer-mug{
    text-align: center;
    color: black;
    align-items: center;
    margin: auto;
    display: inline-block;
}
.add-brewery-text{
    text-align: center;
    font-size: larger;
    font-weight: bold;
}
</style>