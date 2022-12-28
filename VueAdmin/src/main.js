import { createApp } from "vue";
import { createWebHistory, createRouter } from "vue-router";
import store from "./components/store";
// styles

import "@fortawesome/fontawesome-free/css/all.min.css";
import "@/assets/styles/tailwind.css";

// mouting point for the whole app

import App from "@/App.vue";

// layouts

import Admin from "@/layouts/Admin.vue";
import Auth from "@/layouts/Auth.vue";

// views for Admin layout

import Dashboard from "@/views/admin/Dashboard.vue";
import Settings from "@/views/admin/Settings.vue";
import Tables from "@/views/admin/Tables.vue";
import Maps from "@/views/admin/Maps.vue";
import Order from "@/views/admin/Order.vue";
import EditCarPage from "./components/Cards/EditCarPage.vue";
import OrderDetail from "./components/Cards/OrderDetails.vue";

// views for Auth layout

import Login from "@/views/auth/Login.vue";
import Register from "@/views/auth/Register.vue";

// views without layouts

import Landing from "@/views/Landing.vue";
import Profile1 from "@/views/Profile.vue";
import Index from "@/views/Index.vue";
import Booking from "@/views/Booking.vue";
import BookingMore from "@/views/BookingMore.vue";
import BookingDetail from "@/views/BookingDetail.vue";
import ClientLayout from "@/views/ClientLayout.vue";
const routes = [
  {
    path: "/admin",
    redirect: "/admin/car-manage",
    component: Admin,
    meta: { requiresAuth: true },
    children: [
      {
        path: "/admin/dashboard",
        component: Dashboard,
      },
      {
        path: "/admin/settings",
        component: Settings,
      },
      {
        path: "/admin/car-manage",
        component: Tables,
      },
      {
        path: "/admin/car-edit/:id",
        component: EditCarPage,
      },
      {
        path: "/admin/order-detail/:id",
        component: OrderDetail,
      },
      
      {
        path: "/admin/maps",
        component: Maps,
      },
      {
        path: "/admin/order",
        component: Order,
      },
    ],
  },

  {

    component:ClientLayout,
    children: [
      {
        path: "/booking",
        component: Landing,
      },
      {
        path: "/profile1",
        component: Profile1,
      },  
      {
        path: "/booking/:id",
        component: Booking,
        name:"booking",
        meta: { requiresAuth: true },
      },
      {
        path: "/booking-detail/:id",
        component: BookingDetail,
        name:"booking-detail",
      },
      {
        path: "/booking-more/:id",
        component: BookingMore,
        name:"booking-more",
      meta: { requiresAuth: false },
      },
    ]
  },

  {
    path: "/auth",
    redirect: "/auth/login",
    component: Auth,
    children: [
      {
        path: "/auth/login",
        component: Login,
      },
      {
        path: "/auth/register",
        component: Register,
      },
    ],
  },
  
  {
    path: "/test",
    component: Index,
  },
  { path: "/:pathMatch(.*)*", redirect: "/" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});
router.beforeEach((to, from, next) => {
  // const publicPages = ['/booking-detail/:id','/login', '/register', '/' ,'/booking', '/auth/login'];
  // const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('user');
  // trying to access a restricted page + not logged in
  // redirect to login page
  if (to.meta.requiresAuth && !loggedIn) {
    next('/auth/login');
  } else {
    next();
  }
});

createApp(App).use(router).use(store).mount("#app");
