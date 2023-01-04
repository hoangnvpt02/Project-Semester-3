<template>
  <div class="flex flex-wrap mt-4">
    <div class="w-full mb-12 px-4">
      <SpecialistList />
    </div>
  </div>
</template>
<script>
import SpecialistList from "@/components/Cards/SpecialistList.vue";

export default {
  components: {
    SpecialistList,
  },
};
</script>
