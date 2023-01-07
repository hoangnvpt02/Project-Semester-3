import { createApp } from "vue";
import { createWebHistory, createRouter } from "vue-router";

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
import Specialist from "@/views/admin/Specialist.vue";
import ProductList from "@/views/admin/Doctor.vue";
import MedicineList from "@/views/admin/Medicine.vue";
import ProductAuctionList from "@/views/admin/ProductAuction.vue";
import UserAuctionProduct from "@/views/admin/UserAuctionProduct.vue";
import Maps from "@/views/admin/Maps.vue";
import EditCatePage from "./components/Cards/EditCatePage.vue";
import EditSpecialist from "./components/Cards/EditSpecialist.vue";
import EditProductPage from "./components/Cards/EditProductPage.vue";
import EditMedicine from "./components/Cards/EditMedicine.vue";

// views for Auth layout

import Login from "@/views/auth/Login.vue";
import Register from "@/views/auth/Register.vue";

// views without layouts

import Landing from "@/views/Landing.vue";
import Profile from "@/views/Profile.vue";
import Index from "@/views/Index.vue";

// routes

const routes = [
  {
    path: "/admin",
    redirect: "/admin/product-manage",
    component: Admin,
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
        path: "/admin/category-manage",
        component: Tables,
      },
      {
        path: "/admin/auction-manage",
        component: Specialist,
      },
      {
        path: "/admin/product-manage",
        component: ProductList,
      },
      {
        path: "/admin/auction-product-manage",
        component: MedicineList,
      },
      {
        path: "/admin/product-auction/:id",
        component: ProductAuctionList,
      },
      {
        path: "/admin/user-product-auction/:idGa/:idPd",
        component: UserAuctionProduct,
      },
      {
        path: "/admin/cate-edit/:id",
        component: EditCatePage,
      },  
      {
        path: "/admin/specialist-edit/:id",
        component: EditSpecialist,
      },
      {
        path: "/admin/product-edit/:id",
        component: EditProductPage,
      },
      {
        path: "/admin/medicine-edit/:id",
        component: EditMedicine,
      },
      {
        path: "/admin/maps",
        component: Maps,
      },
    ],
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
    path: "/landing",
    component: Landing,
  },
  {
    path: "/profile",
    component: Profile,
  },
  {
    path: "/",
    redirect: "/admin/product-manage",
    component: Index,
  },
  { path: "/:pathMatch(.*)*", redirect: "/" },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

createApp(App).use(router).mount("#app");
