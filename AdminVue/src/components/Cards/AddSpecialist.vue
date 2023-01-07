<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">
  
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-specialist">
    <form @submit.prevent="onSubmit">
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Add Auction Information
      </h6>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Name
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="galary.name" name="name" />
          </div>
        </div>
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Description
            </label>
            <textarea type="text" placeholder="Example:Add description..." class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" rows="4" v-model="galary.description" required name="note">
            </textarea>
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              TIME START
            </label>
            <input  @change="TDate()" style="height:44px" id="rental-time" class="w-full mb-2 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150 text-center" type="datetime-local" name="partydate" min="" max="2024-01-01T00:00" pattern="[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}" v-model="time_start" required>
            <input type="hidden" id="timezone" name="timezone" value="+07:00">
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              TIME END
            </label>
            <input style="height:44px" id="rental-time" class="w-full mb-2 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150 text-center" type="datetime-local" name="partydate" min="" max="2024-01-01T00:00" pattern="[0-9]{4}-[0-9]{2}-[0-9]{2}T[0-9]{2}:[0-9]{2}" v-model="time_end" required>
            <input type="hidden" id="timezone" name="timezone" value="+07:00">
          </div>
        </div>
      </div>
      <div class="w-full lg:w-12/12 px-4 mt-8">
        <a href="/admin/specialist-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
          Back
        </a>
        <button @click="save" class="w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="submit">
          Save
        </button>
      </div>
    </form>

  </div>
  
</div>
</template>

<script>
import SpecialistService from "../../services/SpecialistService";
import GalaryService from "../../services/GalaryService";
import swal from 'sweetalert';

export default {
  data() {
    let galaries
    let time_start
    let time_end
    return {
      time_start,
      time_end,
      galaries,
      galary: {
        name: null,
        description: null,
      },
  
    }
  },
  methods: {
    TDate() {
    var UserDate = document.getElementById("rental-time").value;
    var ToDate = new Date();

    if (new Date(UserDate).getTime() <= ToDate.getTime()) {
          alert("The Date must be Bigger to today date");
          return false;
     }
    return true;
    },
    getAllGalary() {
      GalaryService.getAll()
        .then((response) => {
          this.galaries = response.data;
          // console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },
    save() {
      let data = {
        name: this.galary.name,
        discription: this.galary.description,
        fromDate: this.time_start,
        toDate: this.time_end,
        authen: "string",
        address: "string",
        isActive: 0,
        creeateDate: "2023-01-06T14:10:39.187Z",
        updatedDate: "2023-01-06T14:10:39.187Z"
      };
      console.log("log data");
      console.log(data);
      GalaryService.create(data)
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
  created() {
    this.getAllGalary()
  }
}
</script>

<style>

</style>
