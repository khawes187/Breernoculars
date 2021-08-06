<template>
    <div>
        <h2>{{beer.beerName}}</h2>
        <div>
            <ul class="beer">
                <li>Style:{{beer.beerType}}</li>
                <li>ABV:{{beer.abv}}</li>
                <li>{{beer.beerDescription}}</li>
                <li>Seasonal? - {{beer.seasonal}}</li>
            </ul>
            <ul class="userReviews" v-for="review in reviews" v-bind:key="review.reviewBody">
                <p>User: {{user.username}}</p>
                <p>{{review.reviewBody}}</p>
            <ul>
        </div>
    </div>
</template>

<script>
import BeerAndReviewService from '../services/BeerandReviewService';

export default{ //I HAVE NO IDEA WHAT I HAVE DONE OR WHAT THE CONSEQUENCES MAY BE
        name:'beer-and-reviews',
    
        //data(){
            //return {
                //PLACEHOLDER!
            //};
        //},
    created() {
        this.retrieveBeer();
        this.retrieveReviews();
    },
    methods: {    
        retrieveBeer() {
            BeerAndReviewService.getBeer(this.$route.params.beerId).then(response=> {
                console.log(response); //Is "SET_BEERS" supposed to be plural if I want a single beer and 
                this.$store.commit("SET_BEERS", response.data); //is this supposed to be a separate mutation?
            });
        },
        retrieveReviews() {
            BeerAndReviewService.getBeerReviews(this.$route.params.beerId).then(response=> {
                console.log(response);
                this.$store.commit("SET_REVIEWS", response.data);
            })
        }
    },
    computed: {
        beer() {
            return this.$store.state.beer;
        },
        beerReview(){ //really not sure about these
            return this.$store.state.beerReviews;
        },
        reviews(){
            return this.$store.state.reviews;
        }
    }
}    
</script>

<style>
</style>