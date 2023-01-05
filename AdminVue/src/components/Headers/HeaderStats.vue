<template>
  <!-- Header -->
  <div class="relative bg-emerald-600 md:pt-32 pb-32 pt-12">
    <div class="px-4 md:px-10 mx-auto w-full">
      <div>
        <!-- Card stats -->
        <div class="flex flex-wrap px-4">
          <!-- <div class="w-full lg:w-6/12 xl:w-3/12 px-4">
            <card-stats
              statSubtitle="Total User"
              statTitle=350897
              statIconName="fas fa-users"
              statIconColor="bg-red-500"
            />
          </div> -->
          <!-- <div class="w-full lg:w-6/12 xl:w-3/12 px-4">
            <card-stats
              statSubtitle="Total Doctor"
              statTitle={{countDoctor
              statIconName="fas fa-user-md"
              statIconColor="bg-orange-500"
            />
          </div> -->
           <!-- <div class=" m-1 w-full lg:w-6/12 xl:w-3/12 px-4 bg-white flex items-center justify-center">
              <div class="text-white p-3 text-center inline-flex items-center justify-center w-12 h-12 shadow-lg rounded-full bg-red-500"><i class="fas fa-users"></i></div>
            <p class=" ml-1 font-semibold text-lg text-blueGray-700">TOTAL DOCTOR: {{countDoctor}} </p>
          </div> -->
          
            <div style="height:100px; " class="   w-full lg:w-8/12 xl:w-3/12  bg-white flex items-center justify-center">
              <div class="text-white p-3 text-center inline-flex items-center justify-center w-12 h-12 shadow-lg rounded-full bg-red-500"><i class="fas fa-user-md"></i></div>
            <p class=" ml-1 font-semibold text-sm text-blueGray-700">TOTAL DOCTOR: {{countDoctor}} </p>
          </div>

           <div style="height:100px; " class="   w-full lg:w-8/12 xl:w-3/12  bg-white flex items-center justify-center">
              <div class="text-white p-3 text-center inline-flex items-center justify-center w-12 h-12 shadow-lg rounded-full bg-emerald-500"><i class="fas fa-users"></i></div>
            <p class=" ml-1 font-semibold text-sm text-blueGray-700">TOTAL SPECIALIST: {{countSpecialist}} </p>
          </div>

           <div style="height:100px; " class="   w-full lg:w-8/12 xl:w-3/12  bg-white flex items-center justify-center">
              <div class="text-white p-3 text-center inline-flex items-center justify-center w-12 h-12 shadow-lg rounded-full bg-red-500"><i class="fas fa-capsules"></i></div>
            <p class=" ml-1 font-semibold text-sm text-blueGray-700">TOTAL MEDICINE: {{countMedicine}} </p>
          </div>
          
           <div style="height:100px; " class="  w-full lg:w-8/12 xl:w-3/12  bg-white flex items-center justify-center">
              <div class="text-white p-3 text-center inline-flex items-center justify-center w-12 h-12 shadow-lg rounded-full bg-emerald-500"><i class="fas fa-location-arrow"></i></div>
            <p class=" ml-1 font-semibold text-sm text-blueGray-700">TOTAL FACILITY: {{countFacility}} </p>
          </div>
          <!-- <div class="w-full lg:w-6/12 xl:w-3/12 px-4">
            <card-stats
              statSubtitle="Total Specialist"
              statTitle=49,65
              statIconName="fas fa-users"
              statIconColor="bg-red-400"
            />
          </div>
          <div class="w-full lg:w-6/12 xl:w-3/12 px-4">
            <card-stats
              statSubtitle="Medicine Type"
              statTitle=49,65
              statIconName="fas fa-capsules"
              statIconColor="bg-emerald-500"
            />
          </div> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import CardStats from "@/components/Cards/CardStats.vue";
import DoctorService from "../../services/DoctorService";
import MedicineService from "../../services/MedicineService";
import SpecialistService from "../../services/SpecialistService";
import FacilityService from "../../services/FacilityService";

export default {
  data() {
    return {
      countDoctor:Number,
      countMedicine:Number,
      countSpecialist:Number,
      countFacility:Number
    }
  },
  components: {
    // CardStats,
  },
  methods: {
    reCountDoctor() {
      DoctorService.countAll()
        .then((response) => {
          this.countDoctor = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
        reCountMedicine() {
      MedicineService.countAll()
        .then((response) => {
          this.countMedicine = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
        reCountSpecialist() {
      SpecialistService.countAll()
        .then((response) => {
          this.countSpecialist = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
        reCountFacility() {
      FacilityService.countAll()
        .then((response) => {
          this.countFacility = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },
  },
    mounted() {
    this.reCountDoctor();
    this.reCountMedicine();
    this.reCountSpecialist();
    this.reCountFacility();
  },
};
</script>
