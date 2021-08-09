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
            </ul>
        </div>
        <h3>Submit a review for {{beer.beerName}}:</h3>
        <a href="#" v-on:click.prevent="showForm = true" v-if="!showForm">Show Form</a>
        <form v-on:submit.prevent="addNewReview" v-if="showForm === true">
            <div class="form-element">
                <label for="rating" >Rating:</label>
                <select id="rating" v-model.number="newReview.rating">
                    <option value="1">1 Bottles</option>
                    <option value="2">2 Bottles</option>
                    <option value="3">3 Bottles</option>
                    <option value="4">4 Bottles</option>
                    <option value="5">5 Bottles</option>
                </select>
            </div>
            <div class="form-element">
                <label for="review">Review:</label>
                <textarea id="review" type="text" v-model="newReview.review">                    </textarea>
            </div>
            <input type="submit" value="Save"/>
            <input type="button" value="Cancel" v-on:click="resetForm"/>
        </form> 
    </div>
</template>

<script>
import BeerAndReviewService from '../services/BeerAndReviewService';

export default { 
    name:'beer-and-reviews',
    components: {},
    data() {
        return {
            //PLACEHOLDER!
        };
    },
    created() {
        this.retrieveBeer();
        this.retrieveReviews();
    },
    methods: {    
        retrieveBeer() {
            BeerAndReviewService.getBeer(this.$route.params.beerId).then(response=> {
                console.log(response); 
                this.$store.commit("SET_BEER", response.data); 
            });
        },
        retrieveReviews() {
            BeerAndReviewService.getBeerReviews(this.$route.params.beerId).then(response=> {
                console.log(response);
                this.$store.commit("SET_REVIEWS", response.data);
            });
        },
        addNewReview() {
            this.reviews.unshift(this.newReview);
            this.resetForm();
        },
        resetForm(){
            this.newReview = {};
            this.showForm = false;
        },
    },
    computed: {
        beer() {
            return this.$store.state.beer;
        },
        beerReview(){ 
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