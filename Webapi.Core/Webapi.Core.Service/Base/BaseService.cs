using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapi.Core.IRepository.Base;
using Webapi.Core.IService.Base;
using Webapi.Core.Repository.Base;

namespace Webapi.Core.Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private readonly IBaseRepository<TEntity> baseDal;


        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            baseDal = baseRepository;
        }

        /// <summary>
        /// 写入实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Add(TEntity model)
        {
            return await baseDal.Add(model);
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await baseDal.DeleteByIds(ids);
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public async Task<TEntity> QueryByID(object objId)
        {
            return await baseDal.QueryByID(objId);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity model)
        {
            return await baseDal.Update(model);
        }
    }
}
