using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SwiftCode.BBS.Model.Models;

namespace SwiftCode.BBS.IRepositories
{
    public interface IArticleRepository
    {
        void Add(Article model);
        void Delete(Article model);
        void Update(Article model);
        List<Article> Query(Expression<Func<Article, bool>> whereExpression);
    }
}
