<template>
  <div id="app">
      
    
   
   <!--  </div> 
    --> <router-view />
  </div>
</template>

<style scoped>

/*  #nav {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
 border-radius: 25px; 
  display: grid;
  grid-template-columns: auto auto auto auto;
  grid-template-areas: 
    "home addButton deleteButton loginOrOut"
  ; 
  text-align: center;
  background: repeating-conic-gradient(lightblue 0% 25%, white 0% 50%) 50% / 20px 20px;
  border-radius: 25px;
  border-color: black;
  border-style: groove;
   margin: 0px;
  padding:0px;
  grid-area: navBar;
}*/
.add{
  grid-area: addButton;

}
.delete{
  grid-area: deleteButton;
}
#loginOrOut {
  grid-area: loginOrOut;

}
#home{
  grid-area: home;

}
/* .divider{
    width:50px;
    height:auto;
    display:inline-block;
} */
</style>
