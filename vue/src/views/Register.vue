<template>
<body>
  <img class="backgroundimage" src="../images/register.jpg" width="100%" height="100%" alt="Beer pouring from a tap">
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
        value="brewer"
        v-model="user.role"
        required
      />
      <label class="brewer" for="roleBrewer">Brewer</label>
      <router-link :to="{ name: 'login' }" tag="button">Have an account?</router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
    </form>
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
              this.$router.push({
                path: '/login',
                query: { registration: 'success' },
              });
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
.backgroundimage {
  min-height: 100%;
  min-width: 1024px;

  width:100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  opacity: 0.6;
}
#register {
  display: grid;
  /* justify-content: center; */
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  grid-template-columns: auto auto;
  grid-template-areas: 
    "createAccount createAccount"
    "loginName loginName"
    "usernameInput usernameInput"
    "loginPass passwordInput"
    "brewLover brewer"
    "button button";
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
  align-items:stretch;
  grid-area: loginName
}
label.sr-only-pw {
  font-family: 'Open Sans', sans-serif;
  font-size: 36px;
  display: flex;
  justify-content: center;
  align-items:stretch;
  grid-area: loginPass
}

input#username.form-control {
  font-family: 'Open Sans', sans-serif;
  resize: horizontal;
  width: 465px;
  height: 25px;
  text-align: center;
  /* align-items: center;
  justify-content: center; */
  grid-area:usernameInput
}

input#password.form-control {
  font-family: 'Open Sans', sans-serif;
  resize: horizontal;
  width: 465px;
  height: 25px;
  text-align: center;
  align-items: center;
  justify-content: center;
  grid-area: passwordInput;
}

label.brewlover{
  grid-area: brewLover;
}
label.brewer{
  grid-area: brewer;
}
/* button {
  padding: 8px 32px;
  font-family: 'Open Sans', sans-serif;
  justify-content: center;
  align-items: center;
  text-align: center;
  display: block;  
  grid-area: button;
} */

/* input:active {
  width: auto;
}

input:focus {
  min-width: 200px
} */


</style>
