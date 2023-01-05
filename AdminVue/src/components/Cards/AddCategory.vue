<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">
  
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <form @submit.prevent="onSubmit">
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Category Information
      </h6>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Name
            </label>
            <input type="text" class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" required v-model="category.name" name="name" />
          </div>
        </div>
        <div class="w-full lg:w-6/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Active
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="category.active">
              <option v-for="item in actives" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
          </div>
        </div>
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Description
            </label>
            <textarea type="text" placeholder="Example:Add description..." class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" rows="4" required v-model="category.description" name="note">
            </textarea>
          </div>
        </div>
        
      </div>
      <div class="w-full lg:w-12/12 px-4 mt-8">
        <a href="/admin/facility-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
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
import CategoryService from "../../services/CategoryService";
import swal from 'sweetalert';

export default {
  data() {
    return {
      category: {
        name: null,
        description: null,
        active: 0,
      },
      actives: [{
          id: 0,
          name: 'Active'
        },
        {
          id: 1,
          name: 'InActive'
        },
      ],
    }
  },
  methods: {

    save() {
      let data = {
        name: this.category.name,
        description: this.category.description,
        isActive: this.category.active,
      };
      CategoryService.create(data)
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
}
</script>

<style>

</style>
