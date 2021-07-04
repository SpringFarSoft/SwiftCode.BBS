using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.Model.Models;

namespace SwiftCode.BBS.IRepositories
{
    public interface IArticleRepository: IBaseRepository<Article>
    {

        Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<Article> GetCollectionArticlesByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
