using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapi.Core.Auth;
using Webapi.Core.Model;

namespace Webapi.Core.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserController : BaseController
    {
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
    }
}
