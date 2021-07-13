<template>
  <div id="home">
    <header>
      <div class="header-wrapper header-wrapper-default">
        <div class="header-container">
          <h1 class="header-community-logo">
            <span style="color: #18ad91">社区Logo</span>
          </h1>

          <nav class="header-menu">
            <a class="x-link-a">问答</a>
            <a class="x-link-a">文章</a>
          </nav>

          <div class="header-user">
            <div class="header-user-login">
              <span class="user-login-btn">登录</span>
              <i class="user-login-btn-line"></i>
              <span class="user-login-btn">注册</span>
            </div>
          </div>

          <div class="header-entry">
            <el-button size="small">写文章</el-button>
            <el-button size="small">提问</el-button>
          </div>

          <div class="header-search">
            <el-input placeholder="请输入内容" class="input-with-select">
              <template #append>
                <el-button icon="el-icon-search"></el-button>
              </template>
            </el-input>
          </div>
        </div>
      </div>
    </header>

    <div class="app-content">
      <main class="home-container">
        <el-row :gutter="20" style="margin-top: 24px">
          <el-col :offset="2" :span="12">
            <div class="home-swiper-wrapper swiper-slide">
              <img
                src="../assets/6fd7f53b8f9b4f6caff05dfb981707a7.jpg"
                style="height: 340px; width: 100%"
              />
            </div>
          </el-col>
          <el-col :span="6">
            <el-card class="box-card" style="padding: 24px; text-align: center">
              <img src="../assets/052bf99.svg" alt="缺省图" />

              <div style="font-size: 20px; text-align: center">
                <span>加入</span>
                <span
                  style="color: #18ad91; font-size: xx-large; font-weight: 500"
                  >社区</span
                >
              </div>

              <div style="margin-top: 10px">
                与百万开发者一起探讨技术、实践创新
              </div>

              <el-row style="margin: 24px auto 0">
                <el-button
                  style="
                    background-color: rgb(24, 173, 145);
                    border-color: rgb(24, 173, 145);
                    color: aliceblue;
                  "
                  >登录</el-button
                >
                <el-button>注册</el-button>
              </el-row>
            </el-card>
          </el-col>
        </el-row>

        <el-row :gutter="20" style="margin-top: 24px">
          <el-col :offset="2" :span="12">
            <el-card class="box-card">
              <div slot="header" class="clearfix">
                <span>技术问答</span>
                <el-button style="float: right; padding: 3px 0" type="text"
                  >问答首页 ></el-button
                >
              </div>

              <question-item
                v-for="item in questionList" :key="item.id"
                :comments="item.comments"
                :tag="item.tag"
                :title="item.title"
              ></question-item>
            </el-card>
          </el-col>
          <el-col :span="6">
            <el-card class="box-card" style="text-align: center">
              <el-row :gutter="20">
                <el-col :span="12"
                  ><div class="grid-content bg-purple">
                    <img
                      src="../assets/2ff4e61.svg"
                      alt="发表文章icon"
                      data-v-52a9c7f2=""
                    />
                    <div class="action-text" data-v-52a9c7f2="">发表文章</div>
                  </div></el-col
                >
                <el-col :span="12"
                  ><div class="grid-content bg-purple">
                    <img
                      src="../assets/2f55400.svg"
                      alt="提出问题icon"
                      data-v-52a9c7f2=""
                    />
                    <div class="action-text" data-v-52a9c7f2="">提出问题</div>
                  </div></el-col
                >
              </el-row>
            </el-card>

            <el-card class="box-card" style="margin-top: 24px">
              <div slot="header" class="clearfix">
                <span>热门标签</span>
                <el-button style="float: right; padding: 3px 0" type="text"
                  >更多 ></el-button
                >
              </div>

              <el-tag class="tags-item">标签一</el-tag>
              <el-tag class="tags-item" type="success">标签二</el-tag>
            </el-card>
          </el-col>
        </el-row>

        <el-row :gutter="20" style="margin-top: 24px">
          <el-col :offset="2" :span="12">
            <el-card class="box-card">
              <div slot="header" class="clearfix">
                <span>优选文章</span>
                <el-button style="float: right; padding: 3px 0" type="text"
                  >文章首页 ></el-button
                >
              </div>

              <article-item
                v-for="item in articleList" :key="item.id"
                :content="item.content"
                :createTime="item.createTime"
                :userName="item.userName"
                :cover="item.cover"
                :title="item.title"
              ></article-item>
            </el-card>
          </el-col>
          <el-col :span="6">
            <el-card class="box-card">
              <div slot="header" class="clearfix">
                <span>推荐作者</span>
              </div>

              <author-item
                v-for="item in userInfoList" :key="item.id"
                :userName="item.userName"
                :articlesCount="item.articlesCount"
                :questionsCount="item.questionsCount"
                :headPortrait="item.headPortrait"
              ></author-item>

              
            </el-card>
          </el-col>
        </el-row>
      </main>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Watch } from "vue-property-decorator";
import QuestionItem from "../components/QuestionItem.vue";
import AuthorItem from "../components/AuthorItem.vue";
import ArticleItem from "../components/ArticleItem.vue";
import request from "@/api/http";
@Component({
  components: {
    QuestionItem,
    ArticleItem,
    AuthorItem,
  },
})
export default class Home extends Vue {
 private articleList = [];
  private questionList = [];
  private userInfoList = [];

  created() {
    this.getArticle();
    this.getQuestion();
    this.getUserInfo();
  }
  getArticle() {
    request({
      url: "/Home/GetArticle",
    }).then((res: any) => {
      this.articleList = res.data.response;
    });
  }
  getQuestion() {
    request({
      url: "/Home/GetQuestion",
    }).then((res: any) => {
      this.questionList = res.data.response;
    });
  }
  getUserInfo() {
    request({
      url: "/Home/GetUserInfo",
    }).then((res: any) => {
      this.userInfoList = res.data.response;
    });
  }
}
</script>

<style lang="css">
header {
  position: relative;
}

header {
  display: block;
}
.header-wrapper {
  height: 64px;
  background-color: #fff;
  box-shadow: 0 2px 5px 0 rgb(0 0 0 / 12%);
}
.header-container {
  position: relative;
  width: 1200px;
  margin: 0 auto;
}
.header-community-logo {
  float: left;
  margin: 0;
  padding-top: 10px;
  line-height: 1.4;
}
.header-community-logo img {
  height: 23px;
}
.x-link-a {
  color: inherit;
}

h1 {
  display: block;
  font-size: 2em;
  margin-block-start: 0.67em;
  margin-block-end: 0.67em;
  margin-inline-start: 0px;
  margin-inline-end: 0px;
  font-weight: bold;
}
.header-menu {
  float: left;
  line-height: 64px;
  margin-left: 40px;
}
.header-menu > a {
  font-size: 16px;
  color: #00223b;
  margin: 0 30px;
}

.header-user {
  float: right;
  line-height: 64px;
  font-size: 14px;
}
.header-user-info,
.header-user-login {
  width: 130px;
  text-align: right;
}
.user-login-btn-line {
  display: inline-block;
  width: 1px;
  height: 11px;
  background-color: #d8d8d8;
  margin: 0 11px;
}
.user-login-btn {
  cursor: pointer;
}
.header-entry {
  margin-left: 26px;
}
.header-entry {
  float: right;
  padding-top: 16px;
}
.header-search {
  float: right;
  padding-top: 11px;
}

.app-content {
  -webkit-box-flex: 1;
  flex-grow: 1;
}

.tags-item {
  margin: 11.5px 7px;
}
</style>