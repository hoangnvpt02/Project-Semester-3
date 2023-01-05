<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <form @submit.prevent>
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Specialist Information
      </h6>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Name
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="specialist.name" name="name" />
          </div>
        </div>
      </div>
      <div class="w-full lg:w-12/12 px-4">
        <a href="/admin/specialist-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
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
import SpecialistService from "../../services/SpecialistService";
import swal from 'sweetalert';
export default {
  data() {
    return {
      specialist: {
        name: null,
      }
    }
  },
  methods: {
    getCarById(id) {
      SpecialistService.getById(id)
        .then((response) => {
          this.specialist.name = response.data.name;
        })
        .catch((e) => {
          console.log(e);
        });
    },

    updateCar() {
      let data = {
        name: this.specialist.name,

      };

      SpecialistService.update(this.$route.params.id, data)
        .then(() => {
          swal("Success!", "Update Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch(() => {
          swal("Error!", "Update Failed!", "error", {
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
