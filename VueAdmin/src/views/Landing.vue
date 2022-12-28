<template>
<div>
    <section class="pt-20 pb-48">
      <div class="container mx-auto px-4">
        <div class="flex flex-wrap">
          <div class="w-full md:w-6/12 lg:w-4/12 lg:mb-0 mb-12 px-4" v-for="(item, index) in cars" :key="index">
            <div class="px-1">
              <img alt="..." :src="item.mainImage" class="shadow-lg mx-auto w-full" style="height:250px" />
              <div class="pt-6 p-8">
                <h5 class="text-xl font-bold text-center uppercase">{{item.name}}</h5>
                <p class="mt-1 text-sm capitalize font-thin">
                  - License Plates: {{item.licensePlates}}
                </p>
                <p class="mt-1 text-sm capitalize font-thin">
                  - Seat Number: {{item.seatNumber}}
                </p>
                <p class="mt-1 text-sm capitalize font-thin">
                  - Color: {{item.color}}
                </p>
                <p class="mt-1 text-sm capitalize font-thin">
                  - Brand: {{item.brand}}
                </p>
                <p class="mt-1 text-sm uppercase font-bold">
                  &nbsp; one day rental price : ${{item.rentalPrice}}
                </p>
                <div class="mt-6">
                  <router-link :to="{ name: 'booking', params: {id: item.carId } }">
                    <button class="bg-lightBlue-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button"> Book Now</button>
                  </router-link>
                  <router-link :to="{ name: 'booking-more', params: {id: item.carId } }">
                    <button class="bg-pink-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button"> Details</button>
                  </router-link>
                </div>
              </div>
            </div>
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
import team1 from "@/assets/img/team-1-800x800.jpg";
import team2 from "@/assets/img/team-2-800x800.jpg";
import team3 from "@/assets/img/team-3-800x800.jpg";
import team4 from "@/assets/img/team-4-470x470.png";
import CarService from "../services/CarService";

export default {
  data() {
    const cars = ref([]);
    return {
      cars,
      team1,
      team2,
      team3,
      team4,
    };
  },
  methods: {
    retrievecars() {
      CarService.getAll()
        .then((response) => {
          this.cars = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.retrievecars();
  },
  components: {

  },
};
</script>
