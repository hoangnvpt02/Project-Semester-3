<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <form @submit.prevent>
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Car Information
      </h6>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Car Name
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.name" name="name" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Brand Name
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.brand" name="brand" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Number Of Seat
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.seat_number" name="seat_number" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              License Plates
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.license_plates" name="license_plates" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Color
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.color" name="color" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Price
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.rental_price" name="rental_price" />
          </div>
        </div>
      </div>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Description
            </label>
            <textarea type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" rows="4" required v-model="cars.description" name="description">
                    A beautiful UI Kit and Admin for VueJS & Tailwind CSS. It is Free
                    and Open Source.
            </textarea>
          </div>
        </div>
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Main Image
            </label>
            <div class="flex items-center space-x-6">
              <div v-if="previewImage" class="shrink-0">
                <img style="width:200px;height:100px" class="object-cover rounded-md" :src="previewImage" alt="Photo" />
              </div>
              <div v-else class="shrink-0">
                <img style="width:200px;height:100px" class="object-cover rounded-md" src="https://media.istockphoto.com/vectors/rental-car-icon-vector-id1290071290?k=20&m=1290071290&s=612x612&w=0&h=wWAC-XinvhxfeoGySb0zefOnrCda3838MkBs_sLaWSw=" alt="Current profile photo" />
              </div>
              <label class="block">
                <span class="sr-only">Choose profile photo</span>
                <input type="file" accept="image/*" ref="file" @change="selectImage" />
              </label>
            </div>
          </div>
        </div>
      </div>
      <div class="w-full lg:w-12/12 px-4">
        <a href="/admin/car-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
          Back
        </a>
        <button @click="updateCar" class="w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="submit">
          Save
        </button>
      </div>
    </form>
  </div>
</div>
</template>

<script>
import CarService from "../../services/CarService";
import swal from 'sweetalert';
import UploadService from "../../services/UploadFilesService";
export default {
  data() {
    return {
      previewImage: undefined,
      cars: {
        name: null,
        brand: null,
        seat_number: null,
        license_plates: null,
        description: null,
        main_image: null,
        color: null,
        rental_price: null
      }
    }
  },
  methods: {
    selectImage() {
      this.currentImage = this.$refs.file.files.item(0);
      this.previewImage = URL.createObjectURL(this.currentImage);
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
          this.previewImage = response.data.mainImage;
        })
        .catch((e) => {
          console.log(e);
        });
    },

    updateCar() {
      UploadService.upload(this.currentImage)
        .then((res) => {
          this.cars.main_image = res.data.fileDownloadUri
        }).then( () =>{
          let data = {
          name: this.cars.name,
          brand: this.cars.brand,
          seatNumber: this.cars.seat_number,
          licensePlates: this.cars.license_plates,
          description: this.cars.description,
          mainImage: this.cars.main_image,
          color: this.cars.color,
          rentalPrice: this.cars.rental_price,
          }
          CarService.update(this.$route.params.id, data)
        })
        .then(() => {
          swal("Success!", "Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch(() => {
          swal("Error!", "Failed!", "error", {
            button: false,
            timer: 2000
          });
        });

    },
  },
  mounted() {
    console.log("test");
    this.getCarById(this.$route.params.id);
  },

}
</script>

<style>
.swal-modal {
  text-align: center;
  align-items: center;
}

.swal-text {
  background-color: #FEFAE3;
  padding: 17px;
  border: 1px solid #F0E1A1;
  display: block;
  margin: 22px;
  text-align: center;
  color: #61534e;
  border-radius: 2px;
}

/* .swal-button {
  padding: 7px 29px;
  border-radius: 2px;
  background-color: #059669;
  font-size: 12px;
  text-shadow: 0px -1px 0px #45ebb6;
  align-items: center;
} */
.swal-footer {
  text-align: center;
}
</style>
