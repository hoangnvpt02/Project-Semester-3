<template>
  <div class="flex flex-wrap mt-4">
    <div class="w-full mb-12 px-4">
      <CategoryList />
    </div>
  </div>
</template>
<script>
import CategoryList from "@/components/Cards/CategoryList.vue";

export default {
  components: {
    CategoryList,
  },
};
</script>
