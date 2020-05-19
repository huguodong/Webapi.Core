using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapi.Core.IRepository;
using Webapi.Core.IRepository.Base;
using Webapi.Core.IService;
using Webapi.Core.Model;
using Webapi.Core.Model.Enity;
using Webapi.Core.Service.Base;

namespace Webapi.Core.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository userDal;
        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository) : base(baseRepository)
        {
            userDal = userRepository;

        }

        public async Task<int> GetCount()
        {
            return await userDal.GetCount();
        }


    }
}
