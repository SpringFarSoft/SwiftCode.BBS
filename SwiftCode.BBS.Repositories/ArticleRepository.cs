using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories.BASE;
using SwiftCode.BBS.Repositories.EfContext;

namespace SwiftCode.BBS.Repositories
{
    public class ArticleRepository: BaseRepository<Article>, IArticleRepository
    {
        //private SwiftCodeBbsContext context;
        //public ArticleRepository()
        //{
        //    context = new SwiftCodeBbsContext();
        //}
        //public void Add(Article model)
        //{
        //    context.Articles.Add(model);
        //    context.SaveChanges();
        //}

        //public void Delete(Article model)
        //{
        //    context.Articles.Remove(model);
        //    context.SaveChanges();
        //}

        //public void Update(Article model)
        //{
        //    context.Articles.Update(model);
        //    context.SaveChanges();
        //}

        //public List<Article> Query(Expression<Func<Article, bool>> whereExpression)
        //{

        //   return  context.Articles.Where(whereExpression).ToList();
        //}
    }
}
