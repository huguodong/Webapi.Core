using System;
using System.Collections.Generic;
using System.Text;

namespace Webapi.Core.Model
{
    public   class ErrorModel
    {  
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { get; set; } = 500;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 错误详情
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}
