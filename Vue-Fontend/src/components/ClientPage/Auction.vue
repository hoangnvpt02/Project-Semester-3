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
					<div class="col-md-4 col-sm-3 text-center"  v-for="item in galary">
						<div class="feature-center animate-box" data-animate-effect="fadeIn">
							<span class="icon">
								<i class="icon-eye"></i>
							</span>
							<h3>{{item.name}}</h3>
							<p>{{item.discription}}</p>
							<span style="color:#d1c286"> Time start:</span>  <p>{{item.fromDate}}</p>
							<span style="color:#d1c286"> Time end: </span><p>{{item.toDate}}</p>
							<p><a :href="'/product-auction/' + item.id" class="btn btn-primary btn-outline">View Auction Products</a></p>
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
import ProductService from '@/services/ProductService';
import CategoryService from '@/services/CategoryService';
import BannerAuction from '../../assets/images/BannerAuction.jpg'
import GalaryService from '@/services/GalaryService';
import artgallery from '../../assets/images/artgallery.jpg'

export default {
	data() {
	const products=[]
	const categories=[]
	let galary
	return {
		galary,
		artgallery,
		products,
		categories,
    BannerAuction
	}
	},
	methods: {
		getAllGalary() {
			GalaryService.getAll()
			.then((response) => {
          this.galary = response.data;
        })
        // .catch((e) => {
        //   console.log(e);
        // });
		},
		
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
		this.getAllGalary()
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