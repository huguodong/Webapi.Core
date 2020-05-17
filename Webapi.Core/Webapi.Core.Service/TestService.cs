using Webapi.Core.IRepository;
using Webapi.Core.IService;

namespace Webapi.Core.Service
{
    public class TestService : ITestService
    {
        ITestRepository test = new TestRepository();
        public int Sum(int i, int j)
        {
            return test.Sum(i, j);
        }
    }
}
