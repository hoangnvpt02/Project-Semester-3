<template>
  <div>
    <Header></Header>
		<header id="fh5co-header" class="fh5co-cover fh5co-cover-sm" role="banner" :style="{ backgroundImage: `url(${BannerAuction})` }">
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
		<div id="fh5co-services" class="fh5co-bg-section">
			<div class="container">
				<div class="row">
					<div class="col-md-4 col-sm-4 text-center">
						<div class="feature-center animate-box" data-animate-effect="fadeIn">
							<span class="icon">
								<i class="icon-credit-card"></i>
							</span>
							<h3>Payment</h3>
							<p>Support many forms of payment to bring convenience to customers</p>
							<!-- <p><a href="#" class="btn btn-primary btn-outline">Learn More</a></p> -->
						</div>
					</div>
					<div class="col-md-4 col-sm-4 text-center">
						<div class="feature-center animate-box" data-animate-effect="fadeIn">
							<span class="icon">
								<i class="icon-wallet"></i>
							</span>
							<h3>Save on travel costs</h3>
							<p>Customers can buy works directly here, no need to travel</p>
						</div>
					</div>
					<div class="col-md-4 col-sm-4 text-center">
						<div class="feature-center animate-box" data-animate-effect="fadeIn">
							<span class="icon">
								<i class="icon-paper-plane"></i>
							</span>
							<h3>Fast Shipping</h3>
							<p>Express shipping service can deliver artwork to customers in about 3 hours</p>
						</div>
					</div>
				</div>
			</div>
		</div>

  <div id="fh5co-product" v-if="productFeatures.length >0">
		<div class="container">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
					<!-- <span>Cool Stuff</span> -->
					<h2>Featured Artworks</h2>
					<p>Featured artworks - Let's enjoy!</p>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4 text-center animate-box" v-for="pdfeature in productFeatures">
					<div class="product">
						<div class="product-grid" style="border-radius: 5px;" :style="{ 'background-image' : 'url('+baseUrl+ +pdfeature.fileDetailsId+')'  }">
							<span class="sale">Featured</span>
							<div class="inner">
								<p>
									<!-- <a  @click="AddToCart(pdfeature)" class="icon"  href="#"><i class="icon-shopping-cart"></i></a> -->
									<router-link :to="{ name: 'detail', params: { id: pdfeature.id } }" class="icon"><i class="icon-eye"></i></router-link>
								</p>
							</div>
						</div>
						<div class="desc">
							<h3><router-link :to="{ name: 'detail', params: { id: pdfeature.id } }" class="icon">{{ pdfeature.name }}</router-link></h3>
							<span class="price">Price: ${{ pdfeature.price }}</span>
						</div>
					</div>
				</div>
				
			</div>
		</div>
	</div>

	<div id="fh5co-product" v-if="productSales.length >0">
		<div class="container">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
					<!-- <span>Cool Stuff</span> -->
					<h2>Sale Artworks</h2>
					<p>Sale artworks - Let's enjoy!</p>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4 text-center animate-box" v-for="pdsale in productSales">
					<div class="product">
						<div class="product-grid" style="border-radius: 5px;" :style="{ 'background-image' : 'url('+baseUrl+ +pdsale.fileDetailsId+')'  }">
							<span class="sale">Sale {{ pdsale.salePercent}}%</span>
							<div class="inner">
								<p>
									<!-- <router-link :to="{ name: 'detail', params: { id: pdsale.id } }" class="icon"><i class="icon-shopping-cart"></i></router-link> -->
									<router-link :to="{ name: 'detail', params: { id: pdsale.id } }" class="icon"><i class="icon-eye"></i></router-link>
								</p>
							</div>
						</div>
						<div class="desc">
							<h3><router-link :to="{ name: 'detail', params: { id: pdsale.id } }" class="icon">{{ pdsale.name }}</router-link></h3>
							<span class="price">Price: ${{ pdsale.price }}</span>
							<p class="price" style="color:#d1c286; font-weight: bold;" v-if="pdsale.salePercent >0">Sale: ${{ pdsale.priceSale }}</p> 
						</div>
					</div>
				</div>
				
			</div>
		</div>
	</div>

  <div id="fh5co-testimonial" class="fh5co-bg-section">
		<div class="container">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
					<span>Art Galary</span>
					<h2>Customer Reviews</h2>
				</div>
			</div>
			<div class="row">
				<div class="col-md-4">
					<div class="row animate-box">
						<div class="">
							<div class="item">
								<div class="testimony-slide active text-center">
									<figure>
										<img :src="require(`@/assets/images/person1.jpg`)" alt="user">
									</figure>
									<span>Jean Doe, via <a class="twitter">Twitter</a></span>
									<blockquote>
										<p>&ldquo;I really like this business model&rdquo;</p>
									</blockquote>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-4">
					<div class="row animate-box">
						<div class="">
							<div class="item">
								<div class="testimony-slide active text-center">
									<figure>
										<img :src="require(`@/assets/images/person2.jpg`)" alt="user">
									</figure>
									<span>Athony, via <a class="twitter">Twitter</a></span>
									<blockquote>
										<p>&ldquo;There are so many beautiful works&rdquo;</p>
									</blockquote>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-4">
					<div class="row animate-box">
						<div class="">
							<div class="item">
								<div class="testimony-slide active text-center">
									<figure>
										<img :src="require(`@/assets/images/person3.jpg`)" alt="user">
									</figure>
									<span>Peter, via <a class="twitter">Twitter</a></span>
									<blockquote>
										<p>&ldquo;Prices are very reasonable. I'm very satisfied&rdquo;</p>
									</blockquote>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
  <div id="fh5co-counter" class="fh5co-bg fh5co-counter" :style="{ backgroundImage: `url(${artgallery})` }">
	</div>
  <Footer></Footer>
  </div>
</template>

<script>
import Header from './Header.vue'
import Footer from './Footer.vue'
import artgallery from '../../assets/images/artgallery.jpg'
import img_bg_4 from '../../assets/images/bg4.jpg'
import img_bg_3 from '../../assets/images/bg3.jpg'
import img_bg_2 from '../../assets/images/bg2.jpg'
import img_bg_1 from '../../assets/images/bg1.jpg'
import BannerAuction from '../../assets/images/BannerAuction.jpg'
import person1 from '../../assets/images/person1.jpg'
import ProductService from '@/services/ProductService';
import base from "@/../base.json"

export default {
  data() {
		let productFeatures =[]
		let productSales =[]
		let categories
		let baseUrl=''
    return {
      artgallery,
      img_bg_4,
      img_bg_3,
      img_bg_2,
      img_bg_1,
			BannerAuction,
			productFeatures,
			categories,
			baseUrl,
			base,
			person1,
			productSales
    }
  },
	methods: {
		AddToCart(product) {
			OrderService.create({
				productId: product.id,
				aspNetUsersId: this.user.id,
				price: 10,
				status: 0,
				isActive: 0,
			});
			OrderService.GetQuantityOrder(this.user.id);

		},
		getAllByFeature() {
			ProductService.getAllByFeature()
			.then((response) => {
          this.productFeatures = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
		getAllBySale() {
			ProductService.getAllBySale()
			.then((response) => {
          this.productSales = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
	},
	created() {
		this.baseUrl = this.base.baseUrl+ 'api/files/'
		this.getAllByFeature()
		this.getAllBySale()
	},
  components: {
    Header,
    Footer
  }
}
</script>
<style>
  @import '../../assets/css/animate.css';
  @import '../../assets/css/icomoon.css';
  @import '../../assets/css/bootstrap.css';
  @import '../../assets/css/flexslider.css';
  @import '../../assets/css/owl.carousel.min.css';
  @import '../../assets/css/owl.theme.default.min.css';
  @import '../../assets/css/style.css';
</style>