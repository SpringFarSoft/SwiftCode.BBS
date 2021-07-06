using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleManagerController : ControllerBase
    {
        private readonly IArticleServices _articleServices;
        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public ArticleManagerController(IArticleServices articleServices, IBaseServices<UserInfo> userInfoService, IMapper mapper)
        {
            _articleServices = articleServices;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 文章管理分页获取文章列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<ArticleDto>>> GetList(int page, int pageSize)
        {
            // 这里只是展示用法，还可以通过懒加载的形式 或 自定义仓储去Include UserInfo
            var entityList = await _articleServices.GetPagedListAsync(page, pageSize, nameof(Article.CreateTime));
            var articleUserIdList = entityList.Select(x => x.CreateUserId);
            var userList = await _userInfoService.GetListAsync(x => articleUserIdList.Contains(x.Id));
            var response = _mapper.Map<List<ArticleDto>>(entityList);
            foreach (var item in response)
            {
                var user = userList.FirstOrDefault(x => x.Id == item.CreateUserId);
                item.UserName = user.UserName;
                item.HeadPortrait = user.HeadPortrait;
            }
            return new MessageModel<List<ArticleDto>>()
            {
                success = true,
                msg = "获取成功",
                response = response
            };
        }
        /// <summary>
        /// 根据Id查询文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<ArticleDetailsDto>> Get(int id)
        {
            // 通过自定义服务层处理内部业务
            var entity = await _articleServices.GetArticleDetailsAsync(id);
            var result = _mapper.Map<ArticleDetailsDto>(entity);
            return new MessageModel<ArticleDetailsDto>()
            {
                success = true,
                msg = "获取成功",
                response = result
            };
        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<MessageModel<string>> DeleteAsync(int id)
        {
            var entity = await _articleServices.GetAsync(d => d.Id == id);
            await _articleServices.DeleteAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除成功"
            };
        }
        /// <summary>
        /// 获取文章评论
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<string>>> GetArticleCommentsAsync(int id)
        {
            var list =await _articleServices.GetArticleCommentsAsync(id);
            return new MessageModel<List<string>>()
            {
                success = true,
                msg = "获取成功",
                response = list
            };
        }
    }
}
