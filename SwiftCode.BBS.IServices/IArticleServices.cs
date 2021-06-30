using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;

namespace SwiftCode.BBS.IServices
{
    public interface IArticleServices: IBaseServices<Article>
    {
        Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
