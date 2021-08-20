using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwiftCode.BBS.IRepositories.BASE
{
    /// <summary>
    /// 仓储基类接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 功能描述:添加实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:批量插入实体
        /// </summary>
        /// <param name="entities">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:更新实体数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:批量更新实体
        /// </summary>
        /// <param name="entities">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:根据实体删除一条数据
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:根据筛选条件删除数据
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:根据实体集合删除数据
        /// </summary>
        /// <param name="entities">实体类集合</param>
        /// <param name="autoSave">是否马上更新到数据库</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:根据筛条件获取一条数据(如果不存在返回Null)
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:根据筛条件获取一条数据(如果不存在抛出异常)
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:获取所有数据
        /// </summary>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:根据筛选条件查询数据
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:分页查询数据
        /// </summary>
        /// <param name="skipCount">跳过多少条</param>
        /// <param name="maxResultCount">获取多少条</param>
        /// <param name="sorting">排序字段</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:获取总共多少条数据
        /// </summary>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<long> GetCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 功能描述:根据条件获取筛选数据条数
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="cancellationToken">取消令牌(当CancellationToken是取消状态，Task内部未启动的任务不会启动新线程)</param>
        /// <returns></returns>
        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
