<template>
  <div class="flex flex-wrap mt-4">
    <div class="w-full mb-12 px-4">
      <DoctorList />
    </div>
  </div>
</template>
<script>
import DoctorList from "@/components/Cards/DoctorList.vue";

export default {
  components: {
    DoctorList,
  },
};
</script>
