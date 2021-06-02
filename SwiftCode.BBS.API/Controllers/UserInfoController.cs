using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.ViewModels.UserInfo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SwiftCode.BBS.Model.Models;


namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 个人中心
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserInfoController : ControllerBase
    {

        private readonly IUserInfoService _userInfoService;
        private readonly IMapper _mapper;

        public UserInfoController(IUserInfoService userInfoService, IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
        }
        /// <summary>
        /// 用户个人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<UserInfoDetailsDto>> GetAsync()
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var userInfo = await _userInfoService.Get(x => x.Id == token.Uid);

            return new MessageModel<UserInfoDetailsDto>()
            {
                success = true,
                msg = "获取成功",
                response = _mapper.Map<UserInfoDetailsDto>(userInfo)
            };
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<MessageModel<string>> UpdateAsync(UserInfoInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var userInfo = await _userInfoService.Get(x => x.Id == token.Uid);

            userInfo = _mapper.Map<UserInfo>(input);
            _userInfoService.Update(userInfo);

            return new MessageModel<string>()
            {
                success = true,
                msg = "修改成功",
            };
        }

    }
}
