using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using SwiftCode.BBS.Common.Helper;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.ViewModels.Article;
using SwiftCode.BBS.Model.ViewModels.UserInfo;

namespace SwiftCode.BBS.API.Controllers
{
    /// <summary>
    /// 文章
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleServices _articleServices;
        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleServices articleServices, IBaseServices<UserInfo> userInfoService, IMapper mapper)
        {
            _articleServices = articleServices;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页获取文章列表
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
            var userList = await _userInfoService.GetListAsync(x=> articleUserIdList.Contains(x.Id));
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
        /// 创建文章
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> CreateAsync(CreateArticleInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);

            var entity = _mapper.Map<Article>(input);
            entity.CreateTime = DateTime.Now;
            entity.CreateUserId = token.Uid;
            await _articleServices.InsertAsync(entity, true);

            return new MessageModel<string>()
            {
                success = true,
                msg = "创建成功"
            };
        }

        /// <summary>
        /// 修改文章
        /// </summary>
        [HttpPut]
        public async Task<MessageModel<string>> UpdateAsync(int id, UpdateArticleInputDto input)
        {
            var entity = await _articleServices.GetAsync(d => d.Id == id);

            entity = _mapper.Map(input, entity);

            await _articleServices.UpdateAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                msg = "修改成功"
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
        /// 收藏文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}", Name = "CreateCollection")]
        public async Task<MessageModel<string>> CreateCollectionAsync(int id)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            await _articleServices.AddArticleCollection(id, token.Uid);
            return new MessageModel<string>()
            {
                success = true,
                msg = "收藏成功"
            };
        }


        /// <summary>
        /// 添加文章评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateArticleComments")]
        public async Task<MessageModel<string>> CreateArticleCommentsAsync(int id, CreateArticleCommentsInputDto input)
        {
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            await _articleServices.AddArticleComments(id, token.Uid, input.Content);
            return new MessageModel<string>()
            {
                success = true,
                msg = "评论成功"
            };
        }


        /// <summary>
        /// 删除文章评论
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteArticleComments")]
        public async Task<MessageModel<string>> DeleteArticleCommentsAsync(int articleId, int id)
        {
            var entity = await _articleServices.GetByIdAsync(articleId);
            entity.ArticleComments.Remove(entity.ArticleComments.FirstOrDefault(x => x.Id == id));
            await _articleServices.UpdateAsync(entity, true);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除评论成功"
            };
        }

    }
}
