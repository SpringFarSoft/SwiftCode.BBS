<template>
  <div class="login">
    <div style="margin: auto; margin-top: 12%">
      <h1 style="text-align: center">
        <span style="color: rgb(24, 173, 145)"> 社区Logo</span>
      </h1>
    </div>

    <el-card class="box-card" style="width: 431px; margin: auto">
      <div slot="header" class="clearfix">
        <span>登录</span>
        <el-button style="float: right; padding: 3px 0" type="text"
          >注册账号 ></el-button
        >
      </div>

      <el-form
        :model="ruleForm"
        status-icon
        :rules="rules"
        ref="ruleForm"
        label-width="100px"
      >
        <el-form-item label="用户名" prop="name">
          <el-input v-model="ruleForm.name"></el-input>
        </el-form-item>

        <el-form-item label="密码" prop="pass">
          <el-input
            type="password"
            v-model="ruleForm.pass"
            autocomplete="off"
          ></el-input>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="submitForm('ruleForm')"
            >提交</el-button
          >
          <el-button @click="resetForm('ruleForm')">重置</el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Watch } from "vue-property-decorator";
import request from "@/api/http";
import { Method } from "axios";
@Component({
  components: {},
})
export default class Login extends Vue {
  private ruleForm = {
    name: "",
    pass: "",
  };

  private rules = {
    name: [{ validator: this.checkName, trigger: "blur" }],
    pass: [{ validator: this.validatePass, trigger: "blur" }],
  };

  checkName(_: any, value: string, callback: any) {
    if (!value) {
      return callback(new Error("账号不能为空"));
    } else {
      return callback();
    }
  }

  validatePass(_: any, value: string, callback: any) {
    if (value === "") {
      callback(new Error("请输入密码"));
    } else {
      return callback();
    }
  }

  submitForm(formName: any) {
    let that = this;
    (this.$refs[formName] as any).validate((valid: any) => {
      if (valid) {
        request({
          url: "/Auth/Login",
          params: {
            loginName: that.ruleForm.name,
            loginPassWord: that.ruleForm.pass,
          },
        }).then((res: any) => {
          if (!res.data.success) {
            that.$alert(res.data.msg, "登录提示", {
              confirmButtonText: "确定",
              callback: (action) => {
                return false;
              },
            });
          } else {
            that.$message({
              type: "info",
              message: `欢迎登录`,
            });
            that.$store.commit("saveToken", res.data.response); //保存 token
            that.$router.replace("/");
          }
        });
      } else {
        return false;
      }
    });
  }

  resetForm(formName: any) {
    debugger;
    (this.$refs[formName] as any).resetFields();
  }
}
</script>
