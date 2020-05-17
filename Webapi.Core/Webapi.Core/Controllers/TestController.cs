using Microsoft.AspNetCore.Mvc;
using Webapi.Core.IService;
using Webapi.Core.Service;

namespace Webapi.Core.Controllers
{

    public class TestController : BaseController
    {
        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        [HttpGet]
        public int Sum(int i, int j)
        {
            ITestService testService = new TestService();
            return testService.Sum(i, j);
        }
    }
}
