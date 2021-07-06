using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.IServices.Admin;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers.Admin
{
    /// <summary>
    /// 用户收藏管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserCollectionController : ControllerBase
    {
        private readonly IUserCollectionArticleService _userCollectionArticle;

        public UserCollectionController(IUserCollectionArticleService userCollectionArticle)
        {
            _userCollectionArticle = userCollectionArticle;
        }
        /// <summary>
        /// 获取用户收藏文章列表
        /// </summary>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public async Task<MessageModel<List<UserCollectionArticleDto>>> GetUserCollectionArticlePageAsync([FromQuery] int intPageIndex = 0, int intPageSize = 20)
        {
           var list= await _userCollectionArticle.GetUserCollectionArticlePageAsync();
            return new MessageModel<List<UserCollectionArticleDto>>()
            {
                success = true,
                msg = "获取成功",
                response = list
            };
        }
    }
}
