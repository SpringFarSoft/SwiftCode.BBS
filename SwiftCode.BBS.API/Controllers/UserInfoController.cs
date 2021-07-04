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
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model.Models;


namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 个人中心
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserInfoController : ControllerBase
    {

        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IArticleServices _articleServices;
        private readonly IBaseServices<Question> _questionService;
        private readonly IMapper _mapper;

        public UserInfoController(IBaseServices<UserInfo> userInfoService, IMapper mapper, IArticleServices articleServices, IBaseServices<Question> questionService)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
            _articleServices = articleServices;
            _questionService = questionService;
        }
        /// <summary>
        /// 用户个人信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<UserInfoDetailsDto>> GetAsync()
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var userInfo = await _userInfoService.GetAsync(x => x.Id == token.Uid);

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
        public async Task<MessageModel<string>> UpdateAsync(UpdateUserInfoInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            var userInfo = await _userInfoService.GetAsync(x => x.Id == token.Uid);

            userInfo = _mapper.Map<UserInfo>(input);
            await _userInfoService.UpdateAsync(userInfo, true);

            return new MessageModel<string>()
            {
                success = true,
                msg = "修改成功",
            };
        }


        /// <summary>
        /// 获取文章作者
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<UserInfoDto>> GetAuthor(int id)
        {
            var entity = await _articleServices.GetAsync(x => x.Id == id);
            var user = await _userInfoService.GetAsync(x => x.Id == entity.CreateUserId);
            var response = _mapper.Map<UserInfoDto>(user);
            response.ArticlesCount = await _articleServices.GetCountAsync(x => x.CreateUserId == user.Id);
            response.QuestionsCount = await _questionService.GetCountAsync(x => x.CreateUserId == user.Id);
            return new MessageModel<UserInfoDto>()
            {
                success = true,
                msg = "获取成功",
                response = response
            };

        }
    }
}
