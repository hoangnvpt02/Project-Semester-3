<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded" :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']">
  <div class="rounded-t mb-0 px-4 py-3 border-0">
    <button @click="addCar()" class="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button"> Add Auction Product </button>
  </div>
    <div class=" w-full px-4 hidden" id="add-specialist">
      <AddMedicine/>
    </div>
    <h6 class=" px-4 text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase text-center">
      INFORMATION OF CURRENT Auctions
    </h6>
  <div class="block w-full overflow-x-auto" id="cars-list">
    <div class="flex flex-wrap p-4" >
        <div class="w-full lg:w-3/12 px-4"  v-for="item in galary">
          <img style="width:100%; height:200px" src="https://img.freepik.com/free-vector/antique-auction-isometric-composition_1284-22062.jpg?w=2000" alt="">
          <h3 class="text-blueGray-400 text-sm mt-3 mb-6 font-bold uppercase">{{item.name}}</h3>
          
          <p>{{item.discription}}</p>
          <span style="color:#d1c286"> Time start:</span>  <p>{{item.fromDate}}</p>
          <span style="color:#d1c286"> Time end: </span><p>{{item.toDate}}</p>
          <p><a :href="'/admin/product-auction/' + item.id" class="bg-indigo-500 text-white active:bg-indigo-600 text-xs font-bold uppercase px-3 py-1 rounded outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150">View Auction Products</a></p>
        </div>
      </div>
  </div>
</div>
</template>

<script>
 import { ref } from "vue"
import MedicineService from "../../services/MedicineService";
import AddMedicine from "@/components/Cards/AddMedicine.vue";
import MedicineDropdown from "@/components/Dropdowns/MedicineDropdown.vue";
import GalaryService from "../../services/GalaryService";

export default {
  data() {
    const medicines=ref([]);
    const titles  = ref(['ID','NAME','NOTE','ACTIONS'])
	  let galary

    return {
		  galary,
      medicines,
      titles,
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
		this.getAllGalary()
  },
};
</script>
