<template>
    <div id="create-beer-form">
        <form input type="text" v-on:sumbit.prevent="submitForm">
            <label for="beerName">Beer Name:</label><br>
            <input type="text" id="beerName" name="beerName" v-model="beer.beerName"><br>
            <br>
            <label for="beerImg">URL For Beer Image:</label><br>
            <input type="text" id="beerImg" name="beerImg" v-model="beer.beerImg"><br>
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
            <input type="text" id="beerSeasonal" name="beerSeasonal" v-model="beer.beerSeasonal"><br>
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
                beerImg: '',
                beerType: '',
                abv: '',
                beerDescription:'',
                beerBreweryId: '',
                Seasonal:''
            }
        }
    },
    methods: {
        addNewBeer() {
            AddBeerService.addBeer(this.$route.params.newBeer).then(response=> {
                console.log(response); 
                
            });
        }, 
        resetForm(){
            this.newBeer = {};
            this.showForm = false;
        },
        
        submitForm(){
            const newBeer = {
                beerName:this.beer.beerName,
                beerImg: this.beer.beerImg,
                beerType: this.beer.beertype,
                abv: this.beer.abv,
                beerDescription: this.beer.beerDescription,
                beerBreweryId: this.beer.beerBreweryId,
                Seasonal:this.beer.Seasonal
                }
            AddBeerService.addBeer(newBeer).then(response=> {
                console.log(response);})
            
        }

    }//closes methods
    
}
</script>     

<style>
#create-beer-form{
    background-color: goldenrod;
    width: fit-content;
    padding: 10px;
    border-radius: 25px;
    text-align: center;
    margin-left: 10px;
    font-weight: bold;
}
.add-beer-text{
    color: black;
}
</style>