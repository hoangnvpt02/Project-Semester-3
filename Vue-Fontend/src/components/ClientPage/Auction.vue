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
							<h1>Auction</h1>
							<h2>Join auction with us at here</h2>
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
					<div class="col-md-3 col-sm-3 text-center"  v-for="cate in categories">
						<div class="feature-center animate-box" data-animate-effect="fadeIn">
							<span class="icon">
								<i class="icon-credit-card"></i>
							</span>
							<h3>{{cate.name}}</h3>
							<p>{{cate.description}}</p>
							<p><a href="" class="btn btn-primary btn-outline">View More</a></p>
						</div>
					</div>
				</div>
			</div>
	</div>

			<div class="row">
				<div class="col-md-4 text-center animate-box" v-for="pd in products">
					<div class="product">
						<div class="product-grid" style="background-image:url(images/product-1.jpg);">
							<div class="inner">
								<p>
									<a href="/detail" class="icon"><i class="icon-shopping-cart"></i></a>
									<a href="/detail" class="icon"><i class="icon-eye"></i></a>
								</p>
							</div>
						</div>
						<div class="desc">
							<h3><a href="/detail">{{ pd.name }}</a></h3>
							<span class="price">{{ pd.price }}</span>
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
import BannerAuction from '../../assets/images/BannerAuction.jpg'

export default {
	data() {
	const products=[]
	const categories=[]
	return {
		products,
		categories,
    BannerAuction
	}
	},
	methods: {
		retrieveProduct() {
			ProductService.getAll()
			.then((response) => {
          this.products = response.data;
        })
        // .catch((e) => {
        //   console.log(e);
        // });
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
		this.retrieveProduct()
		this.retrieveCategories()
	},
  components: {
    Header,
    Footer
  }
  
}
</script>
<style>
  
</style>