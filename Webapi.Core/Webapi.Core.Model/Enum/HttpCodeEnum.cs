namespace Webapi.Core.Model.Enum
{
    public enum HttpCodeEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        OK = 1,
        /// <summary>
        /// 失败
        /// </summary>
        Faild = 0,
        /// <summary>
        /// 数据库错误
        /// </summary>
        DbError = 2,
        /// <summary>
        /// 参数错误
        /// </summary>
        ParameterError = 400,
        /// <summary>
        /// 权限不足
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// 没有找到
        /// </summary>
        NotFount = 404,
        /// <summary>
        /// 服务器错误
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// 无效token
        /// </summary>
        TokenError = 4011,
        /// <summary>
        /// 其他客户端登录
        /// </summary>
        OtherLogin = 4012,
        /// <summary>
        /// token过期
        /// </summary>
        TokenTimeOut = 4013
    }
}
