import { createWebHistory, createRouter } from "vue-router";
import Home from "../views/Home.vue";
import VistaMapa from "../views/VistaMapa.vue";
import VistaLista from "../views/VistaLista.vue";
import About from "../views/About.vue";
import Login from "../views/Login.vue";

const routes = [
  {
    path: "/", redirect: "/Home",
  },
  {
    path: "/Home",
    name: "Home",
    component: Home,
    meta: { showHeader: false },
  },
  {
    path: "/VistaMapa",
    name: "VistaMapa",
    component: VistaMapa,
    meta: { showHeader: true },
  },
  {
    path: "/VistaLista",
    name: "VistaLista",
    component: VistaLista,
    meta: { showHeader: true },
  },
  {
    path: "/Login",
    name: "Login",
    component: Login,
    meta: { showHeader: true },
  },
  {
    path: "/About",
    name: "About",
    component: About,
    meta: { showHeader: true },
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;