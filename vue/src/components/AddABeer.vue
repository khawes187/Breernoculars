<template>
    <div id="create-beer-form">
        <form input type="text" v-on:submit.prevent="submitForm">
            <h3 id="Add-Beer-name">Add A Beer</h3>
            <label for="beerName">Beer Name:</label><br>
            <input type="text" id="beerName" name="beerName" v-model="beer.beerName"><br>
            <br>
            <label for="beerImg">URL For Beer Image:</label><br>
            <input type="text" id="beerImg" name="beerImg" v-model="beer.beerUrl"><br> <!-- CHANGED THIS TO BEERURL -->
            <br>
            <label for="beerType">Beer Type:</label><br>
            <input type="text" id="beerType" name="beerType" v-model="beer.beerType"><br>
            <br>
            <label for="beerAbv">Beer ABV:</label><br>
            <input type="text" id="beerAbv" name="beerAbv" v-model="beer.abv"><br>
            <br>
            <label for="beerDescription">Beer Description:</label><br>
            <input type="text" id="beerDescription" name="beerDescription" v-model="beer.beerDescription"><br>
            <br>
            <label for="beerSeasonal">Is It Seasonal? (yes/no):</label><br>
            <input type="text" id="beerSeasonal" name="beerSeasonal" v-model="beer.Seasonal"><br>
            <br>
            <button type="submit" id="beer-submit-button" style="border: 0; background: transparent">
                <img src="@/images/editedbutton.gif" width="55" height="65" alt="add beer" />
               <div class="add-beer-text">Add A Beer</div>
               </button>           
        </form>
    </div>
</template>

<script>
import AddBeerService from '../services/AddBeerService';

export default {
    name:'Add-a-beer',
    components: {},
    data() {
        return {
            beer: {
                beerName:'',
                beerType: '',
                abv: '',
                beerDescription:'',
                beerBreweryId: '',
                Seasonal:'',
                beerUrl:''
            }
        }
    },
    methods: {
        /*addNewBeer() {
            AddBeerService.addBeer(this.$route.params.newBeer).then(response=> {
                console.log(response); 
                
            });
        }, */
        resetForm(){
            this.newBeer = {};
            this.showForm = false;
        },
        
        submitForm(){
            const newBeer = {
                beerName: this.beer.beerName,
                beerType: this.beer.beerType,
                abv: parseInt(this.beer.abv),
                beerDescription: this.beer.beerDescription,
                beerBreweryId: parseInt(this.$route.params.breweryId),
                Seasonal: this.beer.Seasonal,
                beerUrl: this.beer.beerUrl,
                }
            AddBeerService.addBeer(newBeer).then(response=> {
                console.log(response);
                window.location.reload();
            })
            
        },

    }//closes methods
    
}
</script>     

<style>
#Add-Beer-name{
  border-style: solid;
  border-width:thick;
  border-color: black;
  border-radius: 25px;
}
#create-beer-form{
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
.add-beer-text{
    color: black;
    font-size: larger;
    font-weight: bold;
}
</style>