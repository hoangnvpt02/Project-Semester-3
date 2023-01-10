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
							<button @click="maxPrice(this.$route.params.id,pd.id)" class="btn" style="background-color:#d1c286; color:white; border-radius: 5px;">See Hightest Price Now
							</button>
							<!-- <p v-if="priceMax" class="price">Highest Price Now:<span style="color:#d1c286;"> ${{ priceMax }} </span> </p> -->
							<p v-if="pd.aspNetUsersId !=null && pd.aspNetUsersId == userIdLogin" class="price" style="color:#d1c286; font-weight: bolder;">you have won the bid with price ${{ pd.priceAuction }}</p>
							<button v-if="pd.aspNetUsersId !=null && pd.aspNetUsersId == userIdLogin"  @click="AddToCart(pd)" class="btn" style="background-color:#d1c286; color:white; border-radius: 5px;">Add to Cart</button>
							<button v-else v-if="user && pd.aspNetUsersId == null" @click="auction(pd.id, pd.price)" class="btn" style="background-color:#d1c286; color:white; border-radius: 5px;">Auction</button>
						</div>
					</div>
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
import OrderService from '@/services/OrderService';
export default {
	data() {
	let products
	let priceMax = 0
	let categories
	let baseUrl=''
	let galary
	let userIdLogin= null
	return {
		priceMax,
		userIdLogin,
		galary,
		products,
		categories,
		bannerproduct,
		baseUrl,
		base,
		user: JSON.parse(localStorage.getItem('user'))
	}
	},
	methods: {
		maxPrice(idGa,idPd) {
			BidService.getById(idGa,idPd)
			.then((response) => {
				let bid = response.data[0];
				if(bid) {
					this.priceMax = bid.price
				}
				swal("The current highest bid is $" +this.priceMax, {
					button: false,
					timer: 3000,
				});
        })
        .catch((e) => {
          console.log(e);
        });
		},
		auction(id, price) {
			swal({
				content: {
				element: "input",
				attributes: {
					placeholder: "Type your offer price",
					type: "number",
				},
    },
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
		AddToCart(product) {
			OrderService.create({
				productId: product.id,
				aspNetUsersId: this.user.id,
				price: 10,
				status: 0,
				isActive: 0,
			});
			OrderService.GetQuantityOrder(this.user.id);

		}
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
	// mounted() { 
	// 	setTimeout(function(){ 
	// 			const elem = document.getElementById('max_price');
	// 			elem.click(); 
	// 	}, 200);
	// },
  components: {
    Header,
    Footer
  }
  
}
</script>
<style>
  
</style>