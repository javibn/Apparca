import { createStore } from 'vuex';

const store = createStore({
  state: {
    isLoggedIn: false,
    token: "",
    isCar: true,
    direccion: "",
    coordenadas: null,
    horasHome: null
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
  }
});

export default store;
