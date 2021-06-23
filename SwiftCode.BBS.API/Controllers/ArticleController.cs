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
        private readonly IBaseServices<Article> _articleServices;
        private readonly IBaseServices<UserInfo> _userInfoService;
        private readonly IMapper _mapper;

        public ArticleController(IBaseServices<Article> articleServices, IBaseServices<UserInfo> userInfoService, IMapper mapper)
        {
            _articleServices = articleServices;
            _userInfoService = userInfoService;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页获取文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<List<ArticleDto>>> GetList(int page, int pageSize)
        {
            var entityList = await _articleServices.QueryPage(x=>true,x=>x.CreateTime, page, pageSize);

            return new MessageModel<List<ArticleDto>>()
            {
                success = true,
                msg = "获取成功",
                response = _mapper.Map<List<ArticleDto>>(entityList)
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
            var entity = (await _articleServices.Query(d => d.Id == id)).FirstOrDefault();
            var result = _mapper.Map<ArticleDetailsDto>(entity);
            result.ArticleList = _mapper.Map<List<ArticleDto>>(await _articleServices.QueryPage(x => x.Id != id, x => x.CollectionArticles.Count, 1, 5));
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
            entity.CreateUserInfo = await _userInfoService.Get(x => x.Id == token.Uid);
            _articleServices.Add(entity);

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
        public async Task<MessageModel<string>> UpdateAsync(int id,UpdateArticleInputDto input)
        {
            var entity = (await _articleServices.Query(d => d.Id == id)).FirstOrDefault();

            entity =  _mapper.Map(input, entity);
            
            _articleServices.Update(entity);
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
            var entity = (await _articleServices.Query(d => d.Id == id)).FirstOrDefault();
            _articleServices.Delete(entity);
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
            var entity = (await _articleServices.Query(d => d.Id == id)).FirstOrDefault();
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            entity.CollectionArticles.Add(new UserCollectionArticle()
            {
                ArticleId = id,
                UserId = token.Uid
            });
            _articleServices.Update(entity);
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
        /// <returns></returns>
        [HttpPost( Name = "CreateArticleComments")]
        public async Task<MessageModel<string>> CreateArticleCommentsAsync(int id, CreateArticleCommentsInputDto input)
        {
            var entity = (await _articleServices.Query(d => d.Id == id)).FirstOrDefault();
            var token = JwtHelper.ParsingJwtToken(HttpContext);
            entity.ArticleComments.Add(new ArticleComment()
            {
                Content = input.Content,
                CreateTime = DateTime.Now,
                UserInfo = await _userInfoService.Get(x => x.Id == token.Uid)
             });
            _articleServices.Update(entity);
            return new MessageModel<string>()
            {
                success = true,
                msg = "评论成功"
            };
        }

        /// <summary>
        /// 删除文章评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteArticleComments")]
        public async Task<MessageModel<string>> DeleteArticleCommentsAsync(int articleId, int id)
        {
            var entity = (await _articleServices.Query(d => d.Id == articleId)).FirstOrDefault();
            entity.ArticleComments.Remove(entity.ArticleComments.FirstOrDefault(x => x.Id == id));
            _articleServices.Update(entity);
            return new MessageModel<string>()
            {
                success = true,
                msg = "删除评论成功"
            };
        }

    }
}
