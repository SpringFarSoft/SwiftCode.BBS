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

        public async Task<Article> GetArticleDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _articleRepository.GetByIdAsync(id, cancellationToken);
            entity.Traffic += 1;

            await _articleRepository.UpdateAsync(entity,true, cancellationToken: cancellationToken);

            return entity;
        }

        public async Task AddArticleCollection(int id, int userId, CancellationToken cancellationToken = default)
        {
            var entity = await _articleRepository.GetCollectionArticlesByIdAsync(id, cancellationToken);
            entity.CollectionArticles.Add(new UserCollectionArticle()
            {
                ArticleId = id,
                UserId = userId
            });
            await _articleRepository.UpdateAsync(entity, true, cancellationToken);
        }

        public async Task AddArticleComments(int id, int userId, string content, CancellationToken cancellationToken = default)
        {
            var entity = await _articleRepository.GetByIdAsync(id, cancellationToken);
            entity.ArticleComments.Add(new ArticleComment()
            {
                Content = content,
                CreateTime = DateTime.Now,
                CreateUserId = userId
            });
            await _articleRepository.UpdateAsync(entity, true, cancellationToken);
        }

        public async Task<List<string>> GetArticleCommentsAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _articleRepository.GetByIdAsync(id, cancellationToken);
            var list = entity.ArticleComments.Select(x => x.Content);
            return list.ToList();
        }
    }
}
