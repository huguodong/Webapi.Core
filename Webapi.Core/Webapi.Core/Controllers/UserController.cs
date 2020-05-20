using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Webapi.Core.Auth;
using Webapi.Core.Common.Helper;
using Webapi.Core.Common.Redis;
using Webapi.Core.IService;
using Webapi.Core.Model;
using Webapi.Core.Model.Enity;
using Webapi.Core.Service;

namespace Webapi.Core.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : BaseController
    {

        private readonly IUserService _userService;
        private readonly IRedisCacheManager _redisCacheManager;

        public UserController(IUserService userService, IRedisCacheManager redisCacheManager)
        {
            _userService = userService;
            _redisCacheManager = redisCacheManager;
        }


        /// <summary>
        /// 测试automapper
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AutoMapper(int id)
        {
            var userinfo = await _userService.GetUserDetails(id);

            return Ok(userinfo);
        }

        /// <summary>
        /// 测试autofac
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Autofac()
        {
            var count = await _userService.GetCount();

            return Ok(count);
        }



        /// <summary>
        /// 测试Redis
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Redis(int id)
        {

            var key = $"Redis{id}";
            User user = new User();
            if (_redisCacheManager.Get<object>(key) != null)
            {
                user = _redisCacheManager.Get<User>(key);
            }
            else
            {
                user = await _userService.QueryByID(id);
                _redisCacheManager.Set(key, user, TimeSpan.FromHours(2));//缓存2小时
            }

            return Ok(user);
        }

        /// <summary>
        /// hello请求
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string role)
        {
            string jwtStr = string.Empty;
            bool suc = false;

            if (role != null)
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModel tokenModel = new TokenModel { Uid = "abcde", Role = role };
                jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }
        /// <summary>
        /// 需要Admin权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return Ok("hello admin");
        }


        /// <summary>
        /// 需要System权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "System")]
        public IActionResult System()
        {
            return Ok("hello System");
        }

        /// <summary>
        /// 需要System和Admin权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = "SystemOrAdmin")]

        public IActionResult SystemAndAdmin()
        {
            return Ok("hello SystemOrAdmin");
        }


        /// <summary>
        /// 解析Token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult ParseToken()
        {
            //需要截取Bearer 
            var tokenHeader = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var user = JwtHelper.SerializeJwt(tokenHeader);
            return Ok(user);

        }

        /// <summary>
        /// 获取User实体
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult User(User user)
        {
            return Ok(user);
        }


        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id">参数id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {

            User user = await _userService.QueryByID(id);
            return Ok(user);
        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="id">参数id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {

            var count = await _userService.Add(user);
            return Ok(count);
        }

        ///// <summary>
        ///// 更新数据
        ///// </summary>
        ///// <param name="id">参数id</param>
        ///// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {

            var sucess = await _userService.Update(user);
            return Ok(sucess);
        }

        ///// <summary>
        ///// 删除数据
        ///// </summary>
        ///// <param name="id">参数id</param>
        ///// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(object[] ids)
        {
            var sucess = await _userService.DeleteByIds(ids);
            return Ok(sucess);
        }



    }
}
