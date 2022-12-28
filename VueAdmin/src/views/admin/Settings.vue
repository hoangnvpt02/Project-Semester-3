<template>
  <div class="flex flex-wrap">
    <div class="w-full lg:w-8/12 px-4">
      <AddCarPage />
    </div>
    <div class="w-full lg:w-4/12 px-4">
      <CardProfile />
    </div>
  </div>
</template>
<script>
import AddCarPage from "@/components/Cards/AddCarPage.vue";
import CardProfile from "@/components/Cards/CardProfile.vue";

export default {
  components: {
    AddCarPage,
    CardProfile,
  },
};
</script>
