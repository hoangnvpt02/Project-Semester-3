<template>
<div class="relative flex flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-blueGray-50 border-0">
  <div class="flex-auto px-4 lg:px-10 py-10 pt-0" id="add-car">
    <div class="flex flex-wrap mt-5">
      <div class="w-full lg:w-6/12 px-4">
        <div class="relative w-full mb-3">
          <label class="block uppercase text-lightBlue-600 text-lg font-bold mb-3">
            Information of Customer
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            Full Name: <span class="font-normal">{{orders.customerName}}</span>
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            AGE: <span class="font-normal">{{orders.customerAge}}</span>
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            Gender: <span class="font-normal">{{orders.customerGender}}</span>
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            ADDRESS: <span class="font-normal">{{orders.customerAddress}}</span>
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            RENTAL PURPOSE: <span class="font-normal">{{orders.rentalPurpose}}</span>
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            TIME TO GET CAR : <span class="font-normal">{{orders.rentalTime}}</span>
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            Rental Time (Days): <span class="font-normal">{{orders.rentalDay}}</span>
          </label>
          <label class="block uppercase text-emerald-600 text-xs font-bold mb-3">
            Total Price: $<span class="font-bold">{{orders.totalMoney}}</span>
          </label>
          <label class="block uppercase text-blueGray-600 text-xs font-bold mb-3">
            Status of Booking:
          </label>
          <select class=" block border-0 px-3 py-3 placeholder-blueGray-300 text-blueGray-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" name="userSelect" v-model="orders.rentalStatusId">
            <option v-for="item in listStatus" v-bind:key="item.statusId" v-bind:value="item.statusId"> {{ item.name }} </option>
          </select>
          <button @click="updateOrder" class=" mt-4 w-full lg:w-3/12 bg-emerald-500 text-white active:bg-emerald-600 font-bold uppercase text-xs px-4 py-2 rounded shadow hover:shadow-md outline-none focus:outline-none mr-1 ease-linear transition-all duration-150" type="submit">
          Submit
          </button>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import OrderService from "../../services/OrderService";
import RentalStatusService from "../../services/RentalStatusService";
import swal from 'sweetalert';
export default {
  data() {
    return {
      listStatus: null,
      orders: {
        customerName: null,
        customerAge: null,
        customerGender: null,
        customerAddress: null,
        rentalPurpose: null,
        rentalTime: null,
        rentalDay: null,
        totalMoney: null,
        rentalStatusId: null
      }
    }
  },
  methods: {
    retrieveStatus() {
      RentalStatusService.getAll()
        .then((response) => {
          this.listStatus = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
    getOrderById(id) {
      OrderService.getById(id)
        .then((response) => {
          this.orders.customerName = response.data.customerName;
          this.orders.customerAge = response.data.customerAge;
          this.orders.customerGender = response.data.customerGender;
          this.orders.customerAddress = response.data.customerAddress;
          this.orders.rentalPurpose = response.data.rentalPurpose;
          this.orders.rentalTime = response.data.rentalTime;
          this.orders.rentalDay = response.data.rentalDay;
          this.orders.totalMoney = response.data.totalMoney;
          this.orders.rentalStatusId = response.data.rentalStatusId.statusId;
        })
        .catch((e) => {
          console.log(e);
        });
    },

    updateOrder() {
      let data = {
        rentalStatusId : {
          statusId: this.orders.rentalStatusId
        }
      };
      OrderService.updateOrderStatus(this.$route.params.id, data)
        .then(() => {
          swal("Success!", "Successfully!", "success", {
            button: false,
            timer: 2000
          });
        })
        .catch(() => {
          swal("Error!", "Failed!", "error", {
            button: false,
            timer: 2000
          });
        });

    },
  },
  mounted() {
    console.log("test");
    this.getOrderById(this.$route.params.id);
    this.retrieveStatus();
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
