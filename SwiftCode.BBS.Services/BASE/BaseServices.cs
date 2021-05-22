using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.IServices.BASE;

namespace SwiftCode.BBS.Services.BASE
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> baseDal;

        public BaseServices(IBaseRepository<TEntity> baseDal)
        {
            this.baseDal = baseDal;
        }

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="model"></param>
        public void Add(TEntity model)
        {
            baseDal.Add(model);
        }
        /// <summary>
        /// 删除指定对象的数据
        /// </summary>
        /// <param name="model"></param>
        public void Delete(TEntity model)
        {
            baseDal.Delete(model);
        }
        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="model"></param>
        public void Update(TEntity model)
        {
            baseDal.Update(model);
        }
        /// <summary>
        /// 功能描述:查询所有数据
        /// </summary>
        /// <returns></returns>
        public Task<List<TEntity>> Query()
        {
           return baseDal.Query();
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> whereExpression)
        {
            return baseDal.Get(whereExpression);
        }

        /// <summary>
        /// 功能描述:查询数据列表
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return baseDal.Query(whereExpression);
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
            return baseDal.Query(whereExpression, orderByExpression, isAsc);
        }
        /// <summary>
        /// 功能描述:分页查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="intPageIndex"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, Expression<Func<TEntity, object>> orderByExpression)
        {
            return baseDal.Query(whereExpression, intTop, orderByExpression);
        }
        /// <summary>
        /// 功能描述:查询前N条数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="intTop"></param>
        /// <param name="orderByExpression"></param>
        /// <returns></returns>
        public Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, int intPageIndex = 0, int intPageSize = 20)
        {
            return baseDal.QueryPage(whereExpression, orderByExpression, intPageIndex, intPageSize);
        }
    }
}
