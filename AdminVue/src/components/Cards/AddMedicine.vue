<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-100 border-0">
  
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-specialist">
    <form @submit.prevent="onSubmit">
      <h6 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">
        Add Product For Auction Information
      </h6>
      <div class="flex flex-wrap">
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Auction
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="galaryId">
              <option v-for="item in galaries" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
          </div>
        </div>
        <div class="w-full lg:w-12/12 px-4">
          <div class="relative w-full mb-3">
            <label class="block uppercase text-blueGray-600 text-xs font-bold mb-2" htmlFor="grid-password">
              Product for Auction
            </label>
            <select class="border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="productId">
              <option v-for="item in products" v-bind:key="item.id" v-bind:value="item.id"> {{ item.name }} </option>
            </select>
          </div>
        </div>
      </div>
      <div class="w-full lg:w-12/12 px-4 mt-8">
        <a href="/admin/auction-product-manage" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
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
import MedicineService from "../../services/MedicineService";
import swal from 'sweetalert';
import GalaryService from "../../services/GalaryService";
import ProductService from "../../services/ProductService";
import ProductGalaryService from "../../services/ProductGalaryService";
export default {
  data() {
    let galaries
    let products
    let productId
    let galaryId
    return {
      productId,
      galaryId,
      galaries,
      products,
      medicine: {
        name: null,
        note: null,
      },
  
    }
  },
  methods: {
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
    getAllProduct() {
      ProductService.getAll()
        .then((response) => {
          this.products = response.data;
          // console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },
    save() {
      let data = {
        galaryId: this.galaryId,
        productId: this.productId,
      };
      ProductGalaryService.create(data)
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
    this.getAllProduct();
    this.getAllGalary();
  }
}
</script>

<style>

</style>
