<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded" :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']">
  <div class="rounded-t mb-0 px-4 py-3 border-0">
    <button @click="addCar()" class="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button"> Add Auction Product </button>
  </div>
    <div class=" w-full px-4 hidden" id="add-specialist">
      <AddMedicine/>
    </div>
    <h6 class=" px-4 text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase text-center">
      everyone participating in the auction
    </h6>
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
        <tr v-for="(item, index) in bids"  :key="index">
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ index+1 }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.aspNetUsersId }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.price  }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            <button style ="width: 150px;" v-on:click="fnAgree(item.id)" class="text-center w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
              Agree to bid price
            </button>
            <!-- <a :href="'/admin/cate-edit/' + item.id" class="text-center w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button">
              Agree 
            </a> -->
          </td>
        </tr>

      </tbody>
    </table>
  <!-- <div class="block w-full overflow-x-auto" id="cars-list">
    <div class="flex flex-wrap p-4" >
        <div class="w-full lg:w-4/12 px-4 py-4"  v-for="item in products">
          <img :src="baseUrl + item.fileDetailsId" alt="Image artwork">
          <h3 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase text-center">{{item.name}}</h3>
          <p class="text-center"><a :href="'/product-auction/' + item.id" class="bg-indigo-500 text-white active:bg-indigo-600 text-xs font-bold uppercase px-3 py-1 rounded outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150">View More</a></p>
        </div>
      </div>
  </div> -->
</div>
</template>

<script>
 import { ref } from "vue"
import MedicineService from "../../services/MedicineService";
import AddMedicine from "@/components/Cards/AddMedicine.vue";
import MedicineDropdown from "@/components/Dropdowns/MedicineDropdown.vue";
import GalaryService from "../../services/GalaryService";
import BidService from "../../services/BidService";
import ProductService from "../../services/ProductService";
import base from "../../base.json";
export default {
  data() {
    const medicines=ref([]);
    const titles  = ref(['ID','NAME','Price','ACTIONS'])
	  let galary
    let products
    let bids
    let baseUrl=''

    return {
      bids,
		  products,
		  galary,
      medicines,
      titles,
      baseUrl,
      base
    };
  },
  components: {
    MedicineDropdown,
    AddMedicine,
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
    fnAgree(id) {
      BidService.getByIdBid(id)
      .then((response) => {
          let productId = response.data.productId;
          let userId = response.data.aspNetUsersId;
          ProductService.getById(productId).then((response) => {
            console.log("🚀 ~ file: UserAuction.vue:104 ~ ProductService.getById ~ response", response)
            
          })
        })
        .catch((e) => {
          console.log(e);
        });
    },
    getAll(idGa,idPd) {
			BidService.getById(idGa,idPd)
			.then((response) => {
          this.bids = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
		},
    getAllGalary() {
			GalaryService.getAll()
			.then((response) => {
          this.galary = response.data;
        })
        // .catch((e) => {
        //   console.log(e);
        // });
		},
    addCar() {
      document.getElementById('cars-list').style.display = "none";
      document.getElementById('add-specialist').style.display = "block";
    },


    retrieveMedicine() {
      MedicineService.getAll()
        .then((response) => {
          this.medicines = response.data.content;
        })
        .catch((e) => {
          console.log(e);
        });
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
		this.baseUrl = this.base.baseUrl+ 'api/files/'
		this.getAllGalary()
		// this.getProductByGalary(this.$route.params.id)
    this.getAll(1,3)

  },
};
</script>
