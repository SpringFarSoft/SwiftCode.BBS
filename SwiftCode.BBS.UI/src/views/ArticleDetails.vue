<template>
  <div class="ArticleDetails">
    <a-row :gutter="20" style="margin-top: 24px">
      <a-col :offset="2" :span="12">
        <a-card v-if="articleInfo != null">
          <h1
            style="
              margin-bottom: 18px;
              line-height: 1.5;
              margin: 0;
              padding: 0;
              word-break: break-all;
              word-wrap: break-word;
              font-family: PingFangSC-Medium, PingFangSC, helvetica neue,
                hiragino sans gb, arial, microsoft yahei ui, microsoft yahei,
                simsun, sans-serif;
              color: #00223b;
              font-size: 24px;
            "
          >
            {{ articleInfo.title }}
          </h1>

          <div class="article-info">
            <span> 发布时间： {{ articleInfo.createTime }}</span>

            <span style="margin-left: 34px">
              阅读量： {{ articleInfo.traffic }}</span
            >

            <span style="margin-left: 34px"> 分类： {{ articleInfo.tag }}</span>
          </div>

          <div class="article-body">
            {{ articleInfo.content }}
          </div>
        </a-card>
      </a-col>
      <a-col :span="6">
        <a-card title="关于作者" v-if="authorInfo != null">
          <b-author
            :key="authorInfo.id"
            :userName="authorInfo.userName"
            :articlesCount="authorInfo.articlesCount"
            :questionsCount="authorInfo.questionsCount"
            :headPortrait="authorInfo.headPortrait"
          ></b-author>
        </a-card>
      </a-col>
    </a-row>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref, reactive, toRefs } from "vue";
import request from "@/api/http";
import router from "@/router";
import Author from "@/components/Author.vue"; // @ is an alias to /src
export default defineComponent({
  name: "ArticleDetails",
  components: {
    "b-author": Author,
  },
  setup() {
    let id = router.currentRoute.value.params.id;

    let articleInfo = ref(null);
    let authorInfo = ref(null);

    function getArticleById() {
      request({
        url: "/Article/Get",
        params: {
          id: id,
        },
      }).then((res: any) => {
        articleInfo.value = res.data.response;
        getAuthor(res.data.response.createUserId);
      });
    }

    function getAuthor(userId: number) {
      request({
        url: "/UserInfo/GetAuthor",
        params: {
          id: userId,
        },
      }).then((res: any) => {
        authorInfo.value = res.data.response;
      });
    }

    getArticleById();

    return { articleInfo, authorInfo };
  },
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.article-body {
  margin-top: 38px;
  margin-bottom: 32px;
  word-break: break-all;
  word-wrap: break-word;
  line-height: 1.8;
  font-size: 15px;
}
</style>
