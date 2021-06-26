using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
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
        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IBaseServices<Article> _articleService;
        private readonly IBaseServices<Question> _questionService;
        private readonly IBaseServices<Advertisement> _advertisementService;
        private readonly IMapper _mapper;

        public HomeController(IBaseServices<UserInfo> userInfoService,
            IBaseServices<Article> articleService,
            IBaseServices<Question> questionService,
            IBaseServices<Advertisement> advertisementService,
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
           // todo
           var articleList = await  _articleService.GetPagedListAsync( 1, 10, nameof(Article.CreateTime));

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
            var questionList = await _questionService.GetPagedListAsync(1, 10, nameof(Question.CreateTime));

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
            var userInfoList = await _userInfoService.GetPagedListAsync(1, 5,nameof(UserInfo.CreateTime));

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
            var advertisementList = await _advertisementService.GetPagedListAsync(1,5, nameof(Advertisement.CreateTime));
            return new MessageModel<string>();
        }


    }
}
