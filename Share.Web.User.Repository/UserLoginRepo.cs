using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Share.Web.User.Repository
{
    /// <summary>
    /// 用户登录表
    /// </summary>
    [Table("userlogin")]
    public class UserLoginRepo : DateEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImgUrl { get; set; }
    }
}
