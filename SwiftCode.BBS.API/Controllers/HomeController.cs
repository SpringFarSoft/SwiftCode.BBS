using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using SwiftCode.BBS.Model.ViewModels.Question;
using SwiftCode.BBS.Model.ViewModels.UserInfo;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 主页
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IArticleService _articleService;
        private readonly IQuestionService _questionService;
        private readonly IAdvertisementService _advertisementService;
        private readonly IMapper _mapper;

        public HomeController(IUserInfoService userInfoService, 
            IArticleService articleService, 
            IQuestionService questionService, 
            IAdvertisementService advertisementService,
            IMapper mapper)
        {
            _userInfoService = userInfoService;
            _articleService = articleService;
            _questionService = questionService;
            _advertisementService = advertisementService;
            _mapper = mapper;
        }



        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<ArticleDto>>> GetArticle()
        {
           var articleList = await  _articleService.QueryPage(x => x.Content.Length > 50, x => x.CollectionArticles.Count, 0, 10);

           return new MessageModel<List<ArticleDto>>()
           {
               success = true,
               msg = "获取成功",
               response = _mapper.Map<List<ArticleDto>>(articleList)
           };
        }
        /// <summary>
        /// 获取问答列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<QuestionDto>>> GetQuestion()
        {
            var questionList = await _questionService.QueryPage(x => x.Content.Length > 20, x => x.QuestionComments.Count, 0, 10);

            return new MessageModel<List<QuestionDto>>()
            {
                success = true,
                msg = "获取成功",
                response = _mapper.Map<List<QuestionDto>>(questionList)
            };
        }
        /// <summary>
        /// 获取作者列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<UserInfoDto>>> GetUserInfo()
        {
            var userInfoList = await _userInfoService.QueryPage(x => true, x => x.Articles.Count, 0, 5);

            return new MessageModel<List<UserInfoDto>>()
            {
                success = true,
                msg = "获取成功",
                response = _mapper.Map<List<UserInfoDto>>(userInfoList)
            };
        }
        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<string>> GetAdvertisement()
        {
            var advertisementList = await _advertisementService.QueryPage(x => true, x=> x.CreateTime,0,5);
            return new MessageModel<string>();
        }


    }
}
