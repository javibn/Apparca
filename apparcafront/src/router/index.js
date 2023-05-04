import { createWebHistory, createRouter } from "vue-router";
import Home from "../views/Home.vue";
import About from "../views/About.vue";
import SubirPlaza from "../views/SubirPlaza.vue";
import Login from "../views/Login.vue";
import Register from "../views/Register.vue";
import Details from "../views/Plaza.vue";
import MisPlazas from "../views/MisPlazas.vue";



const routes = [
  {
    path: "/", redirect: "/Home",
  },
  {
    path: "/Home",
    name: "Home",
    component: Home,
  },
  {
    path: "/About",
    name: "About",
    component: About,
  },
  {
    path: "/SubirPlaza",
    name: "SubirPlaza",
    component: SubirPlaza,
  },
  {
    path: "/Plaza/:numero",
    name: "Plaza",
    component: Details,
  },
  {
    path: "/MisPlazas",
    name: "MisPlazas",
    component: MisPlazas,
  },
  {
    path: "/Login",
    name: "Login",
    component: Login,
  },
  {
    path: "/Register",
    name: "Register",
    component: Register,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;