import axios from "axios";
import store from "@/store";
import router from "@/router";
const service = axios.create({
  baseURL: "http://110.40.128.93:8108/api",
  timeout: 5000,
});

//定义请求拦截器
service.interceptors.request.use(
  (config) => {
    if (window.localStorage.Token&&window.localStorage.Token.length>=128) {
      config.headers["Authorization"] = "Bearer " + store.state.token;
    }
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

//响应拦截器
service.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response) {
      if (error.response.status == 401) {
        router.replace("/Login");
      }
    }
    return Promise.reject(error);
  }
);

export default service;
