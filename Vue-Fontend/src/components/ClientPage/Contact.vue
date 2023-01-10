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
							<h1>Contact Us</h1>
						</div>
					</div>
				</div>
			</div>
		</div>
	</header>
	
	<div id="fh5co-contact">
		<div class="container">
			<div class="row">
				<div class="col-md-6 col-md-push-1 animate-box">
					<div class="fh5co-contact-info">
						<h3>Contact Information</h3>
						<ul>
							<li class="address">08 Ton That Thuyet, <br> Cau Giay, HaNoi</li>
							<li class="phone"><a href="tel://1234567920">+ 1235 2355 98</a></li>
							<li class="email"><a href="artonline@shop.com">artonline@shop.com</a></li>
						</ul>
					</div>
				</div>
				<div class="col-md-6 animate-box">
					<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.1043404596735!2d105.77944761476327!3d21.028510685998576!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x313454b3aa600d69%3A0x11275455cd98079!2zVMO0biBUaOG6pXQgVGh1eeG6v3QsIE3hu7kgxJDDrG5oIDIsIFThu6sgTGnDqm0sIEjDoCBO4buZaSwgVmnhu4d0IE5hbQ!5e0!3m2!1svi!2s!4v1673337356837!5m2!1svi!2s" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
						
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
import BannerAuction from '../../assets/images/BannerAuction.jpg'

export default {
	data() {
		return {
				BannerAuction
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