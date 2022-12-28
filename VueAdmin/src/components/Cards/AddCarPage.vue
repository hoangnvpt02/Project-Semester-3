<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <!-- <form @submit.prevent="onSubmit"> -->
    <Form @submit="saveCar" :validation-schema="schema">
      <div v-if="!successful">
        <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
          Car Information
        </h6>
        <div class="flex flex-wrap">
          <div class="w-full lg:w-6/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Car Name
              </label>
              <Field type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.name" name="car_name" />
              <ErrorMessage name="car_name" class="text-red-500 text-sm italic" />
            </div>
          </div>
          <div class="w-full lg:w-6/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Brand Name
              </label>
              <Field type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.brand" name="car_brand" />
              <ErrorMessage name="car_brand" class="text-red-500 text-sm italic" />
            </div>
          </div>
          <div class="w-full lg:w-6/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Number Of Seat
              </label>
              <Field type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.seat_number" name="seat_number" />
              <ErrorMessage name="seat_number" class="text-red-500 text-sm italic" />
            </div>
          </div>
          <div class="w-full lg:w-6/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                License Plates
              </label>
              <Field type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.license_plates" name="license_plates" />
              <ErrorMessage name="license_plates" class="text-red-500 text-sm italic" />

            </div>
          </div>
          <div class="w-full lg:w-6/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Color
              </label>
              <Field type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.color" name="color" />
              <ErrorMessage name="color" class="text-red-500 text-sm italic" />
            </div>
          </div>
          <div class="w-full lg:w-6/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Price
              </label>
              <Field type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="cars.rental_price" name="rental_price" />
              <ErrorMessage name="rental_price" class="text-red-500 text-sm italic" />
            </div>
          </div>
        </div>
        <div class="flex flex-wrap">
          <div class="w-full lg:w-12/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Description
              </label>
              
              <Field as="textarea" type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" rows="4" required v-model="cars.description" name="description">
                
              </Field>
              <ErrorMessage name="description" class="text-red-500 text-sm italic" />
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
          <!-- <div class="w-full lg:w-12/12 px-4">
            <div class="relative w-full mb-3">
              <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
                Sub Images
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
          </div> -->
        </div>
        <div class="w-full lg:w-12/12 px-4 mt-8">
          <a href="/admin/car-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
            Back
          </a>
          <button :disabled="loading" class="w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="submit">
            <span v-show="loading" class="spinner-border spinner-border-sm">Processing</span>
            Save
          </button>
        </div>
      </div>
    </Form>
    <div v-if="message" class="alert" :class="successful ? 'alert-success' : 'alert-danger'">
      {{ message }}
    </div>

  </div>
</div>
</template>

<script>
import CarService from "../../services/CarService";
import swal from 'sweetalert';
import UploadService from "../../services/UploadFilesService";
import {
  Form,
  Field,
  ErrorMessage
} from "vee-validate";
import * as yup from "yup";
export default {
  components: {
    Form,
    Field,
    ErrorMessage,
  },
  data() {
    const schema = yup.object().shape({
      car_name: yup
        .string()
        .required("Car name is required")
        .max(50, "Must be maximum 50 characters"),
      car_brand: yup
        .string()
        .required("Brand name is required")
        .max(50, "Must be maximum 50 characters"),
      seat_number: yup
        .number()
        .typeError('You must specify a number')
        .required("Number of seat is required"),
      license_plates: yup
        .string()
        .required("License plates is required")
        .max(20, "Must be maximum 20 characters"),
      description: yup
        .string()
        .required("Description is required"),
      color: yup
        .string()
        .required("Color is required!")
        .max(20, "Must be maximum 20 characters"),
      rental_price: yup
        .number()
        .typeError('You must specify a number')
        .required("Price is required!"),
    });
    return {
      successful: false,
      loading: false,
      message: "",
      schema,
      currentImage: undefined,
      previewImage: undefined,
      cars: {
        name:"",
        brand:"",
        seat_number:null,
        license_plates:"",
        description:"",
        main_image:"",
        color:"",
        rental_price:null,
      }
    }
  },
  methods: {
    selectImage() {
      this.currentImage = this.$refs.file.files.item(0);
      this.previewImage = URL.createObjectURL(this.currentImage);
      this.progress = 0;
      this.message = "";
    },
    saveImage() {
      UploadService.upload(this.currentImage)
        .then((res) => {
          this.cars.main_image = res.data.fileDownloadUri
          console.log("1" + this.cars.main_image);
        })
    },
    saveCar() {
      this.message = "";
      this.successful = false;
      this.loading = true;
      UploadService.upload(this.currentImage)
        .then((res) => {
          this.cars.main_image = res.data.fileDownloadUri
          console.log("1" + this.cars.main_image);
        }).then(() => {
          let data = {
            name: this.cars.name,
            brand: this.cars.brand,
            seatNumber: this.cars.seat_number,
            licensePlates: this.cars.license_plates,
            description: this.cars.description,
            mainImage: this.cars.main_image,
            color: this.cars.color,
            rentalPrice: this.cars.rental_price,
          };
          CarService.create(data)
        }).then(() => {
          this.successful = true;
          this.loading = false;
          swal("Success!", "Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch((error) => {
          this.message =
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString();
          this.successful = false;
          this.loading = false;
          swal("Error!", this.message, "error", {
            button: false,
            timer: 2000
          });
        });
    },

  },
}
</script>

<style>
input[type="file"] {
  background-color: antiquewhite;
  border-radius: 5px;
  margin-left: 5px;
}

input::file-selector-button {
  font-weight: lighter;
  /* color: limegreen; */
  padding: 0.5em;
  border: thin solid gainsboro;
  border-radius: 5px;
  cursor: pointer;
  background-color: white;
}
</style>
