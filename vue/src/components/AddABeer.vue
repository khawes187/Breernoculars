<template>
    <div id="create-beer-form">
        <form input type="text">
            <label for="beerName">Beer Name:</label><br>
            <input type="text" id="beerName" name="beerName"><br>
            <label for="beerImg">URL For Beer Image:</label><br>
            <input type="text" id="beerImg" name="beerImg"><br>
            <label for="beerType">Beer Type:</label><br>
            <input type="text" id="beerType" name="beerType"><br>
            <label for="beerAbv">Beer ABV:</label><br>
            <input type="text" id="beerAbv" name="beerAbv"><br>
            <label for="beerDescription">Beer Description:</label><br>
            <input type="text" id="beerDescription" name="beerDescription"><br>
            <label for="beerSeasonal">Is It Seasonal?:</label><br>
            <input type="text" id="beerSeasonal" name="beerSeasonal"><br>           
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
            beerName: this.beer.beerName,
            beerImg: this.beer.beerImg,
            beerType: this.beer.beerType,
            beerAbv: this.beer.abv,
            beerDescription: this.beer.beerDescription,
            beerSeasonal: this.beer.seasonal
        };
    },
    created() {
        this.addNewBeer();
    },
    methods: {
        addNewBeer() {
            AddBeerService.addBeer(this.$route.params.newBeer).then(response=> {
                console.log(response); 
                this.$store.commit("ADD_BEER", response.data); 
            });
        }, 
    },        
        resetForm(){
            this.newReview = {};
            this.showForm = false;
        },
    computed: {
        beer() {
            return this.$store.state.beer;
        }
    }
}
</script>     

<style>

</style>