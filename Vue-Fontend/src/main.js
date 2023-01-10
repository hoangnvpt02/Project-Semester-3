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
import ProductAuction from "@/components/ClientPage/ProductAuction.vue";
import Auction from "@/components/ClientPage/Auction.vue";
import Login from "@/components/ClientPage/Login.vue";
import Register from "@/components/ClientPage/Register.vue";
import Profile from "@/components/ClientPage/Profile.vue";

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
    path: "/product-auction/:id",
    component: ProductAuction,
    name: "product-auction"
  },
  {
    path: "/auction",
    component: Auction,
    // meta: { requiresAuth: true },

  },
  {
    path: "/login",
    component: Login,
  },
  {
    path: "/register",
    component: Register,
  },
  {
    path: "/profile",
    component: Profile,
  },
  { path: "/:pathMatch(.*)*", redirect: "/home" },

];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

router.beforeEach((to, from, next) => {

  const loggedIn = localStorage.getItem('admin');

  if (to.meta.requiresAuth && !loggedIn) {
    next('/login');
  } else {
    next();
  }
});
// createApp(App).mount('#app')
createApp(App).use(router).mount("#app");