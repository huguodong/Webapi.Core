using System;
using System.Collections.Generic;
using System.Text;
using Webapi.Core.Model;

namespace Webapi.Core.Common.Helper
{
    public static class PageHelper<TEntity>
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tuple"></param>
        /// <returns></returns>
        public static PageModel<TEntity> GetPageModel(int pageIndex, int pageSize, Tuple<List<TEntity>, int, int> tuple)
        {
            PageModel<TEntity> pageModel = new PageModel<TEntity>();
            pageModel.data = tuple.Item1;
            pageModel.IsFirstPage = pageIndex == 1 ? true : false;
            pageModel.IsLastPage = (pageIndex == tuple.Item3 || tuple.Item3 == 0) ? true : false;
            pageModel.page = pageIndex;
            pageModel.PageSize = pageSize;
            pageModel.dataCount = tuple.Item2;
            pageModel.pageCount = tuple.Item3;
            return pageModel;
        }

    }
}
