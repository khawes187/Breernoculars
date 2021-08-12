<template>
    <div id="b-r-body" content="width=device-width, initial-scale=1.0">
        <h2 id="b-r-h2">{{beer.beerName}}</h2>
        <div>
          <div>
            <img v-bind:src="beer.beerUrl" id="bar-beer-photo" alt="beer list photo">
          </div>
            <ul class="b-r-beer">
                <li id ="b-r-style">Style:&nbsp;{{beer.beerType}}</li><br><br>
                <li id ="b-r-abv">ABV:&nbsp;{{beer.abv}}</li><br><br>
                <li id ="b-r-description">Description:&nbsp;{{beer.beerDescription}}</li><br><br>
                <li id ="b-r-seasonal">Seasonal? &nbsp; {{beer.seasonal}}</li><br><br>
            </ul>
            <ul class="b-r-userReviews" id="b-r-reviewList" v-for="review in this.$store.state.reviews" v-bind:key="review.beerReviewId">
                <p>User: {{currentUser.username}}</p>
                <p>{{review.reviewBody}}</p>
            </ul>
        </div>
        <!-- <h3 id="b-r-submit">Submit a review for {{beer.beerName}}:</h3> -->
        <a href="#" id="b-r-show-form" v-on:click.prevent="showForm = true" v-if="!showForm">Submit a review for {{beer.beerName}}</a>
        <form v-on:submit.prevent="submitForm" v-if="showForm === true" id="b-r-form-shown">
            <div id="form-element-rating">
                <label for="rating" >Rating:</label>
                <select id="rating" v-model="newReview.rating">
                    <option value="1">1 Bottles</option>
                    <option value="2">2 Bottles</option>
                    <option value="3">3 Bottles</option>
                    <option value="4">4 Bottles</option>
                    <option value="5">5 Bottles</option>
                </select>
            </div>
            <br>
            <div id="form-element-review">
              
                <label for="review">Review:</label>
                <textarea id="review" type="text" v-model="newReview.reviewBody">                    </textarea>
            </div>
            
            <button type="submit" id="beer-submit-button" style="border: 0; background: transparent"  v-on:click.prevent="resetForm" value="Save">
                <img src="@/images/editedbutton.gif" width="55" height="65" alt="Submit review" />
               <div class="submit-review-text">Submit Review</div>
               </button>     
            <br>
            <button type="submit" id="beer-cancel-button" style="border: 0; background: transparent"  v-on:click.prevent="resetForm" value="Cancel">
                <img src="@/images/editedbutton.gif" width="55" height="65" alt="Submit review" />
               <div class="Cancel">Cancel</div>
               </button>  
        </form> 
        <button id="delete-beer-button" v-on:click="showImage = !showImage">Brewer Options</button>
        <div id="delete-button" v-if="showImage===true">
        <delete-a-beer />
        </div>
    </div>
</template>

<script>
import BeerAndReviewService from '../services/BeerAndReviewService';
import DeleteABeer from '../components/DeleteABeer.vue';

export default { 
    name:'beer-and-reviews',
    components: {DeleteABeer},
    data() {
        return {
            showForm: false,
            showImage:false,
            newReview: {
                userId:'',
                beerId:'',
                rating:'',
                reviewBody:'',
            }

        };
    },
    created() {
        this.retrieveBeer();
        this.retrieveReviews();
    },
    methods: {    
        submitForm(){
            const newNewReview = {
                userId: this.currentUser.userId,
                beerId: parseInt(this.$route.params.beerId),
                rating: parseInt(this.newReview.rating),
                reviewBody: this.newReview.reviewBody
                }
            BeerAndReviewService.postBeerReview(newNewReview).then(response=> {
                console.log(response);
                window.location.reload();
            })
            
        },
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
        resetForm(){
            this.newReview = {};
            this.showForm = false;
        },
    },
    computed: {
        beer() {
            return this.$store.state.beer;
        },
        reviews(){ 
            return this.$store.state.reviews;
        },
        currentUser() {
            return this.$store.state.user;
        },
    }
}    
</script>


<style>
#b-r-body{
  margin: 0;
  background-image: url(../images/BreweryInfoPage.jpg);
  height:100%;
  width:100%;
  display: grid;
  grid-template-columns: auto auto;
  grid-template-areas: 
    "beerName beerName"
    "beerInfo beerInfo"
    "reviewlist reviewlist"
    "reviewHeader reviewHeader"
    "form from"
    "form2 form2"
    "deleteBeerButton deleteBeerButton"
    "deleteBeer deleteBeer"
    
}
#b-r-h2{
  display: grid;
  grid-area: beerName;
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
#bar-beer-photo{
  border-style: solid;
  border-width:thick;
  border-color: goldenrod;
  border-radius: 25px;
  background-color: goldenrod;
  text-align: center;
  object-fit:contain;
  width:max-content;
  width:400px;
  height: auto;
  display: block;
  margin-left: auto;
  margin-right: auto
}
.b-r-beer{
  margin: 10px;
  padding: 10px;
  border-radius: 25px;
  background-color: goldenrod;
  color: black;
  width: 40%;
  display: inline-block;
  grid-area: beerInfo;
  text-align: center;

}
#b-r-style{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;
}
#b-r-abv{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;
}
#b-r-description{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  word-wrap: break-word;
  width: 100%;
  padding:5px;
  border-radius: 35px;
}
#b-r-seasonal{
  display: grid;
  background-color: goldenrod;
  color: black;
  display: inline;
  width: 100%;
  padding:5px;
  border-radius: 35px;
}
#b-r-reviewList{
  margin: 10px;
  background-color: goldenrod;
  color: black;
  display: inline-block;
  padding: 10px;
  border-radius: 25px;
  text-align: center;
  width: 40%;
  display: grid;
  grid-area: reviewlist;
}
#b-r-submit{
  width:max-content;
  margin: 10px;
  background-color: goldenrod;
  color: black;
  display: inline;
  padding:5px;
  border-radius: 35px;
  display: grid;
  grid-area: reviewHeader;
}
#b-r-show-form{
  margin: 10px;
  margin-top: -4px;
  background-color: goldenrod;
  width:max-content;
  padding:5px;
  border-radius: 35px;
  color: black;
  display: grid;
  grid-area: form;
}
#b-r-form-shown{
  margin: 10px;
  background-color: goldenrod;
  width:max-content;
  padding:5px;
  border-radius: 35px;
  padding: 25px;
  display: grid;
  grid-area: form2;
  grid-template-columns: auto auto;
  grid-template-areas: 
    "rating rating"
    "review review"
    "submit cancel";
}
#form-element-rating{
  text-align: center;
  display: grid;
  grid-area: rating;
}
#form-element-review{
  text-align: center;
  display: grid;
  grid-area: review;
}
#beer-submit-button{
  display: grid;
  grid-area: submit;
}
#beer-cancel-button{
  display: grid;
  grid-area: cancel;
}
#delete-beer-button{
  width:max-content;
  margin: 10px;
  background-color: goldenrod;
  color: black;
  display: inline;
  padding:5px;
  border-radius: 35px;
  display: grid;
  grid-area: deleteBeerButton;
}
#delete-button{
  display: grid;
  grid-area: deleteBeer;
  margin-bottom: 10px;
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
 
}
</style>