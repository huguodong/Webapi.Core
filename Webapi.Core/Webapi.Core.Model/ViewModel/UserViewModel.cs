using System;
using System.Collections.Generic;
using System.Text;

namespace Webapi.Core.Model.ViewModel
{
    public class UserViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }


        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>

        public string Address { get; set; }
    }
}
