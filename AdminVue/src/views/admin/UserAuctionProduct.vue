<template>
  <div class="flex flex-wrap mt-4">
    <div class="w-full mb-12 px-4">
      <UserAuction />
    </div>
  </div>
</template>
<script>
import UserAuction from "@/components/Cards/UserAuction.vue";

export default {
  components: {
    UserAuction,
  },
};
</script>
