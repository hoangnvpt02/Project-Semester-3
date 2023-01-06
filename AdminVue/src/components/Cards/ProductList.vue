<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded" :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']">
  <div class="rounded-t mb-0 px-4 py-3 border-0">
    <button @click="addCategory()" class="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button"> Add Product </button>
  </div>
    <div class=" w-full px-4 hidden" id="add-specialist">
      <AddProductPage/>
    </div>
  <div class="block w-full overflow-x-auto" id="doctor-list">
    <!-- Projects table -->
    <table class="items-center w-full bg-transparent border-collapse">
      <thead>
        <tr>
          <th v-for="(title, index) in titles"  :key="index" 
          class="px-6 align-middle border border-solid py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left bg-blueGray-50 text-blueGray-500 border-blueGray-100">
            {{ title }}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item, index) in products"  :key="index">
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ index+1 }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.name }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.author }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.price }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.isActive==0 ? "True" : "False" }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            <button v-on:click="deleteProduct(item.id)" class="text-center w-full lg:w-3/12  bg-red-500 text-white active:bg-red-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
              Delete
            </button>
            <a :href="'/admin/product-edit/' + item.id" class="text-center w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
              Edit
            </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</div>
</template>

<script>
 import { ref } from "vue"
import AddProductPage from "@/components/Cards/AddProductPage.vue";
import ProductService from '@/services/ProductService';


export default {
  data() {
	  let products

    const specialist=ref([]);
    const doctors=ref([]);
    const titles  = ref(['ID','NAME','AUTHOR','PRICE','ACTIVE','ACTIONS'])



    return {
      products,
      specialist,
      doctors,
      titles,
    };
  },
  components: {
    AddProductPage,
  },
  props: {
    color: {
      default: "light",
      validator: function (value) {
        // The value must match one of these strings
        return ["light", "dark"].indexOf(value) !== -1;
      },
    },
  },

  methods: {
    deleteProduct : function(id) {
      swal({
      title: "Are you sure?",
      icon: "warning",
      buttons: [
        'No, cancel it!',
        'Yes, I am sure!'
      ],
      dangerMode: true,
    }).then(function(isConfirm) {
      if (isConfirm) {
        ProductService.delete(id).then(() => {
        swal("Success", "Delete Successfully!", "success",{
            button: false,
            timer:2000
          })
        .then(function(){ 
          location.reload();
        })
        })
        .catch(() => {
          swal("Error", "Delete Failed!", "error",{
            button: false,
            timer:2000
          });
        });
      }
      
    })

    },
    retrieveProduct() {
			ProductService.getAll()
			.then((response) => {
          this.products = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
    addCategory() {
      document.getElementById('doctor-list').style.display = "none";
      document.getElementById('add-specialist').style.display = "block";
    },
    refreshList() {
      this.retrievecars();
      this.currentitem = {} ;
      this.currentIndex = -1;
    },
    setActiveitem(item, index = -1) {
      this.currentitem = item;
      this.currentIndex = index;
    },
  },
  created() {
		// this.baseUrl = this.base.baseUrl+ 'api/files/'
		this.retrieveProduct()
	},
};
</script>
