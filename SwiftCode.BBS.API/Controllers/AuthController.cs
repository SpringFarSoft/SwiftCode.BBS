using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.UserInfo;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 授权
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public AuthController(IBaseServices<UserInfo> userInfoService, IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPassWord"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<string>> Login(string loginName, string loginPassWord)
        {

            var jwtStr = string.Empty;

            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(loginPassWord))
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "用户名或密码不能为空",
                };
            }

            var pass = MD5Helper.MD5Encrypt32(loginPassWord);
            var userInfo = await _userInfoService.GetAsync(x => x.LoginName == loginName && x.LoginPassWord == pass);
            if (userInfo == null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "认证失败",
                };
            }
            jwtStr = GetUserJwt(userInfo);

            return new MessageModel<string>()
            {
                success = true,
                msg = "获取成功",
                response = jwtStr
            };

        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Register(RegisterInputDto input)
        {
            var userInfo = await _userInfoService.FindAsync(x => x.LoginName == input.LoginName);
            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "账号已存在",
                };
            }

            userInfo = await _userInfoService.FindAsync(x => x.Email == input.Email);
            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "邮箱已存在",
                };
            }

            userInfo = await _userInfoService.FindAsync(x => x.Phone == input.Phone);
            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "手机号已注册",
                };
            }

            userInfo = await _userInfoService.FindAsync(x => x.UserName == input.UserName);
            if (userInfo != null)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    msg = "用户名已存在",
                };
            }
            input.LoginPassWord = MD5Helper.MD5Encrypt32(input.LoginPassWord);

            var user = _mapper.Map<UserInfo>(input);
            user.CreateTime = DateTime.Now;
            await _userInfoService.InsertAsync(user, true);
            var jwtStr = GetUserJwt(user);

            return new MessageModel<string>()
            {
                success = true,
                msg = "注册成功",
                response = jwtStr
            };
        }

        private string GetUserJwt(UserInfo userInfo)
        {
            var tokenModel = new TokenModelJwt { Uid = userInfo.Id, Role = "User" };
            var jwtStr = JwtHelper.IssueJwt(tokenModel);
            return jwtStr;
        }

    }
}
