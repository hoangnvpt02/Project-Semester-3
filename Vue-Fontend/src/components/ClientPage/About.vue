<template>
  <div>
    <Header></Header>
    <!-- <div class="fh5co-loader"></div> -->
	
	<div id="page">
	

	<header id="fh5co-header" class="fh5co-cover fh5co-cover-sm" role="banner" :style="{ backgroundImage: `url(${BannerAuction})` }">
		<div class="overlay"></div>
		<div class="container">
			<div class="row">
				<div class="col-md-8 col-md-offset-2 text-center">
					<div class="display-t">
						<div class="display-tc animate-box" data-animate-effect="fadeIn">
							<h1>About Us</h1>
						</div>
					</div>
				</div>
			</div>
		</div>
	</header>
	
	<div id="fh5co-about">
		<div class="container">
			<div class="about-content">
				<div class="row animate-box">
					<div class="col-md-6">
						<div class="desc">
							<h3>Company History</h3>
							<p>We were established in 2020 with an initial team of 4 members. After more than 2 years of operation, 
								our website has reached a large number of customers who visit the website every day</p>
						</div>
						<div class="desc">
							<h3>Mission &amp; Vission</h3>
							<p>-Make it easy for customers to purchase artwork that matches their personal taste</p>
							<p>-For customers to have the best experience when visiting the website</p>
							<p>-Reach customers all over the world</p>
						</div>
					</div>
					<div class="col-md-6">
						<img class="img-responsive" src="../../assets/images/BannerAuction.jpg" alt="about">
					</div>
				</div>
			</div>
		</div>
	</div>
	<div id="fh5co-counter" class="fh5co-bg fh5co-counter" :style="{ backgroundImage: `url(${artgallery})` }">
	</div>
	</div>

	<div class="gototop js-top">
		<a href="#" class="js-gotop"><i class="icon-arrow-up"></i></a>
	</div>
    <Footer></Footer>
  </div>
</template>
<script>
import Header from './Header.vue'
import Footer from './Footer.vue'
import img_bg_2 from '../../assets/images/bg2.jpg'
import BannerAuction from '../../assets/images/BannerAuction.jpg'
import artgallery from '../../assets/images/artgallery.jpg'

export default {
  data() {
    return {
      img_bg_2,
			BannerAuction,
			artgallery
    }
  },
  components: {
    Header,
    Footer
  }
}
</script>
<style>
  
</style>