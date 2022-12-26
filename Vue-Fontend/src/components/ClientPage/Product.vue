<template>
  <div>
    <Header></Header>
    <header id="fh5co-header" class="fh5co-cover fh5co-cover-sm" role="banner" style="background-image:url(images/img_bg_2.jpg);">
		<div class="overlay"></div>
		<div class="container">
			<div class="row">
				<div class="col-md-8 col-md-offset-2 text-center">
					<div class="display-t">
						<div class="display-tc animate-box" data-animate-effect="fadeIn">
							<h1>Product</h1>
							<h2>Free html5 templates by <a href="https://themewagon.com/theme_tag/free/" target="_blank">Themewagon</a></h2>
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
					<span>Cool Stuff</span>
					<h2>Products.</h2>
					<p>Dignissimos asperiores vitae velit veniam totam fuga molestias accusamus alias autem provident. Odit ab aliquam dolor eius.</p>
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
import productService from '@/services/ProductService';
export default {
	data() {
	const products=[]
	return {
		products,
	}
	},
	methods: {
		retrieveProduct() {
			productService.getAll()
			.then((response) => {
          this.products = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		}
	},
	created() {
		this.retrieveProduct()
	},
  components: {
    Header,
    Footer
  }
  
}
</script>
<style>
  
</style>