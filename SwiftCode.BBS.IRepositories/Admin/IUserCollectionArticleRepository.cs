using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IRepositories.Admin
{
    public interface IUserCollectionArticleRepository : IBaseRepository<UserCollectionArticle>
    {
        Task<List<UserCollectionArticleDto>> GetUserCollectionArticlePageAsync();
    }
}
