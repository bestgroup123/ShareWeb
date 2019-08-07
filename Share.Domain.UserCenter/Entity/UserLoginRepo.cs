using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Share.Domain.UserCenter.Entity
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        [Column("LoginName"), MaxLength(50)]
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("Password"), MaxLength(100)]
        public string Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Column("HeadImgUrl"), MaxLength(300)]
        public string HeadImgUrl { get; set; }
    }
}
