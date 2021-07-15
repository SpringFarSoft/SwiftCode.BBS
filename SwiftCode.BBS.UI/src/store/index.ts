import { createStore } from "vuex";

export default createStore({
  state: {
    token: null,
  },
  mutations: {
    saveToken(state, data) {
      if(data == null || data == "" || data == undefined || data == "null" || data == "undefined") {
        data = null;
      }
      state.token = data;
      window.localStorage.setItem("Token", data);
    },
  },
  actions: {},
  modules: {},
});
