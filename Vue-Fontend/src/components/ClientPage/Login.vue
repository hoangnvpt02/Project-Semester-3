<template>
<div>
  <div id="body-login">
    <div class="login-box">
      <h2>Login</h2>
      <form>
        <div class="user-box">
          <input v-model="form.userName"
            type="text" 
            name=""
            @blur="this.validateUserName()"
            v-bind:class="{'is-invalid':errors.userName}"
            >
          <label>Username</label>
          <div class="invalid-feedback">{{ errors.userName }}</div>
        </div>
        <div class="user-box">
          <input v-model="form.password" 
            type="password" 
            name="" 
            @blur="validatePassword()"
            v-bind:class="{'is-invalid':errors.password}" 
            >
          <label>Password</label>
          <div class="invalid-feedback">{{ errors.password }}</div>
        </div>
        <a class="button" @click="clickButtonLogin(form)">
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          Login
        </a>
        <div style="text-align: center;">
          <a href="/register">Create account ?</a>
        </div>
      </form>
    </div>
  </div>
</div>
</template>

<script>
import AuthenticationService from '@/services/AuthenticationService';

export default {
  data() {
    return {
      errors: {
        userName: '',
        password: ''
      },
      form: {
        userName: '',
        password: ''
      },
    }
  },
  methods: {
    validate() {
      this.errors = {
        userName: '',
        password: ''
      }
      if (this.validateUserName() && this.validatePassword()) {
        return true;
      }
      return false;
    },
    validateUserName() {
      if (!this.form.userName) {
        this.errors.userName = "Username is required";
        return false;
      }
      this.errors.userName = "";
      return true;
    },
    validatePassword() {
      if (!this.form.password) {
        this.errors.password = "Password is required";
        return false;
      }
      var passw = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{6,}$/;
      if(!this.form.password.match(passw)) 
      { 
        this.errors.password = "Password must have at least 6 characters 1 uppercase letter 1 special character and 1 number";
        return false;
      }
      this.errors.password = "";
      return true;
    },
    clickButtonLogin(form) {
      var result = this.validate();
      if (result) {
        AuthenticationService.login(form)
        .then(response => {
          console.log(response);
          if (response.data.token) {
            localStorage.setItem('user', JSON.stringify(response.data));
          }
          window.location.href = "http://localhost:4001/home";
          return response.data;
        })
        .catch(e => {
          alert("Username or password incorrect");
        })
      }
    },

  },
}
</script>

<style>
@import '../../assets/css/login.css';
@import '../../assets/css/bootstrap.css';
</style>
