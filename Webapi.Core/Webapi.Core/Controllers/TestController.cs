using Microsoft.AspNetCore.Mvc;
using System;
using Webapi.Core.IService;
using Webapi.Core.Log4net;
using Webapi.Core.Service;

namespace Webapi.Core.Controllers
{

    public class TestController : BaseController
    {
        private readonly ILoggerHelper _logger;


        public TestController(ILoggerHelper loggerHelper)
        {
            _logger = loggerHelper;
        }

        /// <summary>
        /// 测试日志
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult LogTest()
        {
            _logger.Error(typeof(TestController), "这是错误日志", new Exception("123"));
            _logger.Debug(typeof(TestController), "这是bug日志");
            //throw new System.IO.IOException();
            return Ok();
        }

        /// <summary>
        /// 抛出异常
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Throw()
        {
            throw new System.IO.IOException();
        }


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
