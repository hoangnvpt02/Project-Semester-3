import { createApp } from 'vue'
import App from './App.vue'
import { createWebHistory, createRouter } from "vue-router";
import Index from "@/components/ClientPage/Index.vue";
import About from "@/components/ClientPage/About.vue";
import Product from "@/components/ClientPage/Product.vue";
import ProductAsCate from "@/components/ClientPage/ProductAsCate.vue";
import Contact from "@/components/ClientPage/Contact.vue";
import ProductDetail from "@/components/ClientPage/ProductDetail.vue";
import Cart from "@/components/ClientPage/order/Cart.vue";
import Auction from "@/components/ClientPage/Auction.vue";
import Login from "@/components/ClientPage/Login.vue";
import Register from "@/components/ClientPage/Register.vue";

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
    path: "/cart",
    component: Cart,
  },
  {
    path: "/product/category/:id",
    component: ProductAsCate,
    name: "productAsCate"
  },
  {
    path: "/contact",
    component: Contact,
  },
  {
    path: "/detail/:id",
    component: ProductDetail,
    name: "detail"
  },
  {
    path: "/auction",
    component: Auction,
  },
  {
    path: "/login",
    component: Login,
  },
  {
    path: "/register",
    component: Register,
  },
  { path: "/:pathMatch(.*)*", redirect: "/home" },

];

const router = createRouter({
  history: createWebHistory(),
  routes,
});
// createApp(App).mount('#app')
createApp(App).use(router).mount("#app");