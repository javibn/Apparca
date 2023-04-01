import { createStore } from 'vuex';

const store = createStore({
  state: {
    isLoggedIn: true,
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
