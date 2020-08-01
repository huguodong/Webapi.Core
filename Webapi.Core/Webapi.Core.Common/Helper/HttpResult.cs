using System;
using System.Collections.Generic;
using System.Text;
using Webapi.Core.Model;
using Webapi.Core.Model.Enum;

namespace Webapi.Core.Common.Helper
{
    public static class HttpResult
    {

        /// <summary>
        /// 执行数据库操作成功
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="success"></param>
        /// <returns></returns>
        public static MessageModel<CurdModel> Ok(string msg = "OK", int success = 1)
        {
            var result = new MessageModel<CurdModel>
            {
                code = (int)HttpCodeEnum.OK,
                msg = msg,
                success = true,
                data = new CurdModel() { Success = success }
            };
            return result;
        }

        /// <summary>
        /// 执行查询操作成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageModel<T> Ok<T>(T data, string msg = "OK")
        {
            var result = new MessageModel<T>
            {
                code = (int)HttpCodeEnum.OK,
                msg = msg,
                success = true,
                data = data
            };
            return result;
        }

        /// <summary>
        /// 错误参数返回
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageModel<T> ErrorParameter<T>(string msg = "传入的参数格式不对")
        {
            var result = new MessageModel<T>
            {
                code = (int)HttpCodeEnum.ParameterError,
                msg = msg
            };
            return result;
        }



        /// <summary>
        /// 错误参数返回
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageModel<string> ErrorParameter(string msg = "传入的参数格式不对")
        {
            var result = new MessageModel<string>
            {
                code = (int)HttpCodeEnum.ParameterError,
                msg = msg
            };
            return result;
        }



        public static MessageModel<T> NotFount<T>(string msg = "数据不存在")
        {
            var result = new MessageModel<T>
            {
                code = (int)HttpCodeEnum.NotFount,
                msg = msg
            };
            return result;
        }


        public static MessageModel<CurdModel> NotFount(string msg = "数据不存在")
        {
            var result = new MessageModel<CurdModel>
            {
                code = (int)HttpCodeEnum.NotFount,
                msg = msg
            };
            return result;
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errMsg"></param>
        /// <param name="failed"></param>
        /// <returns></returns>
        public static MessageModel<CurdModel> Forbidden(string msg = "没有权限!", string errMsg = "", int failed = 1)
        {
            var result = new MessageModel<CurdModel>
            {
                code = (int)HttpCodeEnum.Forbidden,
                msg = msg,
                data = new CurdModel { Failed = failed, Msg = errMsg }

            };
            return result;
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static MessageModel<T> Forbidden<T>(string msg = "没有权限!", string errMsg = "")
        {
            var result = new MessageModel<T>
            {
                code = (int)HttpCodeEnum.Forbidden,
                msg = msg,

            };
            return result;
        }

        /// <summary>
        /// 数据库错误
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageModel<CurdModel> DbError(string msg = "执行操作失败!", string errMsg = "", int success = 0, int failed = 1)
        {
            var result = new MessageModel<CurdModel>
            {
                code = (int)HttpCodeEnum.DbError,
                msg = msg,
                data = new CurdModel { Success = success, Failed = failed, Msg = errMsg }

            };
            return result;
        }



        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageModel<CurdModel> Fail(string msg = "操作失败!", string errMsg = "", int failed = 1)
        {
            var result = new MessageModel<CurdModel>
            {
                code = (int)HttpCodeEnum.Faild,
                msg = msg,
                data = new CurdModel { Failed = failed, Msg = errMsg }

            };
            return result;
        }


        public static MessageModel<T> Fail<T>(string msg = "操作失败!")
        {
            var result = new MessageModel<T>
            {
                code = (int)HttpCodeEnum.Faild,
                msg = msg,
            };
            return result;
        }


        /// <summary>
        /// 排序错误
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageModel<T> SortError<T>(string msg = "排序字段有误!")
        {
            var result = new MessageModel<T>
            {
                code = (int)HttpCodeEnum.ParameterError,
                msg = msg
            };
            return result;
        }

    }
}
