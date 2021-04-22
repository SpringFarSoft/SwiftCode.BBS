using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SwiftCode.BBS.IRepositories;
using SwiftCode.BBS.IServices;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories;
using SwiftCode.BBS.Services.BASE;

namespace SwiftCode.BBS.Services
{
    public class ArticleService: BaseServices<Article>,IArticleService
    {
        //public IArticleRepository dal = new ArticleRepository();
        //public void Add(Article model)
        //{
        //    dal.Add(model);
        //}

        //public void Delete(Article model)
        //{
        //    dal.Delete(model);
        //}

        //public void Update(Article model)
        //{
        //    dal.Update(model);
        //}

        //public List<Article> Query(Expression<Func<Article, bool>> whereExpression)
        //{
        //   return dal.Query(whereExpression);
        //}
    }
}
