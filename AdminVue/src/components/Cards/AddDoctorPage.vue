<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">

  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <form @submit.prevent="onSubmit">
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Doctor Information
      </h6>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Full Name
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="doctors.name" name="name" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Phone
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="doctors.phone" name="brand" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Address
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="doctors.address" name="seat_number" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Facility
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="doctors.slFacility">
              <option v-for="item in facilities" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
            <!-- <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="facilities.website" name="license_plates" /> -->
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Specialist
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="doctors.slSpecialist">
              <option v-for="item in specialist" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
            <!-- <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="facilities.website" name="license_plates" /> -->
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Gender
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="doctors.slGender">
              <option v-for="item in genders" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
            <!-- <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="facilities.phone" name="seat_number" /> -->
          </div>
        </div>
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Avatar
            </label>
            <div class="flex items-center space-x-6">
              <div v-if="previewImage" class="shrink-0">
                <img style="width:100px;height:100px" class="object-cover rounded-md" :src="previewImage" alt="Photo" />
              </div>
              <div v-else class="shrink-0">
                <img style="width:100px;height:100px" class="object-cover rounded-md" src="https://banffventureforum.com/wp-content/uploads/2019/08/No-Image.png" alt="Current profile photo" />
              </div>
              <label class="block">
                <span class="sr-only">Choose profile photo</span>
                <input type="file" accept="image/*" ref="file" @change="selectImage" />
              </label>
               <button class="block text-center w-2/12 ml-3 bg-emerald-400 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" :disabled="!currentImage" @click="upload">
            Upload
          </button>
            </div>
          </div>
        </div>
        <!-- <div class="w-full lg:w-6/12 px-4">
          <button class="block text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" :disabled="!currentImage" @click="upload">
            Upload
          </button>

        </div> -->
      </div>
      <div class="w-full lg:w-12/12 px-4 mt-8">
        <a href="/admin/doctor-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
          Back
        </a>
        <button @click="saveCar" class="w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="submit">
          Save
        </button>
      </div>
    </form>

  </div>

</div>
</template>

<script>
import SpecialistService from "../../services/SpecialistService";
import FacilityService from "../../services/FacilityService";
import DoctorService from "../../services/DoctorService";
import UploadService from "../../services/UploadFilesService";
import { ref } from "vue"
import swal from 'sweetalert';

export default {
  data() {
    const facilities = ref([]);
    const specialist = ref([]);
    return {
      currentImage: undefined,
      previewImage: undefined,
      progress: 0,
      message: "",
      imageInfos: [],
      genders: [{
          id: 1,
          name: 'Male'
        },
        {
          id: 2,
          name: 'Female'
        },

      ],
      specialist,
      facilities,
      doctors: {
        name: null,
        phone: null,
        address: null,
        slGender: null,
        slSpecialist: null,
        slFacility: null,
        image: null,
      },
    }
  },
  methods: {
    selectImage() {
      this.currentImage = this.$refs.file.files.item(0);
      this.previewImage = URL.createObjectURL(this.currentImage);
      this.progress = 0;
      this.message = "";
    },
    upload() {
      this.progress = 0;
      UploadService.uploadAvatar(this.currentImage)
        .then((response) => {
          this.message = response.data.message;
          this.doctors.image = response.data.fileDownloadUri;

          // return UploadService.getFiles();
        })
        .then(() => {
          swal("Success!", "Upload Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch(() => {
          swal("Error!", "Upload Failed!", "error", {
            button: false,
            timer: 2000
          });
        });
    },
    retrievefacilities() {
      FacilityService.getAll()
        .then((response) => {
          this.facilities = response.data.content;
          console.log(response.data.content);
        })
        .catch((e) => {
          console.log(e);
        });
    },
    retrieveSpecialist() {
      SpecialistService.getAll()
        .then((response) => {
          this.specialist = response.data;
          console.log(response.data.content);
        })
        .catch((e) => {
          console.log(e);
        });
    },
    saveCar() {
      let data = {
        name: this.doctors.name,
        phone: this.doctors.phone,
        address: this.doctors.address,
        gender: this.doctors.slGender,
        specialists: {
          id: this.doctors.slSpecialist
        },
        healthFacilities: {
          id: this.doctors.slFacility
        },
        image:  this.doctors.image

      };
      console.log("log data");
      console.log(data);
      DoctorService.create(data)
        .then(() => {
          swal("Success!", "Add Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch(() => {
          swal("Error!", "Add Failed!", "error", {
            button: false,
            timer: 2000
          });
        });
    },
  },
  mounted() {
    this.retrievefacilities();
    this.retrieveSpecialist();
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
  font-weight: normal;
  color: limegreen;
  padding: 0.5em;
  border: thin solid gainsboro;
  border-radius: 5px;
  cursor: pointer;
}
</style>
