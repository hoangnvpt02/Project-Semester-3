<template>
  <div class="flex flex-wrap mt-4">
    <div class="w-full mb-12 px-4">
      <OrderList/>
    </div>
  </div>
</template>
<script>
import OrderList from "@/components/Cards/OrderList.vue";

export default {
  components: {
    OrderList,
},
};
</script>
