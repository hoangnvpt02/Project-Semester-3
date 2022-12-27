<template>
<div>
  <div class="login-box">
    <h2>Login</h2>
    <form>
      <div class="user-box">
        {{ user_name }}
        <input v-mode="user_name" type="text" name="" required="">
        <label>Username</label>
      </div>
      <div class="user-box">
        <input v-mode="password" type="password" name="" required="">
        <label>Password</label>
      </div>
      <a @click="clickButtonLogin()">
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        Login
      </a>
    </form>
  </div>
</div>
</template>

<script>
import AuthenticationService from '@/services/AuthenticationService';

export default {
  data() {
    return {
      user_name: '',
      password: '',
      response: ''
    }
  },
  methods: {
    clickButtonLogin() {
      console.log(this.user_name);
      // AuthenticationService.login(form.user_name, form.password)
      // .then((response) => {
      //     this.response = response.data;
      //   })
      //   .catch((e) => {
      //     console.log(e);
      //   });
    },

  },
}
</script>

<style>
@import '../../assets/css/login.css';
</style>
