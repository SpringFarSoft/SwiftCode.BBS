<template>
  <div class="ArticleList">
    <a-row :gutter="20" style="margin-top: 24px">
      <a-col :offset="2" :span="12">
        <a-card title="优选文章">
          <a-list
            class="demo-loadmore-list"
            :loading="loading"
            item-layout="horizontal"
            :data-source="articleList"
          >
            <template #loadMore>
              <div
                :style="{
                  textAlign: 'center',
                  marginTop: '12px',
                  height: '32px',
                  lineHeight: '32px',
                }"
              >
                <a-spin v-if="loadingMore" />
                <a-button v-else @click="loadMore">加载更多</a-button>
              </div>
            </template>

            <template #renderItem="{ item }">
              <a-list-item>
                <b-article
                  :key="item.id"
                  :content="item.content"
                  :createTime="item.createTime"
                  :userName="item.userName"
                  :cover="item.cover"
                  :title="item.title"
                ></b-article>
              </a-list-item>
            </template>
          </a-list>
        </a-card>
      </a-col>
      <a-col :span="6">
        <a-row
          style="margin: 15px auto 0"
          type="flex"
          justify="space-around"
          align="middle"
        >
          <router-link to="/Login" style="float: right">
            <a-radio-button
              style="
                background-color: rgb(24, 173, 145);
                border-color: rgb(24, 173, 145);
                color: aliceblue;
              "
              >发布文章</a-radio-button
            >
          </router-link>
        </a-row>

        <a-card title="推荐作者" style="margin-top: 30px">
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
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref, reactive } from "vue";
import Article from "@/components/Article.vue"; // @ is an alias to /src
import Author from "@/components/Author.vue";
import request from "@/api/http";
import { message } from "ant-design-vue";
export default defineComponent({
  name: "ArticleList",
  components: {
    "b-article": Article,
    "b-author": Author,
  },
  setup(props: any) {
    let articleList = ref([]);
    let userInfoList = ref([]);

    let loading = ref(false);
    let loadingMore = ref(false);

    let page = 0;
    let pageSize = 10;

    function getArticle() {
      loading.value = true;
      loadingMore.value = true;
      request({
        url: "/Article/GetList",
        params: {
          page: page,
          pageSize: pageSize,
        },
      }).then((res: any) => {
        
        articleList.value = res.data.response;
        loading.value = false;
        loadingMore.value = false;
        if (res.data.response.length <= 0) {
          message.success("没有更多了");
        }
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
    getUserInfo();

    let loadMore = function () {
      page = page + 1;
      getArticle();
    };

    return {
      articleList,
      userInfoList,
      loading,
      loadingMore,
      loadMore,
    };
  },
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.demo-loadmore-list {
  min-height: 350px;
}
</style>