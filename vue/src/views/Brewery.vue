<template>
<body>
    <h1>Brewery Name</h1> <!-- Do we want to just make this a link to the bewery? -->
    
    <h2>Brewery Information</h2>
    <ul class="breweryInfo">
        <li>Date Established</li>
        <li>Brewery Phone</li>
        <li>Brewery Address</li>
        <li>Brewery Hours</li>
        <li>Brewery History/Fun Facts</li>
        <li>Brewery Webpage</li>
    </ul>
    <p class="firstbeer">First Beer Name</p>
    <p class="secondbeer">Second Beer Name</p>
    
</body>        
</template>

<script>
export default {
    
}
</script>   

<style>
h1{
    text-align: center;
    grid-area: header;
}
h2{
    grid-area: breweryName;
}
.breweryInfo{
    grid-area:breweryInfo;
}
.firstbeer{
    grid-area: firstBeer;
}
.secondbeer{
    grid-area: secondBeer;
}
body{
  display: grid;
  grid-template-columns: auto auto auto;
  grid-template-areas: 
    "header header header"
    "breweryName . ."
    "breweryInfo firstBeer firstBeer"
    "breweryInfo firstBeer firstBeer"
    "breweryInfo secondBeer secondBeer"
    "breweryInfo secondBeer secondBeer"

}
</style>