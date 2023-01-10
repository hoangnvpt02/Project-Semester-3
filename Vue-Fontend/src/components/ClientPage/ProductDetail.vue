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
							<h1>Product Details</h1>
							<!-- <h2>Free html5 templates by <a href="https://themewagon.com/theme_tag/free/" target="_blank">Themewagon</a></h2> -->
						</div>
					</div>
				</div>
			</div>
		</div>
	</header>

  <div id="fh5co-product" style="padding:0px 0 600px 0">
		<div class="container">
			<div class="row">
				<div class="col-md-10 col-md-offset-1 animate-box">
					
					<div class="row animate-box">
						<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
							<h2 style="color:#d1c286; padding:30px">{{ product.name }}</h2>
							<div class="item">
							<div class="active text-center" >
								<figure>
									<img :src="baseUrl + product.fileDetailsId" style="width:500px; border-radius: 5px;" >
								</figure>
							</div>
						</div>
							<p>
								<a  v-if = "product.priceAuction == null" href="#" class="btn btn-primary btn-outline btn-lg" style="width:500px; border-radius: 5px;" @click="AddToCart(product)">Add to Cart</a>
								<!-- <a href="#" class="btn btn-primary btn-outline btn-lg">Compare</a> -->
							</p>
						</div>
					</div>
				</div>
			</div>
			<div class="row">
				<div class="col-md-10 col-md-offset-1">
					<div class="fh5co-tabs animate-box">
						<ul class="fh5co-tab-nav" >
							<li class="active"><a style="width:300%"><span class="icon visible-xs"><i class="icon-file"></i></span><span class="hidden-xs">Product Details</span></a></li>
							<!-- <li ><a href="#"><span class="icon visible-xs"><i class="icon-bar-graph"></i></span><span class="hidden-xs">Specification</span></a></li> -->
							<!-- <li><a href="#" data-tab="3"><span class="icon visible-xs"><i class="icon-star"></i></span><span class="hidden-xs">Feedback &amp; Ratings</span></a></li> -->
						</ul>

						<!-- Tabs -->
						<div class="fh5co-tab-content-wrap">

							<div class="fh5co-tab-content tab-content active" data-tab-content="1">
								<div class="col-md-10 col-md-offset-1">
									<span v-if = "product.priceAuction == null">
										<p class="price" style="color:#d1c286; font-weight: bold;" v-if="product.salePercent >0">Sale: ${{ product.priceSale }}</p> 
										<span v-else class="price">Price: ${{ product.price }}</span>
									</span>
									<span v-else>
										<p class="price" style="color:#d1c286; font-weight: bold;"> The product is being auctioned </p> 
									</span>

									<h2>{{ product.name }}</h2>
									<p>{{ product.description }}</p>

								</div>
							</div>

							<div class="fh5co-tab-content tab-content" data-tab-content="2">
								<div class="col-md-10 col-md-offset-1">
									<h3>Product Specification</h3>
									<ul>
										<li>Paragraph placeat quis fugiat provident veritatis quia iure a debitis adipisci dignissimos consectetur magni quas eius</li>
										<li>adipisci dignissimos consectetur magni quas eius nobis reprehenderit soluta eligendi</li>
										<li>Veritatis tenetur odio delectus quibusdam officiis est.</li>
										<li>Magni quas eius nobis reprehenderit soluta eligendi quo reiciendis fugit? Veritatis tenetur odio delectus quibusdam officiis est.</li>
									</ul>
									<ul>
										<li>Paragraph placeat quis fugiat provident veritatis quia iure a debitis adipisci dignissimos consectetur magni quas eius</li>
										<li>adipisci dignissimos consectetur magni quas eius nobis reprehenderit soluta eligendi</li>
										<li>Veritatis tenetur odio delectus quibusdam officiis est.</li>
										<li>Magni quas eius nobis reprehenderit soluta eligendi quo reiciendis fugit? Veritatis tenetur odio delectus quibusdam officiis est.</li>
									</ul>
								</div>
							</div>

						
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
import img_bg_2 from '../../assets/images/bg2.jpg'
import ProductService from '@/services/ProductService'
import bannerproduct from '../../assets/images/bannerproduct.png'
import base from "@/../base.json"
import OrderService from '@/services/OrderService';

export default {
	props: {
    id: Number
  },
  data() {
		let product
		let baseUrl=''

		return {
      img_bg_2,
			product,
			bannerproduct,
			baseUrl,
			base,
		user: JSON.parse(localStorage.getItem('user'))
    }
  },
	methods: {
		getProductById(id) {
			ProductService.getById(id)
			.then((response) => {
          this.product = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
		AddToCart(product) {
			if (this.user == null) {
				alert('please login!')
			}
			else {
				OrderService.create({
					productId: product.id,
					aspNetUsersId: this.user.id,
					price: 10,
					status: 0,
					isActive: 0,
				});
				OrderService.GetQuantityOrder(this.user.id);
			}

		}
	},
	created() {
		this.baseUrl = this.base.baseUrl+ 'api/files/'
    this.getProductById(this.$route.params.id);
		
	},
  components: {
    Header,
    Footer
  }
}
</script>
<style>
  
</style>