<template>
  <div class="question-item">
    <div class="question-answer">
      <div class="question-answer-num">{{ comments }}</div>
      <div class="question-answer-title">回答</div>
    </div>
    <div class="question-config">
      <h3 class="question-config-title">{{ title }}</h3>
      <el-tag size="mini" v-for="tagName in tagList" :key="tagName">{{ tagName }}</el-tag>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue, Watch } from "vue-property-decorator";
@Component({
  name: "question-item",
})
export default class QuestionIten extends Vue {
  @Prop() private comments: String | undefined;
  @Prop() private title: String | undefined;
  @Prop() private tag!: String;

  private tagList = this.tag.split(",");
}
</script>

<style scoped lang="stylus">
.question-item {
  box-sizing: border-box;
  padding: 20px 8px;
  width: 50%;
  display: -webkit-inline-box;
  display: inline-flex;
  height: 20%;
}

.question-answer {
  width: 52px;
  height: 52px;
  background-color: rgba(24, 173, 145, 0.15);
  color: #18ad91;
  text-align: center;
}

.question-answer-num {
  width: 52px;
  margin-top: 8px;
  font-size: 16px;
}

.question-answer-title {
  font-size: 12px;
}

.question-config {
  box-sizing: border-box;
  margin-left: 16px;
  width: calc(100% - 85px);
}

.question-config-title {
  word-break: break-all;
  display: block;
  margin: 0;
  padding: 0;
  font-family: PingFangSC-Medium, PingFangSC, helvetica neue, hiragino sans gb, arial, microsoft yahei ui, microsoft yahei, simsun, sans-serif;
  font-size: 16px;
  color: #00223b;
  width: 100%;
  line-height: 1.5;
}
</style>