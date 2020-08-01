using System.ComponentModel.DataAnnotations;

namespace Webapi.Core.Model.Attributes
{

    /// <summary>
    /// 正整数
    /// </summary>
    public class PositiveInteger : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                int num = (int)value;
                if (num < 0)
                {
                    return new ValidationResult("不是正整数!");
                }
            }
            catch
            {
                return new ValidationResult("不是正整数!");
            }
            return ValidationResult.Success;
        }
    }
}
