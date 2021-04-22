using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IRepositories.BASE
{
    public  interface IBaseRepository<TEntity> where TEntity : class
    {

        void Add(TEntity model);
        void Delete(TEntity model);
        void Update(TEntity model);
        Task<List<TEntity>> Query();
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, Expression<Func<TEntity, object>> orderByExpression);
        Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, int intPageIndex = 0, int intPageSize = 20);
    }
}
