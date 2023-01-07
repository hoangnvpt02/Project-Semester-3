<template>
  <div>
    <Header></Header>
    <header id="fh5co-header" class="fh5co-cover fh5co-cover-sm" role="banner" :style="{ backgroundImage: `url(${bannerproduct})` }">
		<div class="overlay"></div>
		<div class="container">
			<div class="row">
				<div class="col-md-8 col-md-offset-2 text-center">
					<div class="display-t">
						<div class="display-tc animate-box" data-animate-effect="fadeIn">
							<h1>Artworks</h1>
							<h2>Enjoy artworks at here</h2>
						</div>
					</div>
				</div>
			</div>
		</div>
		</header>
	
	<div id="fh5co-product">
		<div class="container">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
					<h2>Artworks being auctioned</h2>
					<p>Please submit your bid and we'll let you place the artwork if you bid the best</p>
				</div>
			</div>
		<div>
			<div class="container">
				<div class="row">
					<div class="col-md-3 col-sm-3 text-center"  v-for="item in galary">
						<div class="feature-center animate-box" data-animate-effect="fadeIn">
							<span class="icon">
								<i class="icon-eye"></i>
							</span>
							<h3>{{item.name}}</h3>
							<p>{{item.discription}}</p>
							<p><a :href="'/product-auction/' + item.id" class="btn btn-primary btn-outline">View Auction Products</a></p>
						</div>
					</div>
				</div>
			</div>
		
	</div>
			<div class="row">
					<div class="row animate-box" style="padding-top:50px">
						<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
							<!-- <h2>Artworks being auctioned</h2> -->
							<p>Let's have a look at the products in our store and enjoy the works of art</p>
						</div>
					</div>
				<div class="col-md-4 text-center animate-box" v-for="pd in products">
					<div class="product">
						<div class="product-grid" style="border-radius: 5px;" :style="{ 'background-image' : 'url('+baseUrl+ +pd.fileDetailsId+')'  }">
							<div class="inner">
								<p>
									<!-- <router-link :to="{ name: 'detail', params: { id: pd.id } }" class="icon"><i class="icon-shopping-cart"></i></router-link> -->
									<router-link :to="{ name: 'detail', params: { id: pd.id } }" class="icon"><i class="icon-eye"></i></router-link>
								</p>
							</div>
						</div>
						<div class="desc">
							<h3><a :href="'/detail/' + pd.id">{{ pd.name }}</a></h3>
							<p class="price" >Starting Price:<span style="color:#d1c286;"> ${{ pd.price }} </span> </p>
							<p v-if="pd.aspNetUsersId == userIdLogin" class="price" style="color:#d1c286; font-weight: bolder;">you have won the bid with price ${{ pd.priceAuction }}</p>
							<button v-if="pd.aspNetUsersId == userIdLogin" @click="auction(pd.id, pd.price)" class="btn" style="background-color:#d1c286; color:white; border-radius: 5px;">Add to Cart</button>
							<button v-else @click="auction(pd.id, pd.price)" class="btn" style="background-color:#d1c286; color:white; border-radius: 5px;">Auction</button>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div id="fh5co-started">
		<div class="container">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
					<h2>Newsletter</h2>
					<p>Just stay tune for our latest Product. Now you can subscribe</p>
				</div>
			</div>
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2">
					<form class="form-inline">
						<div class="col-md-6 col-sm-6">
							<div class="form-group">
								<label for="email" class="sr-only">Email</label>
								<input type="email" class="form-control" id="email" placeholder="Email">
							</div>
						</div>
						<div class="col-md-6 col-sm-6">
							<button type="submit" class="btn btn-default btn-block">Subscribe</button>
						</div>
					</form>
				</div>
			</div>
		</div>
	</div>
    <Footer></Footer>
    
  </div>
</template>
<script>
import Header from './Header.vue'
import Footer from './Footer.vue'
import ProductService from '@/services/ProductService';
import CategoryService from '@/services/CategoryService';
import bannerproduct from '../../assets/images/bannerproduct.png'
import base from "@/../base.json"
import GalaryService from '@/services/GalaryService';
import BidService from '@/services/BidService';
import swal from 'sweetalert';

export default {
	data() {
	let products
	let categories
	let baseUrl=''
	let galary
	let userIdLogin= null
	return {
		userIdLogin,
		galary,
		products,
		categories,
		bannerproduct,
		baseUrl,
		base
	}
	},
	methods: {
		auction(id, price) {
			swal({
			content: "input",
			})
			.then((response) => { 
				if (response <= price) {
					swal("Error!", "The entered price must be greater than the bid price", "error", {
            button: false,
            timer: 4000
          });
				} else {
					let userId = ''
					let name = ''
  				let user = JSON.parse(localStorage.getItem('user'));
					if (user) { 
						userId = user.id,
						name = user.name
					}
					let data = {
					galaryId : this.$route.params.id,
					price : response,
					productId : id,
					aspNetUsersId : userId,
					name: name
					}
					BidService.create(data).then((response) => {
						swal("Success!", "Successfully!", "success", {
            button: false,
            timer: 2000
          });
						console.log("🚀 ~ file: ProductAuction.vue:139 ~ BidService.create ~ response", response)
					})
				}
			});
		},
		getAllGalary() {
			GalaryService.getAll()
			.then((response) => {
          this.galary = response.data;
        })
        // .catch((e) => {
        //   console.log(e);
        // });
		},
		getProductByGalary(id) {
			GalaryService.getProductByGalary(id)
			.then((response) => {
          this.products = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
		retrieveCategories() {
			CategoryService.getAll()
			.then((response) => {
          this.categories = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
	},
	created() {
		let user = JSON.parse(localStorage.getItem('user'));
			if (user) { 
				this.userIdLogin = user.id
			}
		this.baseUrl = this.base.baseUrl+ 'api/files/'
		this.retrieveCategories()
		this.getProductByGalary(this.$route.params.id)
		this.getAllGalary()
	},
  components: {
    Header,
    Footer
  }
  
}
</script>
<style>
  
</style>