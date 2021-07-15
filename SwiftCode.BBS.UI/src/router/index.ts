import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Register from "../views/Register.vue";
import ArticleList from "../views/ArticleList.vue";
import ArticleDetails from "../views/ArticleDetails.vue";
import ArticleCreate from "../views/ArticleCreate.vue";
const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/Register",
    name: "Register",
    component: Register,
  },
  {
    path: "/ArticleList",
    name: "ArticleList",
    component: ArticleList,
    meta: {
      requireAuth: true, // 添加该字段，表示进入这个路由是需要登录的
    },
  },
  {
    path: "/ArticleDetails/:id",
    name: "ArticleDetails",
    props: true,
    component: ArticleDetails,
    meta: {
      requireAuth: true, // 添加该字段，表示进入这个路由是需要登录的
    },
  },
  {
    path: "/ArticleCreate",
    name: "ArticleCreate",
    component: ArticleCreate,
    meta: {
      requireAuth: true, // 添加该字段，表示进入这个路由是需要登录的
    },
  },
  {
    path: "/Login",
    name: "Login",
    component: Login,
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

import store from "@/store";
var storeTemp = store;
// 路由守卫
router.beforeEach((to, from, next) => {
  if (!storeTemp.state.token) {
    storeTemp.commit("saveToken", window.localStorage.Token);
  }
  if (to.meta.requireAuth) {
    // 判断该路由是否需要登录权限
    if (storeTemp.state.token) {
      // 通过vuex state获取当前的token是否存在
      next();
    } else {
      next({
        path: "/login",
      });
    }
  } else {
    next();
  }
});

export default router;
