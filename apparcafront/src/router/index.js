import { createWebHistory, createRouter } from "vue-router";
import Home from "../views/Home.vue";
import About from "../views/About.vue";
import SubirPlaza from "../views/SubirPlaza.vue";



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
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;