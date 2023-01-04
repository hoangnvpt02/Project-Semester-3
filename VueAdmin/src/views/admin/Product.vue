<template>
    <div class="flex flex-wrap mt-4">
      <div class="w-full mb-12 px-4">
        <ProductList/>
      </div>
    </div>
  </template>
  <script>
  import ProductList from "@/components/admin/ProductList.vue";
  
  export default {
    components: {
      ProductList,
  },
  };
  </script>
  