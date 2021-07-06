using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.IServices.Admin;
using SwiftCode.BBS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.Model.ViewModels.Admin;
using SwiftCode.BBS.IRepositories.Admin;

namespace SwiftCode.BBS.Services.Admin
{
    public class UserCollectionArticleService : IUserCollectionArticleService
    {
        private readonly IUserCollectionArticleRepository _userArticle;

        public UserCollectionArticleService(IUserCollectionArticleRepository userArticle)
        {
            _userArticle = userArticle;
        }
        /// <summary>
        /// 获取用户收藏文章列表分页
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserCollectionArticleDto>> GetUserCollectionArticlePageAsync()
        {
            return await _userArticle.GetUserCollectionArticlePageAsync();
        }
    }
}
