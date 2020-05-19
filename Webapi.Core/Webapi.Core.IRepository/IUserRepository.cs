using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapi.Core.IRepository.Base;
using Webapi.Core.Model.Enity;

namespace Webapi.Core.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {

        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        Task<int> GetCount();
    }
}
