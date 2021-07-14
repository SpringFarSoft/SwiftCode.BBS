import { createStore } from "vuex";

export default createStore({
  state: {
    token: null,
  },
  mutations: {
    saveToken(state, data) {
      state.token = data;
      window.localStorage.setItem("Token", data);
    },
  },
  actions: {},
  modules: {},
});
