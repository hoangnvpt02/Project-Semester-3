<template>
<div>
  <div id="body-login">
    <div class="login-box">
      <h2>Register</h2>
      <form>
        <div class="user-box">
          <input v-model="form.name"
            type="text" 
            name=""
            @blur="validateName()"
            v-bind:class="{'is-invalid':errors.name}"
          >
          <label>Name</label>
          <div class="invalid-feedback">{{ errors.name }}</div>
        </div>
        <div class="user-box">
          <input v-model="form.phone"
            type="text" 
            name=""
            @blur="validatePhone()"
            v-bind:class="{'is-invalid':errors.phone}"
          >
          <label>Phone</label>
          <div class="invalid-feedback">{{ errors.phone }}</div>
        </div>
        <div class="user-box">
          <input v-model="form.address"
            type="text" 
            name=""
            @blur="validateAddress()"
            v-bind:class="{'is-invalid':errors.address}"
          >
          <label>Address</label>
          <div class="invalid-feedback">{{ errors.address }}</div>
        </div>
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
        <a class="button" @click="clickButtonLogin(form)">
          <span></span>
          <span></span>
          <span></span>
          <span></span>
          Register
        </a>
        <div style="text-align: center;">
          <a href="/Login">Login</a>
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
        name: '',
        phone: '',
        address: '',
        userName: '',
        email: '',
        password: '',
        rePassword: ''
      },
      form: {
        name: '',
        phone: '',
        address: '',
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
        name: '',
        phone: '',
        address: '',
        userName: '',
        email: '',
        password: '',
        rePassword: ''
      }
      if (this.validateName() && this.validatePhone() && this.validateAddress() && this.validateUserName() && this.validatePassword() && this.validateEmail() && this.validateRePassword()) {
        return true;
      }
      return false;
    },
    validateName() {
      if (!this.form.name) {
        this.errors.name = "Name is required";
        return false;
      }
      this.errors.name = "";
      return true;
    },
    validatePhone() {
      if (!this.form.phone) {
        this.errors.phone = "Phone is required";
        return false;
      }
      this.errors.phone = "";
      return true;
    },
    validateAddress() {
      if (!this.form.address) {
        this.errors.address = "Address is required";
        return false;
      }
      this.errors.address = "";
      return true;
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
            alert("????ng k?? th??nh c??ng");
            return window.location.href = "http://localhost:4001/login";
          })
          .catch((e) => {
            alert("T??n username ???? t???n t???i");
          });
      }
    },

  },
}
</script>

<style>
@import '../../assets/css/login.css';
</style>
