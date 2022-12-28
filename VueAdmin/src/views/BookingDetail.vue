<template>
<div>


    <section class="pt-20 pb-48">
      <div class="container mx-auto px-4">
        <div class="flex flex-wrap justify-center text-center mb-24">
          <div class="w-full lg:w-6/12 px-4">
            <h2 class="text-4xl font-semibold mb-8 text-lightBlue-600">BOOKING INFORMATION</h2>
            <img alt="..." :src="cars.main_image" class="shadow-lg rounded-md mx-auto w-1/2" />
          </div>
        </div>

        <div class="flex flex-wrap">
          <div class="w-full lg:w-4/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-lightBlue-600 text-lg font-bold mb-3">
                Car Information
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
                Car Name: <span class="font-normal">{{cars.name}}</span>
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
                Brand Name: <span class="font-normal">{{cars.brand}}</span>
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
                Number Of Seat: <span class="font-normal">{{cars.seat_number}}</span>
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
                License Plates: <span class="font-normal">{{cars.license_plates}}</span>
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
                Car Color: <span class="font-normal">{{cars.color}}</span>
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
                ONE DAY RENTAL PRICE: <span class="font-normal">${{cars.rental_price}}</span>
              </label>
            </div>
          </div>
          <div class="w-full lg:w-4/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-lightBlue-600 text-lg font-bold mb-3">
                Your Information
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2">
                Full Name
              </label>
              <input type="text" class="mb-2 border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="user.name" name="color" />
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2">
                AGE
              </label>
              <input type="text" class="mb-2 border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="user.age" name="color" />
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Gender
              </label>
              <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="user.sex">
                <option v-for="item in genders" v-bind:key="item.id" v-bind:value="item.name"> {{ item.name }} </option>
              </select>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2">
                ADDRESS
              </label>
              <input type="text" class="mb-2 border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="user.address" name="color" />
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2">
                RENTAL PURPOSE
              </label>
              <input type="text" class="mb-2 border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="user.purpose" placeholder="Ex: For Travel" />
            </div>
          </div>
          <div class="w-full lg:w-4/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-lightBlue-600 text-lg font-bold mb-3">
                Booking Details
              </label>
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2">
                TIME TO GET CAR
              </label>
              <input style="height:44px" id="rental-time" class="w-full mb-2 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150 text-center" type="datetime-local" name="partydate" min="" max="2024-01-01T00:00" pattern="[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}" v-model="rental_day" required>
              <input type="hidden" id="timezone" name="timezone" value="+07:00">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2">
                Rental Time (Days)
              </label>
              <input type="number" min="1" max="99" class="mb-2 border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="rental.time" name="color" />
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2">
                ONE DAY RENTAL PRICE
              </label>
              <input type="text" readonly class="mb-2 border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.rental_price" name="color" />
              <label class="text-emerald-600 block uppercase  text-xs font-bold mb-2">
                Total Price
              </label>
              <input type="text" readonly class="mb-2 border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="total" name="color" />
              <button @click="bookCar" class="w-full bg-lightBlue-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150 text-center" type="button">Book</button>
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

import CarService from "../services/CarService";
import OrderService from "../services/OrderService";
import swal from 'sweetalert';
export default {
  props: {
    id: Number
  },
  data() {
    const cars = ref([]);
    return {
      rental_day: null,
      genders: [{
          id: 1,
          name: 'Male'
        },
        {
          id: 2,
          name: 'Female'
        },
      ],
      user: {
        name: null,
        age: null,
        sex: null,
        address: null,
        purpose: null
      },
      rental: {
        time: null,
      },
      cars,
    };
  },
  computed: {
    total: function () {
      return this.rental.time * this.cars.rental_price;
    }
  },
  methods: {

    bookCar() {
      let data = {
        carId: this.$route.params.id,
        rentalPurpose: this.user.purpose,
        totalMoney: this.total,
        customerName: this.user.name,
        customerAge: this.user.age,
        customerGender: this.user.sex,
        customerAddress: this.user.address,
        // customerPurpose: this.user.purpose,
        rentalDay: this.rental.time,
        rentalStatusId: {
          statusId: 1
        },
        rentalTime: this.rental_day
      };
      OrderService.create(data)
        .then(() => {
          swal("Success!", "Done! Waiting for Confirmation", "success", {
            button: false,
            timer: 3000
          });
        })
        .catch(() => {
          swal("Error!", "Failed!", "error", {
            button: false,
            timer: 2000
          });
        });
    },
    getCarById(id) {
      CarService.getById(id)
        .then((response) => {
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
  },
  mounted() {
    this.getCarById(this.$route.params.id);
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0 so need to add 1 to make it 1!
    var yyyy = today.getFullYear();
    if (dd < 10) {
      dd = '0' + dd
    }
    if (mm < 10) {
      mm = '0' + mm
    }
    today = yyyy + '-' + mm + '-' + dd;
    document.getElementById("rental-time").setAttribute("min", today);
  },

};
</script>
