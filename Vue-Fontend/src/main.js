import { createApp } from 'vue'
import App from './App.vue'
import { createWebHistory, createRouter } from "vue-router";
import Index from "@/components/ClientPage/Index.vue";
import About from "@/components/ClientPage/About.vue";
import Product from "@/components/ClientPage/Product.vue";
import Contact from "@/components/ClientPage/Contact.vue";
import ProductDetail from "@/components/ClientPage/ProductDetail.vue";
import Auction from "@/components/ClientPage/Auction.vue";

const routes = [
  {
    path: "/home",
    component: Index,
  },
  {
    path: "/about",
    component: About,
  },
  {
    path: "/product",
    component: Product,
  },
  {
    path: "/contact",
    component: Contact,
  },
  {
    path: "/detail",
    component: ProductDetail,
  },
  {
    path: "/auction",
    component: Auction,
  },
  { path: "/:pathMatch(.*)*", redirect: "/home" },

];

const router = createRouter({
  history: createWebHistory(),
  routes,
});
// createApp(App).mount('#app')
createApp(App).use(router).mount("#app");

