<template>
    <div id="b-r-body">
        <h2 id="b-r-h2">{{this.$store.state.beer.beerName}}</h2>
        <div>
            <ul class="b-r-beer">
                <li id ="b-r-style">Style:{{this.$store.state.beer.beerType}}</li>
                <li id ="b-r-abv">ABV:{{this.$store.state.beer.abv}}</li>
                <li id ="b-r-description">{{this.$store.state.beer.beerDescription}}</li>
                <li id ="b-r-seasonal">Seasonal? - {{this.$store.state.beer.seasonal}}</li>
            </ul>
            <ul class="b-r-userReviews" v-for="review in this.$store.state.reviews" v-bind:key="review.BeerReviewId">
                <p>User: {{review.UserId}}</p>
                <p>{{review.ReviewBody}}</p>
            </ul>
        </div>
        <h3 id="b-r-submit">Submit a review for {{beer.beerName}}:</h3>
        <a href="#" v-on:click.prevent="showForm = true" v-if="!showForm">Show Form</a>
        <form v-on:submit.prevent="addNewReview" v-if="showForm === true">
            <div class="form-element">
                <label for="title">Title:</label>
                <input id="title" type="text" v-model="newReview.title">
            </div>
            <div class="form-element">

                <label for="review">Review:</label>
                <textarea id="review" type="text" v-model="newReview.review">                    </textarea>
            </div>
            <input type="submit" v-on:click="addNewReview()" value="Save"/>
            <input type="button" value="Cancel" v-on:click.prevent="resetForm"/>
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
            showForm: false,
            newReview: {
                productID: 0,
                reviewer: "",
                title: "",
                rating: 0,
                review: ""
            }

        };
    },
    created() {
        this.retrieveBeer();
        this.retrieveReviews();
    },
    methods: {    
        // submitForm(){
        //     const newReview = {
        //         rating: this.beerReview.rating,
        //         reviewBody: this.beerReview.reviewBody,
        //     };
        // },
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
            const productID = this.$route.params.id;
            this.newReview.productID = productID;
            this.$store.commit("ADD_REVIEW", this.newReview);
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
            return this.$store.state.reviews.filter(reviews => reviews.beerId == this.$store.state.beer.beerId);
        },
    }
}    
</script>

<style>
#add-review-button{
  background-color: goldenrod;
  padding: 10px;
  border-radius: 25px;
}
#b-r-h2{
  display: grid;
  text-align: center;
  grid-area: breweryName;
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
#b-r-generalInfo{
  /* display: grid;  */
  margin-left: 10px;
  width: 40%;
  padding-left: 50px;
  grid-area: generalInfo;
  padding: 5px;
  border-radius: 25px;
  background-color: goldenrod;
  color: black;
  display: inline;
  text-align: center;
}
#b-r-style{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;;
  grid-area: about;
}
#b-r-abv{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;;
  grid-area: about;
}
#b-r-description{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;;
  grid-area: about;
}
#b-r-seasonal{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;;
  grid-area: about;
}
#b-r-submit{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;;
  grid-area: about;
}
#b-r-reviewList{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 10px;
  border-radius: 25px;
  text-align: center;
}
#b-r-beers{
  margin: 10px;
  padding: 10px;
  border-radius: 25px;
  background-color: goldenrod;
  color: black;
  width: 40%;
  /* display: inline-block; 
  border-radius: 25px;
  
  margin: 0;
  text-align: center;
 grid-template-columns: auto auto;
   grid-template-areas: 
    "name name"
    "photo photo"
    "type type"
    "abv abv"
    "description description"
    "seasonal seasonal"; */
} 
#b-r-beer-name{ 
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 5px;
  border-radius: 25px;
  display: grid;
  grid-area: name;
  text-align: center;
}
#b-r-beer-photo{
  margin-left: 10%;
  margin-right: 10%;
  display: grid;
  grid-area: photo;
}
#b-r-beer-type{
  text-align: center;
  display: grid;
  grid-area: type;
}
#b-r-beer-abv{
  text-align: center;
  display: grid;
  grid-area: abv;
}
#b-r-beer-description{
  text-align: center;
  
  display: grid;
  grid-area: description;
}
#b-r-beer-seasonal{
  text-align: center;
  display: grid;
  grid-area: seasonal;
}
#b-r-breweryInfo{
  margin: 10px;
  width:30%;
  padding-left: 50px;
  padding-top: 20px;
  background-color: goldenrod;
  border-radius: 25px;
  grid-area:breweryInfo;
}

#b-r-brewery-photo {
  display: grid;
  grid-area: breweryPhoto;
  justify-content: center;
}
#b-r-body{
  margin: 0;
  background-image: url(../images/BreweryInfoPage.jpg);
  height:100%;
  width:100%;
  display: grid;
  grid-template-columns: auto auto;
  grid-template-areas: 
    "breweryName breweryName"
    "breweryPhoto breweryPhoto"
    "generalInfo generalInfo"
    "address website"
    "address phone"
    "about about"
    "date date"
}
@media screen and (max-width: 800px) {
  #b-r-breweryInfo, #b-r-beers{
    width: 90%;
  }
  #b-r-breweryInfo {
    width: 90%;
    padding: 0;
    text-align: center;
  }
  #b-r-beer-photo{
    margin-left: 10%;
    margin-right: 10%;
    width: 60%;
  }
  #b-r-body{
  margin: 0;
  background-image: url(../images/BreweryInfoPage.jpg);
  height:100%;
  width:100%;
  }
}
</style>