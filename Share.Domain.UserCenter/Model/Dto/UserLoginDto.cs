using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.UserCenter.Model
{
    public class UserLoginDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
