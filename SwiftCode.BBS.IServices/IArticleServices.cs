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

        Task<Article> GetArticleDetailsAsync(int id, CancellationToken cancellationToken = default);

        Task AddArticleCollection(int id, int userId, CancellationToken cancellationToken = default);

        Task AddArticleComments(int id, int userId, string content, CancellationToken cancellationToken = default);
    }
}
