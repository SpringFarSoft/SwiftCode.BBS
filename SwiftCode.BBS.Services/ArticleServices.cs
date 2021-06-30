using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Model.ViewModels.Article;
using SwiftCode.BBS.Services.BASE;

namespace SwiftCode.BBS.Services
{
    public class ArticleServices : BaseServices<Article>, IArticleServices
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleServices(IBaseRepository<Article> baseRepository, IArticleRepository articleRepository) : base(baseRepository)
        {
            _articleRepository = articleRepository;
        }


        public Task<Article> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _articleRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
