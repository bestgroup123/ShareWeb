using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Share.Model
{
    public class UserLoginRequestModel
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required, MaxLength(20)]
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required, MaxLength(16)]
        public string Password { get; set; }
    }
}
