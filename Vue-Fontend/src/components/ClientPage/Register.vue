<template>
<div>
  <div id="body-login">
    <div class="login-box">
      <h2>Register</h2>
      <form>
        <div class="user-box">
          <input v-model="form.userName"
            type="text" 
            name=""
            @blur="validateUserName()"
            v-bind:class="{'is-invalid':errors.userName}"
          >
          <label>Username</label>
          <div class="invalid-feedback">{{ errors.userName }}</div>
        </div>
        <div class="user-box">
          <input v-model="form.email"
            type="text" 
            name=""
            @blur="validateEmail()"
            v-bind:class="{'is-invalid':errors.email}"
          >
          <label>Email</label>
          <div class="invalid-feedback">{{ errors.email }}</div>
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
        <div class="user-box">
          <input v-model="form.rePassword" 
            type="password" 
            name="" 
            @blur="validateRePassword()"
            v-bind:class="{'is-invalid':errors.rePassword}" 
            >
          <label>Confirm Password</label>
          <div class="invalid-feedback">{{ errors.rePassword }}</div>
        </div>
        <a @click="clickButtonLogin(form)">
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          Register
        </a>
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
        email: '',
        password: '',
        rePassword: ''
      },
      form: {
        userName: '',
        email: '',
        password: '',
        rePassword: ''
      },
    }
  },
  methods: {
    validate() {
      this.errors = {
        userName: '',
        email: '',
        password: '',
        rePassword: ''
      }
      if (this.validateUserName() && this.validatePassword() && this.validateEmail() && this.validateRePassword()) {
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
      this.errors.password = "";
      return true;
    },
    validateEmail() {
      if (!this.form.email) {
        this.errors.email = "Email is required";
        return false;
      }
      var re = /(.+)@(.+){2,}\.(.+){2,}/;
      if(!re.test(this.form.email.toLowerCase())){
        this.errors.email = "You have entered an not invalid email address";
        return false;
      }
      this.errors.email = "";
      return true;
    },
    validateRePassword() {
      if (!this.form.rePassword) {
        this.errors.rePassword = "Confirm password is required";
        return false;
      } else if (this.form.password != this.form.rePassword) {
        this.errors.rePassword = "Confirm password is not the same as the password";
        return false;
      }
      this.errors.rePassword = "";
      return true;
    },
    clickButtonLogin(form) {
      var result = this.validate();
      if (result) {
        AuthenticationService.register(form)
        .then((response) => {
            this.response = response.data;
          })
          .catch((e) => {
            console.log(e);
          });
      }
    },

  },
}
</script>

<style>
@import '../../assets/css/login.css';
</style>
