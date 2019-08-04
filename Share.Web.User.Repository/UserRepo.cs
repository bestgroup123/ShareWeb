using Share.Web.User.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Share.Web.User.Repository
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("user")]
    public class UserRepo: DateEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 登录用户
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public SexTypes Sex { get; set; }
        /// <summary>
        ///  电子右键
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistrationTime { get; set; }
        /// <summary>
        /// 用户登录Id
        /// </summary>
        public long UserLoginId { get; set; }
    }
}
