import { createStore } from 'vuex';

const store = createStore({
  state: {
    isLoggedIn: false,
    name: "",
    token: ""
  },
  mutations: {
    login(state) {
      state.isLoggedIn = true;
    },
    logout(state) {
      state.isLoggedIn = false;
    },
  },
});

export default store;
