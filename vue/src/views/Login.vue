<template class="template">

<body class="body"> 
  <!--  -->
      
  <img class="backgroundimage" src="../images/image.png" width="100%" height="100%" alt="Beer next to hops">
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      
      <router-link :to="{ name: 'register' }" tag="button">Need an account?</router-link>
      
      <button type="submit">Sign in</button>
      </form>
  </div>
</body>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>

@import url('https://fonts.googleapis.com/css2?family=Lobster&display=swap');

@import url('https://fonts.googleapis.com/css2?family=Lobster&family=Open+Sans&display=swap');

/* img {
  opacity: 0.9;
} */
.menuButtons{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  background: repeating-conic-gradient(lightblue 0% 25%, white 0% 50%) 50% / 20px 20px;
  border-radius: 25px;
  border-color: black;
  border-style: groove;
}
backgroundimage {
  min-height: 100%;
  min-width: 1024px;
  width:100%;
  height: auto;
  position: fixed; /* THIS IS WHAT IS MESSING UP THE APP.VUE */
  top: 0;
  left: 0;
  opacity: 0.6;
  z-index: -1;
  border-style: groove;
  border-radius: 25px;
  border-color: black;
  margin: 0px;
  padding:0px; 
}

#login {
  display:flex;
  justify-content: center;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  
}

h1 {
  font-family: 'Lobster', cursive;
  font-size: 84px;
  grid-area: h1;
}

.sr-only { /* Labels for username and password input boxes */
  font-family: 'Open Sans', sans-serif;
  font-size: 36px;
  display: flex;
  justify-content: center;
  align-items:stretch;
  grid-area: userPassInput;
}

input {
  font-family: 'Open Sans', sans-serif;
  resize: horizontal;
  width: 465px;
  height: 25px;
  text-align: center;
  align-items: center;
  justify-content: center;
}

input:active {
  width: auto;
}

input:focus {
  min-width: 200px
}

.return-button {
  display: flex;
  justify-content: center;
  align-items: center;
  grid-area: returnButton;
}

button {
  padding: 8px 32px;
  font-family: 'Open Sans', sans-serif;
  justify-content: center;
  align-items: center;
  text-align: center;
  display: block; 
  grid-area: button; 
}

@media screen and (max-width: 450px) {
  .template {
    grid-template-areas: 
      "h1"
      "userPassInput"
      "returnButton"
      "button"
  ;
      grid-template-columns: auto;
  }
}
</style>