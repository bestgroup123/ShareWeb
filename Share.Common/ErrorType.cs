using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Share.Common
{
    public enum ErrorType
    {
        /// <summary>
        /// 登录名已存在
        /// </summary>
        [Description("账户已存在")]
        LoginNameIsExist = 101,
        [Description("手机号码已存在")]
        PhoneIsExist = 102,
        [Description("邮箱已存在")]
        EmailIsExist = 103,
        [Description("账户不存在")]
        LoginNameIsNotExist = 104,
        [Description("面错误")]
        PasswordIsError = 105
    }
}
