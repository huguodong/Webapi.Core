using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapi.Core.IService.Base;
using Webapi.Core.Model.Enity;

namespace Webapi.Core.IService
{
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetCount();

    }
}
