<template>
<div>
  <a class="text-blueGray-500 py-1 px-3" href="#pablo" ref="btnDropdownRef" v-on:click="toggleDropdown($event)">
    <i class="fas fa-ellipsis-v"></i>
  </a>
  <div ref="popoverDropdownRef" class="bg-white text-base z-50 float-left py-2 list-none text-left rounded shadow-lg min-w-48" v-bind:class="{
        hidden: !dropdownPopoverShow,
        block: dropdownPopoverShow,
      }">
    <button @click="deleteCar" class="hover:shadow-md outline-none focus:outline-none text-sm py-2 px-4 font-normal block w-full whitespace-nowrap bg-transparent text-blueGray-700">
      Delete
    </button>

    <router-link
          :to="'/admin/medicine-edit/' + carId"
          class="text-center hover:shadow-md outline-none text-sm py-2 px-4 font-normal block w-full whitespace-nowrap bg-transparent text-blueGray-700"
          >Edit
    </router-link>
  </div>
</div>
</template>

<script>
import { createPopper } from "@popperjs/core";
import MedicineService from "../../services/MedicineService";
import swal from "sweetalert"

export default {
  props: {
    carId: Number
  },
  data() {
    return {
      dropdownPopoverShow: false,
    };
  },
  methods: {
    deleteCar() {
      var id = this.carId;
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
        MedicineService.delete(id).then(() => {
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
    toggleDropdown: function (event) {
      event.preventDefault();
      if (this.dropdownPopoverShow) {
        this.dropdownPopoverShow = false;
      } else {
        this.dropdownPopoverShow = true;
        createPopper(this.$refs.btnDropdownRef, this.$refs.popoverDropdownRef, {
          placement: "bottom-start",
        });
      }
    },
  },
};
</script>
