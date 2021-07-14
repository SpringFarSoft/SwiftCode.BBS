import { createStore } from "vuex";

export default createStore({
  state: {
    token: '' || localStorage.getItem('Token'),
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
