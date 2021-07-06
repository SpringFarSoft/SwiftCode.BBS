using SwiftCode.BBS.Model.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IServices.Admin
{
    public interface IUserCollectionArticleService
    {
        Task<List<UserCollectionArticleDto>> GetUserCollectionArticlePageAsync();
    }
}
