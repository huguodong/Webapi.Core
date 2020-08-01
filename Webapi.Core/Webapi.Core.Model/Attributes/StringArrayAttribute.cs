using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webapi.Core.Model.Attributes
{
    /// <summary>
    /// 限制数组范围
    /// </summary>
    public class StringArrayAttribute : ValidationAttribute
    {
        private readonly int maxLenth;
        private readonly int minLenth;

        public StringArrayAttribute(int MaxLenth = 0, int MinLenth = 0)
        {
            maxLenth = MaxLenth;
            minLenth = MinLenth;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                List<string> Valid = (List<string>)value;
                if (Valid != null)
                {
                    if (maxLenth != 0 && Valid.Count > maxLenth)
                    {
                        return new ValidationResult($"数组长度最大为{maxLenth}!");
                    }
                    if (minLenth != 0 && Valid.Count < minLenth)
                    {
                        return new ValidationResult($"数组长度最小为{minLenth}!");
                    }
                }

            }
            catch
            {
                return new ValidationResult("不是String类型的数组!");
            }
            return ValidationResult.Success;
        }
    }
}
