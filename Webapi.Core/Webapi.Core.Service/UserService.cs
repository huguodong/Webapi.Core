using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapi.Core.IRepository;
using Webapi.Core.IRepository.Base;
using Webapi.Core.IService;
using Webapi.Core.Model;
using Webapi.Core.Model.Enity;
using Webapi.Core.Model.ViewModel;
using Webapi.Core.Service.Base;

namespace Webapi.Core.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository userDal;
        private readonly IMapper iMapper;
        public UserService(IBaseRepository<User> baseRepository, IUserRepository userRepository, IMapper IMapper) : base(baseRepository)
        {
            userDal = userRepository;
            iMapper = IMapper;

        }

        public async Task<int> GetCount()
        {
            return await userDal.GetCount();
        }

        public async Task<UserViewModel> GetUserDetails(int id)
        {
            var userinfo = await userDal.QueryByID(id);

            if (userinfo != null)
            {
                //UserViewModel model = new UserViewModel()
                //{
                //    UserId = userinfo.UserId,
                //    UserName = userinfo.UserName,
                //    Address = "北京市xx区xx小区",
                //    Age = userinfo.Age,
                //    Birthday = "1996-06-26",
                //    Phone = "13888888888"

                //};
                UserViewModel model = iMapper.Map<UserViewModel>(userinfo);
                model.Address = "北京市xx区xx小区";
                model.Birthday = "1996-06-26";
                model.Phone = "13888888888";
                return model;

            }
            else
            {
                return null;
            }
        }
    }
}
