import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)
// 输出模块
export default new Vuex.Store({
    // 初始化的数据
    state: {
        token: null
    },
    // 改变state里面的值得方法
    mutations: {
        saveToken(state, data) {
            state.token = data;
            window.localStorage.setItem("Token", data);
        }
    },
    actions: {
    },
    modules: {
    }
})
