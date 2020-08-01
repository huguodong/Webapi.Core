namespace Webapi.Core.Model
{
    /// <summary>
    /// 令牌
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public int DeptId { get; set; }

        /// <summary>
        /// 用户名 
        /// </summary>
        public string UName { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 角色等级
        /// </summary>
        public int MaxRoleLevel { get; set; }
    }
}
