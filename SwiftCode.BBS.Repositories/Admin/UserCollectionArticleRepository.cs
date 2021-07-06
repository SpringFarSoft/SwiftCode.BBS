using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.IRepositories.Admin;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Admin;
using SwiftCode.BBS.Repositories.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.Repositories.Admin
{
    public class UserCollectionArticleRepository:BaseRepository<UserCollectionArticle>, IUserCollectionArticleRepository
    {
        public UserCollectionArticleRepository(SwiftCodeBbsContext context) : base(context)
        {
        }

        public async Task<List<UserCollectionArticleDto>> GetUserCollectionArticlePageAsync()
        {
            var linq = await (from a in DbContext().UserCollectionArticles
                        join ba in DbContext().UserInfos on a.UserId equals ba.Id
                        join c in DbContext().Articles on a.ArticleId equals c.Id
                        select new UserCollectionArticleDto
                        {
                            Id = a.Id,
                            Title = c.Title,
                            Tag = c.Tag,
                            Cover = c.Cover,
                            Traffic = c.Traffic,
                            CollectionUser = ba.UserName,
                            CreateTime = c.CreateTime,
                        }).ToListAsync();
            return linq;
        }
    }
}
