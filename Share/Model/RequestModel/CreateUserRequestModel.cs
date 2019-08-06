using Share.Web.User.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Share.Model
{
    /// <summary>
    /// 创建用户RequestModel
    /// </summary>
    public class CreateUserRequestModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required, MaxLength(20)]
        public string LoginName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Required, MaxLength(20)]
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public SexTypes Sex { get; set; }
        /// <summary>
        ///  电子邮件
        /// </summary>
        [MaxLength(30)]
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(11)]
        public string Phone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required, MaxLength(16)]
        public string Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(300)]
        public string HeadImgUrl { get; set; }
    }
}
