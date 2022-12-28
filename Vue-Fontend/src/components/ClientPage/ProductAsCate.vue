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
			<div class="row">
				<div class="col-md-3 col-sm-3 text-center"  v-for="cate in categories">
					<div class="feature-center animate-box" data-animate-effect="fadeIn">
						<span class="icon">
							<i class="icon-shop"></i>
						</span>
						<h3>{{cate.name}}</h3>
						<p>{{cate.description}}</p>
						<p><a :href="'/product/category/' + cate.id" class="btn btn-primary btn-outline">View More</a></p>
						<!-- <router-link :to="{ name: 'productAsCate', params: { id: cate.id } }" class="btn btn-primary btn-outline">View More</router-link> -->
					</div>
				</div>
			</div>
		</div>
		<div class="container">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading">
					<h2>{{category.name}}</h2>
					<p>{{category.description}}</p>
				</div>
			</div>
		<div>
	</div>
			<div class="row">
				<div class="col-md-4 text-center animate-box" v-for="pd in products">
					<div class="product">
						<div class="product-grid" style="border-radius: 5px;" :style="{ 'background-image' : 'url('+baseUrl+ +pd.fileDetailsId+')'  }">
							<!-- <img class="product-grid" :src="image"/> -->
							<div class="inner">
								<p>
									<router-link :to="{ name: 'detail', params: { id: pd.id } }" class="icon"><i class="icon-shopping-cart"></i></router-link>
									<router-link :to="{ name: 'detail', params: { id: pd.id } }" class="icon"><i class="icon-eye"></i></router-link>
								</p>
							</div>
						</div>
						<div class="desc">
							<h3><a :href="'/detail/' + pd.id">{{ pd.name }}</a></h3>
							<span class="price" v-if="pd.salePercent >0">Sale: ${{ pd.priceSale }}</span>
							<span class="price" v-else>Price: ${{ pd.price }}</span>
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
import bannerproduct from '../../assets/images/bannerproduct.png'
import base from "@/../base.json"
import CategoryService from '@/services/CategoryService';

export default {
	data() {
	let products
	let categories
	let category
	let baseUrl=''
	return {
		products,
		bannerproduct,
		baseUrl,
		base,
		categories,
	  category

	}
	},
	methods: {
		retrieveCategories() {
			CategoryService.getAll()
			.then((response) => {
          this.categories = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
		getCateById(id) {
			CategoryService.getById(id)
			.then((response) => {
          this.category = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},

		getAllProductByCate(id) {
			ProductService.getAllProductByCate(id)
			.then((response) => {
          this.products = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
	},
	created() {
		this.baseUrl = this.base.baseUrl+ 'api/files/'
    this.getAllProductByCate(this.$route.params.id);
    this.getCateById(this.$route.params.id);
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