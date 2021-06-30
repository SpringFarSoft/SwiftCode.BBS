using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories.BASE;

namespace SwiftCode.BBS.Repositories
{
    public class ArticleRepository: BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(SwiftCodeBbsContext context) : base(context)
        {
        }

        public Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
           return DbContext().Articles.Where(x=>x.Id == id)
                .Include(x=>x.ArticleComments).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
