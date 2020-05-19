using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapi.Core.IRepository;
using Webapi.Core.Model.Enity;
using Webapi.Core.Repository.Base;

namespace Webapi.Core.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public async Task<int> GetCount()
        {

            var i = await Task.Run(() => UserDb.Count(x => 1 == 1));
            return i;
        }

    }
}
