<template>
<div>


    <section class="pt-20 pb-48">
      <div class="container mx-auto px-4">
        <div class="flex flex-wrap justify-center text-center mb-5">
          <div class="w-full lg:w-6/12 px-4">
            <h2 class="text-4xl font-semibold mb-8 text-lightBlue-600">INFORMATIONS OF CAR</h2>
          </div>
        </div>
        <div class="flex flex-wrap">
          <div class="w-full lg:w-6/12 px-4">
            <img alt="..." :src="cars.main_image" class="shadow-lg rounded-md mx-auto w-full" />
            <h2 class="text-sm text-center m-3 font-normal mb-8 text-lightBlue-600">------More Images------</h2>
            <div class="justify-between hidden lg:flex">
              <div v-for="(item, index) in subImages" :key="index">
                <img alt="..." :src="item.subImage" class="sub-img shadow-lg rounded-lg mx-auto" style="width:180px;height:100px" />
              </div>
            </div>
          </div>
          <div class="w-full lg:w-6/12 px-4">
            <label class="block uppercase text-blueGray-600 text-3xl font-bold mb-3">
              {{cars.name}}
            </label>
            <label class="block uppercase text-blueGray-600 text-sm font-bold mb-3">
              Brand Name: <span class="font-normal">{{cars.brand}}</span>
            </label>
            <label class="block uppercase text-blueGray-600 text-sm font-bold mb-3">
              Number Of Seat: <span class="font-normal">{{cars.seat_number}}</span>
            </label>
            <label class="block uppercase text-blueGray-600 text-sm font-bold mb-3">
              License Plates: <span class="font-normal">{{cars.license_plates}}</span>
            </label>
            <label class="block uppercase text-blueGray-600 text-sm font-bold mb-3">
              Car Color: <span class="font-normal">{{cars.color}}</span>
            </label>
            <label class="block uppercase text-blueGray-600 text-sm font-bold mb-3">
              ONE DAY RENTAL PRICE: <span class="font-normal">${{cars.rental_price}}</span>
            </label>
            <label class="block uppercase text-blueGray-600 text-sm font-bold mb-3">
              Descriptios: <span class="font-normal">{{cars.description}}</span>
            </label>
            <router-link :to="{ name: 'booking', params: {id: cars.id } }">
              <button class="bg-lightBlue-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button"> Book Now</button>
            </router-link>
          </div>
        </div>

      </div>
    </section>

  </div>
</template>

<script>
import {
  ref
} from "vue"

import CarService from "../services/CarService";
import CarImageService from "../services/CarImageService";
export default {
  data() {
    const cars = ref([]);
    const subImages = ref([]);
    return {
      cars,
      subImages,
    };
  },

  methods: {
    getCarById(id) {
      CarService.getById(id)
        .then((response) => {
          this.cars.id = response.data.carId;
          this.cars.name = response.data.name;
          this.cars.brand = response.data.brand;
          this.cars.seat_number = response.data.seatNumber;
          this.cars.license_plates = response.data.licensePlates;
          this.cars.description = response.data.description;
          this.cars.main_image = response.data.mainImage;
          this.cars.color = response.data.color;
          this.cars.rental_price = response.data.rentalPrice;
        })
        .catch((e) => {
          console.log(e);
        });
    },
    getCarImageById(id) {
      CarImageService.getById(id)
        .then((response) => {
          this.subImages = response.data;
          console.log("sub");
          console.log(this.subImages);
        })
        .catch((e) => {
          console.log(e);
        });
    },

  },
  mounted() {
    this.getCarById(this.$route.params.id);
    this.getCarImageById(this.$route.params.id);
  },
  components: {

  },
};
</script>

<style>
.sub-img:hover {
  transform: scale(1.5);
}
</style>
