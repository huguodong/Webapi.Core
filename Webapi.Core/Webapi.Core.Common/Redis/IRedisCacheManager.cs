using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Webapi.Core.Common.Redis
{
    public interface IRedisCacheManager
    {

        //获取 Reids 缓存值
        string GetValue(string key);

        //获取值，并序列化
        TEntity Get<TEntity>(string key);

        //保存
        void Set(string key, object value, TimeSpan cacheTime);

        //判断是否存在
        bool Get(string key);

        //移除某一个缓存值
        void Remove(string key);

        //全部清除
        void Clear();

        //获取 Reids 缓存值
        Task<string> GetValueAsync(string key);

        //获取值，并序列化
        Task<TEntity> GetAsync<TEntity>(string key);

        //保存
        Task SetAsync(string key, object value, TimeSpan cacheTime);

        //判断是否存在
        Task<bool> GetAsync(string key);

        //移除某一个缓存值
        Task RemoveAsync(string key);

        //根据关键字移除
        Task RemoveByKey(string key);

        //全部清除
        Task ClearAsync();
    }
}
