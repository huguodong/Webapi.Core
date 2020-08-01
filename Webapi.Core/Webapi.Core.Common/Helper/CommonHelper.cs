using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webapi.Core.Model;

namespace Webapi.Core.Common.Helper
{
    public static class CommonHelper
    {

        /// <summary>
        /// 根据反射获取类的属性列表
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static List<string> GetProperties(Type tp)
        {
            List<string> result = new List<string>();
            var list = tp.GetProperties();
            foreach (var item in list)
            {
                result.Add(item.Name.ToLower());
            }
            return result;
        }

        /// <summary>
        /// 比较数组
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="less_list"></param>
        /// <param name="add_list"></param>
        public static void GetListDifferent(int[] first, int[] second, ref int[] less_list, ref int[] add_list)
        {
            less_list = first.Except(second).ToArray();
            add_list = second.Except(first).ToArray();
        }




        /// <summary>
        /// 解析toke返回用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static TokenModel GetUserFromToken(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (token != null)
            {
                var userinfo = JwtHelper.SerializeJwt(token);
                return userinfo;
            }
            else
            {
                throw new Exception("Token获取失败!");
            }
        }

    }
}
