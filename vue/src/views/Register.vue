<template>
<body class="body" content="width=device-width, initial-scale=1.0">
  <!-- <div id="imageAndText">
   --><img class="backgroundimage" src="../images/registerpage.jpg" width="100%" height="100%" alt="Beer pouring from a tap">
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <label for="username" class="sr-only-un">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only-pw">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <div>
      <input
        type="radio"
        id="roleUser"
        class="form-control"
        name="set_role"
        value="user"
        v-model="user.role"
        required
      />
      <label class="brewlover" for="roleUser">Brew-Lover</label>
      <input
        type="radio"
        id="roleBrewer"
        class="form-control"
        name="set_role"
        value="potentialBrewer"
        v-model="user.role"
        required
      />
      <label class="brewer" for="roleBrewer">Brewer</label>
      
      
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="sumbit" />
          <div class="createAccount">Create Account</div>
      </button>
<!--       <router-link :to="{ name: 'login' }" tag="button">
        <img src="@/images/editedbutton.gif" width="55" height="65" alt="return to login" />
          <div class="ReturnLogin">Return to Login</div></router-link> -->
        
      </div>
    </form>
    
 <!--  </div> -->
</div>
</body>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: '',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              if (this.user.role == 'user') {
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
              }
              else {
                this.$router.push({
                path: '/newBreweryForm',
                query: { registration: 'success' },
              });
              }
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style scoped>

.backgroundimage{
  margin: 0;
  min-height: 100%;
  min-width: 1024px;
  width:100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  opacity: 0.8;
  z-index: -1;
}

#register.text-center {
  display:flex;
  justify-content: center;
  margin: 10px;
  margin-left: auto;
  margin-right: auto;
  width:max-content;
  border-style: solid;
  border-width:thick;
  border-color: black;
  border-radius: 25px;
  background-color: goldenrod;
  padding: 5px;
}
 
h1 {
  font-family: 'Lobster', cursive;
  font-size: 84px;
  grid-area: createAccount;
}

label.sr-only-un {
  font-family: 'Open Sans', sans-serif;
  font-size: 36px;
  display: flex;
  justify-content: center;
  align-items:auto;
  grid-area: loginName
}
label.sr-only-pw {
  font-family: 'Open Sans', sans-serif;
  font-size: 36px;
  display: flex;
  justify-content: center;
  align-items:auto;
  grid-area: loginPass
}

#username.form-control {
  display: block;
  margin : 0 auto;
  font-family: 'Open Sans', sans-serif;
  /* resize: horizontal; */
  width: 465px;
  height: 25px;
  text-align: center;
  grid-area:usernameInput;
  border-radius: 10px;
}

#password.form-control {
  display: block;
  margin : 0 auto;
  font-family: 'Open Sans', sans-serif;
  resize: vertical;
  width: 465px;
  height: 25px;
  text-align: center;
  grid-area: passwordInput;
  border-radius: 10px;
}

#confirmPassword.form-control {
  display: block;
  margin : 0 auto;
  font-family: 'Open Sans', sans-serif;
  resize: vertical;
  width: 465px;
  height: 25px;
  text-align: center;
  grid-area: passwordInput;
  border-radius: 10px;
}

 input[type='radio'], label.brewlover, label.brewer{
   text-align:justify; 
   display:flex;
   flex-direction:column;
   align-items:center;
   justify-content:center;
   vertical-align: top;
   width: 100%;
 }

label.brewlover{
  width:100%;
  margin:auto;
  font-family: 'Open Sans', sans-serif;
  grid-area: brewLover;
}
label.brewer{
  margin: auto;
  font-family: 'Open Sans', sans-serif;
  grid-area: brewer;
}
 button {
  border-style: solid;
  border-width:thick;
  border-color: black;
  border-radius: 25px;
  background-color: goldenrod;
  padding: 10px;
  border-radius: 25px;
  font-weight: bold;
  width: 100%;
 } 

@media screen and (max-width: 450px) {
  .template {
    grid-template-areas: 
      "createAccount"
      "loginName"
      "loginPass"
      "passwordInput"
      "brewlover"
      "brewer"
      "button"
  ;
      grid-template-columns: auto;
  }
}

</style>
