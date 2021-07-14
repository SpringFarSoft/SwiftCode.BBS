<template>
  <div class="home">
    <div class="app-content">
      <main class="home-container">
        <a-row :gutter="20" style="margin-top: 24px">
          <a-col :offset="2" :span="12">
            <div class="home-swiper-wrapper swiper-slide">
              <img
                src="../assets/6fd7f53b8f9b4f6caff05dfb981707a7.jpg"
                style="height: 340px; width: 100%"
              />
            </div>
          </a-col>
          <a-col :span="6">
            <a-card style="padding: 24px; text-align: center">
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

              <a-row
                style="margin: 5px auto 0"
                :gutter="20"
                type="flex"
                justify="space-around"
                align="middle"
              >
                <a-col :span="12">
                  <router-link to="/Login" style="float: right">
                    <a-radio-button
                      style="
                        background-color: rgb(24, 173, 145);
                        border-color: rgb(24, 173, 145);
                        color: aliceblue;
                      "
                      >登录</a-radio-button
                    >
                  </router-link>
                </a-col>
                <a-col :span="12">
                  <router-link to="/Login" style="float: left">
                    <a-radio-button>注册</a-radio-button>
                  </router-link>
                </a-col>
              </a-row>
            </a-card>
          </a-col>
        </a-row>

        <a-row :gutter="20" style="margin-top: 24px">
          <a-col :offset="2" :span="12">
            <a-card title="技术问答">
              <template #extra><a href="#">问答首页 ></a></template>

              <b-question
                v-for="item in questionList"
                :key="item.id"
                :comments="item.comments"
                :tag="item.tag"
                :title="item.title"
              ></b-question>
            </a-card>
          </a-col>
          <a-col :span="6">
            <a-card class="box-card" style="text-align: center">
              <a-row :gutter="20">
                <a-col :span="12"
                  ><div class="grid-content bg-purple">
                    <img
                      src="../assets/2ff4e61.svg"
                      alt="发表文章icon"
                      data-v-52a9c7f2=""
                    />
                    <div class="action-text" data-v-52a9c7f2="">发表文章</div>
                  </div></a-col
                >
                <a-col :span="12"
                  ><div class="grid-content bg-purple">
                    <img
                      src="../assets/2f55400.svg"
                      alt="提出问题icon"
                      data-v-52a9c7f2=""
                    />
                    <div class="action-text" data-v-52a9c7f2="">提出问题</div>
                  </div></a-col
                >
              </a-row>
            </a-card>

            <a-card title="热门标签" style="margin-top: 24px">
              <template #extra><a href="#">更多 ></a></template>

              <a-tag class="tags-item" color="pink">标签一</a-tag>
              <a-tag class="tags-item" color="red">标签二</a-tag>
            </a-card>
          </a-col>
        </a-row>

        <a-row :gutter="20" style="margin-top: 24px">
          <a-col :offset="2" :span="12">
            <a-card title="优选文章">
              <template #extra><a href="#">文章首页 ></a></template>

              <b-article
                v-for="item in articleList"
                :key="item.id"
                :content="item.content"
                :createTime="item.createTime"
                :userName="item.userName"
                :cover="item.cover"
                :title="item.title"
              ></b-article>
            </a-card>
          </a-col>
          <a-col :span="6">
            <a-card title="推荐作者">
              <b-author
                v-for="item in userInfoList"
                :key="item.id"
                :userName="item.userName"
                :articlesCount="item.articlesCount"
                :questionsCount="item.questionsCount"
                :headPortrait="item.headPortrait"
              ></b-author>
            </a-card>
          </a-col>
        </a-row>
      </main>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref, reactive } from "vue";
import Article from "@/components/Article.vue"; // @ is an alias to /src
import Author from "@/components/Author.vue"; // @ is an alias to /src
import Question from "@/components/Question.vue"; // @ is an alias to /src
import request from "@/api/http";
export default defineComponent({
  name: "Home",
  components: {
    "b-article": Article,
    "b-author": Author,
    "b-question": Question,
  },
  setup() {
    let articleList = ref([]);
    let questionList = ref([]);
    let userInfoList = ref([]);

    function getArticle() {
      request({
        url: "/Home/GetArticle",
      }).then((res: any) => {
        articleList.value = res.data.response;
      });
    }

    function getQuestion() {
      request({
        url: "/Home/GetQuestion",
      }).then((res: any) => {
        questionList.value = res.data.response;
      });
    }

    function getUserInfo() {
      request({
        url: "/Home/GetUserInfo",
      }).then((res: any) => {
        userInfoList.value = res.data.response;
      });
    }

    getArticle();
    getQuestion();
    getUserInfo();

    return {
      articleList,
      questionList,
      userInfoList,
    };
  },
});
</script>

<style scoped lang="scss">


.app-content {
  -webkit-box-flex: 1;
  flex-grow: 1;
}

.tags-item {
  margin: 11.5px 7px;
}
</style>
