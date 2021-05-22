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

namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]")]
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
        /// 首页精选
        /// </summary>
        /// <returns></returns>
        public async Task<MessageModel<string>> Index()
        {
           var articleList = await  _articleService.QueryPage(x => x.Content.Length > 50, x => x.CollectionArticles, 0, 10);
           var questionList = await _questionService.QueryPage(x => x.Content.Length > 20, x => x.QuestionComments, 0, 10);
           var userInfoList = await _userInfoService.QueryPage(x => true, x => x.Articles, 0,5);


           return  new MessageModel<string>();
        }
        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <returns></returns>
        public async Task<MessageModel<string>> GetAdvertisement()
        {
            var advertisementList = await _advertisementService.QueryPage(x => true, x=> x.CreateTime,0,5);
            return new MessageModel<string>();
        }


    }
}
