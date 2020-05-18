using System;
using System.Collections.Generic;
using System.Text;
using Webapi.Core.IRepository;
using Webapi.Core.Model.Enity;
using Webapi.Core.Repository.Base;

namespace Webapi.Core.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

    }
}
