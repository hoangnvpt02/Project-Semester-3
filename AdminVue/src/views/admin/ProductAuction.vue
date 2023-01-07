<template>
  <div class="flex flex-wrap mt-4">
    <div class="w-full mb-12 px-4">
      <ProductAuctionList />
    </div>
  </div>
</template>
<script>
import ProductAuctionList from "@/components/Cards/ProductAuctionList.vue";

export default {
  components: {
    ProductAuctionList,
  },
};
</script>
