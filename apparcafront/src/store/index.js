import { createStore } from 'vuex';

const store = createStore({
  state: {
    isLoggedIn: false,
    name: "",
    token: ""
  },
  mutations: {
    login(state, data) {
      state.isLoggedIn = true;
      state.token = data.result;
      state.name = data.user.nombre
    },
    logout(state) {
      state.isLoggedIn = false;
    },
  },
  actions: {
    setToken({ commit }, data) {
      commit('login', data);
    }
  }
});

export default store;
