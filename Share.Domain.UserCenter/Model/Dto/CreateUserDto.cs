using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.UserCenter.Model
{
    /// <summary>
    /// 创建用户Dto
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public SexTypes Sex { get; set; }
        /// <summary>
        ///  电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
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
