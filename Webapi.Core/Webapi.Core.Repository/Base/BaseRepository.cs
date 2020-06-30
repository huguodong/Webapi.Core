using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Webapi.Core.IRepository.Base;

namespace Webapi.Core.Repository.Base
{
    public class BaseRepository<TEntity> : DbContext<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
    {

        /// <summary>
        /// 写入实体数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Add(TEntity model)
        {
            return await Task.Run(() =>
            {
                var result = CurrentDb.AsInsertable(model).IgnoreColumns(true).ExecuteCommand();
                return result > 0;
            });


        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteById(dynamic id)
        {
            return await Task.Run(() => CurrentDb.DeleteById(id));
        }


        /// <summary>
        /// 根据主键数组删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<int> DeleteByIds(object[] ids)
        {

            return await Task.Run(() => Db.Deleteable<TEntity>().In(ids).With(SqlWith.RowLock).ExecuteCommand());
        }

        /// <summary>
        /// 根据ID查询一条数据
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public async Task<TEntity> GetById(object objId)
        {
            return await Task.Run(() => Db.Queryable<TEntity>().InSingle(objId));
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> GetList()
        {
            return await Task.Run(() => Db.Queryable<TEntity>().ToList());
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Tuple<List<TEntity>, int, int>> PageList(int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
        {
            int totalNumber = 0;
            int totalPage = 0;
            var data = CurrentDb.AsQueryable().ToPageList(pageIndex, pageSize, ref totalNumber, ref totalPage);
            return new Tuple<List<TEntity>, int, int>(data, totalNumber, totalPage);
        });

        }

        public async Task<TEntity> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Db.Queryable<TEntity>().WhereIF(whereExpression != null, whereExpression).FirstAsync();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> QueryList(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Db.Queryable<TEntity>().WhereIF(whereExpression != null, whereExpression).ToListAsync();
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity model)
        {
            //这种方式会以主键为条件
            var i = await Task.Run(() => Db.Updateable(model).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommand());
            return i > 0;
        }
    }
}
