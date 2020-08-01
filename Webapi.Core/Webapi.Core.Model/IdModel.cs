using System.ComponentModel.DataAnnotations;

namespace Webapi.Core.Model
{
    public class IdModel
    {

    }

    public class StringIdModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id必填")]
        public string Id { get; set; }
    }

    public class IntIdModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Required(ErrorMessage = "Id必填")]
        public int Id { get; set; }
    }
}
