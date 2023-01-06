<template>
  <div class="flex flex-wrap mt-4">
    <div class="w-full mb-12 px-4">
      <MedicineList />
    </div>
  </div>
</template>
<script>
import MedicineList from "@/components/Cards/MedicineList.vue";

export default {
  components: {
    MedicineList,
  },
};
</script>
