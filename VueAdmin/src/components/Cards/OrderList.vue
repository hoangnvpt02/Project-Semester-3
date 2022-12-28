<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded" :class="[color === 'light' ? 'bg-white' : 'bg-emerald-900 text-white']">
  <div class="rounded-t mb-0 px-4 py-3 border-0">
    <button @click="addCar()" class="bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="button"> Add Car </button>
  </div>
    <div class=" w-full px-4 hidden" id="add-car">
      <AddCarPage />
    </div>
  <div class="block w-full overflow-x-auto" id="cars-list">
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
        <tr v-for="(item, index) in orders"  :key="index">
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ index+1 }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.customerName }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.rentalTime   }}
          </td>
          <td class=" border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.rentalDay  }}
          </td>
          <td class=" border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.rentalStatusId.name  }}
          </td>
            <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            {{ item.totalMoney }}
          </td>
          <td class="border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 text-left">
            <OrderDropdown :orderId="item.orderId"/>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</div>
</template>

<script>
import { ref } from "vue"
import AddCarPage from "@/components/Cards/AddCarPage.vue";
// import TableDropdown from "@/components/Dropdowns/TableDropdown.vue";
import OrderService from "../../services/OrderService";
import OrderDropdown from "../Dropdowns/OrderDropdown.vue";


export default {
  data() {
    const orders=ref([]);
    const titles  = ref(['ID','CUSTOMER NAME','TIME TO GET CAR','RENTAL DAY','STATUS','TOTAL MONEY','ACTIONS'])



    return {
      orders,
      titles,
      // currentitem,
      currentIndex: -1,
      title: "",
      ok:[1,2,3],
    };
  },
  components: {
    // TableDropdown,
    AddCarPage,
    OrderDropdown
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
    addCar() {
      document.getElementById('cars-list').style.display = "none";
      document.getElementById('add-car').style.display = "block";
    },


    retrieveOrder() {
      OrderService.getAll()
        .then((response) => {
          this.orders = response.data;
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
  mounted() {
    this.retrieveOrder();
  },
};
</script>
