using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.Core.Common.Helper;
using Webapi.Core.IRepository.Base;
using Webapi.Core.IService.Base;
using Webapi.Core.Model;
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
        public virtual async Task<MessageModel<CurdModel>> Add(TEntity model)
        {

            var result = await baseDal.Add(model);
            if (result)
            {
                return HttpResult.Ok();
            }
            else
            {
                return HttpResult.DbError("添加失败!");
            }

        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<MessageModel<CurdModel>> DeleteById(object id)
        {
            var result = await baseDal.DeleteById(id);
            if (result)
            {
                return HttpResult.Ok();
            }
            else
            {
                return HttpResult.DbError("删除失败!");
            }
        }

        /// <summary>
        /// 根据ID数组删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>

        public virtual async Task<MessageModel<CurdModel>> DeleteByIds(object[] ids)
        {


            var result = await baseDal.DeleteByIds(ids);
            if (result == ids.Count())
            {
                return HttpResult.Ok($"成功删除{result}条数据！", result);
            }
            else
            {
                return HttpResult.DbError($"成功删除了{result}条数据,{ids.Count() - result}条数据删除失败！", null, result, ids.Count() - result);

            }

        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="objId"></param>
        /// <returns></returns>
        public virtual async Task<MessageModel<TEntity>> GetById(object objId)
        {
            var result = await baseDal.GetById(objId);
            if (result != null)
            {
                return HttpResult.Ok(result);
            }
            else
            {
                return HttpResult.Fail<TEntity>("获取信息失败!");

            }

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public virtual async Task<Tuple<List<TEntity>, int, int>> PageList(int pageIndex, int pageSize)
        {
            return await baseDal.PageList(pageIndex, pageSize);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual async Task<MessageModel<CurdModel>> Update(TEntity model)
        {
            var result = await baseDal.Update(model);
            if (result)
            {
                return HttpResult.Ok();
            }
            else
            {
                return HttpResult.Fail();

            }
        }


    }
}
