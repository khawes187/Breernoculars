<template>
    <div id="delete-beer-form">
        <button class="delete-beer-form" v-on:click="deleteBeer" style="border: 0; background: transparent">
          <img src="@/images/editedbutton.gif" width="55" height="65" alt="Go Home" />
          <div class="homeText">Delete Current Beer</div>
        </button>
    </div>
</template>

<script>
import AddBeerService from '../services/AddBeerService';

export default {
    name:'delete-a-beer',
    components: {},
    data() {
        return {
            beerId: "",
        }
    },
    methods: {
        
        deleteBeer(){

            AddBeerService.deleteBeer(parseInt(this.$route.params.beerId)).then(response=> {
                console.log(response);
                this.$router.push(`/brewery/${this.$route.params.breweryId}`);
                window.location.reload();             
            })
            
        },

    }//closes methods
    
}
</script>     

<style>
#delete-beer-form{
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