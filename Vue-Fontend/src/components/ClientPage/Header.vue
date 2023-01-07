<template lang="">
  <div>
	<!-- <div class="fh5co-loader"></div> -->
  <nav class="fh5co-nav" role="navigation">
		<div class="container">
			<div class="row">
				<div class="col-md-3 col-xs-2">
					<div id="fh5co-logo"><a href="/home" style="color:#d1c286">ART GALARY</a></div>
				</div>
				<div class="col-md-6 col-xs-6 text-center menu-1">
					<ul>
						<li class="has-dropdown">
							<a href="/product">Shop</a>
							<ul class="dropdown">
								<li><a href="single.html">Single Shop</a></li>
							</ul>
						</li>
						<li><a href="/auction">Auction</a></li>
						<li><a href="/about">About</a></li>
						<li class="has-dropdown">
							<a href="/about">Services</a>
							<ul class="dropdown">
								<li><a href="#">Web Design</a></li>
								<li><a href="#">eCommerce</a></li>
								<li><a href="#">Branding</a></li>
								<li><a href="#">API</a></li>
							</ul>
						</li>
						<li><a href="/contact">Contact</a></li>
					</ul>
				</div>
				<div class="col-md-3 col-xs-4 text-right hidden-xs menu-2">
					<ul>
						<li v-if="!exist"><a href="/login">Login</a></li>
						<li v-if="!exist"><a href="/register">Register</a></li>
						<li v-if="exist"><a href="#" @click="logout()">Logout</a></li>
						<li v-if="exist"><div><a href="/profile">Profile</a></div></li>
						<li class="shopping-cart"><a href="/cart" class="cart"><span><small>{{ quantity_order }}</small><i class="icon-shopping-cart"></i></span></a></li>
					</ul>
				</div>
			</div>
			
		</div>
	</nav>

  </div>
</template>
<script>
import OrderService from '@/services/OrderService';
import AuthenticationService from '@/services/AuthenticationService';

export default {
	data () {
		return {
			quantity_order: 0,
			exist: null,
			user: {
				id: 0,
			}
		}
	},
	created () {
		this.getQuantityOrder();
		this.checkExistLogin();
	},
	methods: {
		getQuantityOrder() {
			if (localStorage.getItem('user')) {
				this.user = JSON.parse(localStorage.getItem('user'));
			}
			OrderService.GetQuantityOrder(this.user.id)
			.then((response) => {
				this.quantity_order = response.data;
			});
			// .catch((e) => {
			//   	console.log(e);
			// });
		},
		checkExistLogin() {
			if (localStorage.getItem("user") === null) {
				this.exist = false;
			} else {
				this.exist = true;
			}
		},
		logout() {
			AuthenticationService.logout();
			return window.location.href = "http://localhost:4001/home";
		}
	},
}
</script>
<style>

</style>