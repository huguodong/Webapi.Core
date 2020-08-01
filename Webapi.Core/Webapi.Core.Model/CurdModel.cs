using System;
using System.Collections.Generic;
using System.Text;

namespace Webapi.Core.Model
{
    /// <summary>
    /// curd返回成功或失败数量
    /// </summary>
    public class CurdModel
    {
        /// <summary>
        /// 成功数量
        /// </summary>
        public int Success { get; set; } = 0;

        /// <summary>
        /// 失败数量
        /// </summary>
        public int Failed { get; set; } = 0;


        /// <summary>
        /// 消息数量
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    }
}
