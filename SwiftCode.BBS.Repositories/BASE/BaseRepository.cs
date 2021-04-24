using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.IRepositories.BASE;

namespace SwiftCode.BBS.Repositories.BASE
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private SwiftCodeBbsContext context;
        public BaseRepository()
        {
            context = new SwiftCodeBbsContext();
        }
        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="model"></param>
        public void Add(TEntity model)
        {
            context.Set<TEntity>().Add(model);
            context.SaveChanges();
        }
        /// <summary>
        /// 删除指定对象的数据
        /// </summary>
        /// <param name="model"></param>
        public void Delete(TEntity model)
        {
            context.Set<TEntity>().Remove(model);
            context.SaveChanges();
        }
        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="model"></param>
        public void Update(TEntity model)
        {
            context.Set<TEntity>().Update(model);
            context.SaveChanges();
        }
        /// <summary>
        /// 功能描述:查询所有数据
        /// </summary>
        /// <returns></returns>
        public Task<List<TEntity>> Query()
        {
            return context.Set<TEntity>().ToListAsync();
        }
        /// <summary>
        /// 功能描述:查询数据列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return context.Set<TEntity>().Where(whereExpression).ToListAsync();
        }
        /// <summary>
        /// 功能描述:查询一个列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            if (isAsc)
            {
                return context.Set<TEntity>().Where(whereExpression).OrderBy(orderByExpression).ToListAsync();
            }
            return context.Set<TEntity>().Where(whereExpression).OrderByDescending(orderByExpression).ToListAsync();
        }

        /// <summary>
        /// 功能描述:分页查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, int intPageIndex = 0, int intPageSize = 20)
        {
            return context.Set<TEntity>().Where(whereExpression).OrderBy(orderByExpression).Skip(intPageSize * (intPageIndex - 1)).Take(intPageSize).ToListAsync();
        }
        /// <summary>
        /// 功能描述:查询前N条数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intTop"></param>
        /// <param name="orderByExpression"></param>
        /// <returns></returns>
        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, Expression<Func<TEntity, object>> orderByExpression)
        {
            return context.Set<TEntity>().Where(whereExpression).OrderBy(orderByExpression).Take(intTop).ToListAsync();
        }
    }
}
