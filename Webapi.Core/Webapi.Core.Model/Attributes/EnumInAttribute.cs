using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Webapi.Core.Model.Attributes
{
    /// <summary>
    /// 判断是否值是否在枚举类里面
    /// </summary>
    public class EnumInAttribute : ValidationAttribute
    {
        private readonly Dictionary<int, string> enumDic = new Dictionary<int, string>();
        public EnumInAttribute(Type type)
        {
            var nums = System.Enum.GetValues(type);
            foreach (var foo in nums)
            {
                enumDic.Add((int)foo, foo.ToString());
            }

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var values = enumDic.Keys.ToList();
            if (values.Contains((int)value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }

        }
    }
}
