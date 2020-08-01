using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Webapi.Core.Model.Attributes;

namespace Webapi.Core.Model
{
    public class PageViewModel : IValidatableObject
    {

        /// <summary>
        /// 页数
        /// </summary>
        [PositiveInteger(ErrorMessage = "页数超出范围!")]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页显示数量
        /// </summary>
        [Range(1, 200, ErrorMessage = "每页最多显示200条")]
        public int PageSize { get; set; } = 20;


        /// <summary>
        /// 排序类型desc,asc
        /// </summary>
        public string OrderType { get; set; } = "asc";

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderBy != null && OrderType == null)
            {
                yield return new ValidationResult("排序类型不能为空!");
            }
            if (OrderType != null && OrderType.ToLower() != "asc" && OrderType.ToLower() != "desc")
            {
                yield return new ValidationResult("排序类型为asc或desc !");
            }
            yield break;
        }
    }
}
