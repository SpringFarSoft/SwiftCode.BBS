<template>
  <div class="login">
    <el-card class="box-card">
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

  checkName(_: any, value: string, callback: (arg0: Error) => any) {
    if (!value) {
      return callback(new Error("账号不能为空"));
    }
  }

  validatePass(_: any, value: string, callback: (arg0: Error) => void) {
    if (value === "") {
      callback(new Error("请输入密码"));
    }
  }

  submitForm(formName: string | number) {
    this.$data[formName].validate((valid: any) => {
      if (valid) {
        alert("submit!");
      } else {
        console.log("error submit!!");
        return false;
      }
    });
  }

  resetForm(formName: string | number) {
    this.$data[formName].resetFields();
  }
}
</script>
