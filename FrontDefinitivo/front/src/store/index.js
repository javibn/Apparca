import { createStore } from 'vuex';

const store = createStore({
  state: {
    isLoggedIn: false,
    token: "",
    isCar: true,
    direccion: "",
    coordenadas: null,
    horasHome: null,
    filtroStore: null
  },
  mutations: {
    login(state, data) {
      state.isLoggedIn = true;
      state.token = data.result;
    },
    logout(state) {
      state.isLoggedIn = false;
    },
    pasarVariablesHome(state, data){
      state.isCar = data.isCar;
      state.direccion = data.direccion;
      state.coordenadas = data.coordenadas;
      state.horasHome = data.horas;
    },
    limpiar(state){
      state.filtroStore = null
    },
    PasarDatos(state, filtro){
      console.log("Aqui los subo de verdad")
      console.log(filtro)
      state.filtroStore = filtro
      console.log(state.filtroStore)
      console.log("Hasta aqui")
    }
  },
  actions: {
    setToken({ commit }, data) {
      commit('login', data);
    },
    pasarVariablesHome({ commit }, { isCar, direccion, coordenadas, horas }) {
      console.log("hola")
      commit('pasarVariablesHome', { isCar, direccion, coordenadas, horas });
    },
    limpiar({commit}){
      commit('limpiar')
    },
    PasarDatos({ commit }, filtro){
      console.log("Aqui llegan en el commit")
      console.log(filtro)
      commit('PasarDatos', filtro);
    }
  }
});

export default store;
