using Share.Domain.UserCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.UserCenter.IService
{
    public interface IUserService
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool CreateUser(CreateUserDto dto);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool UserLogin(UserLoginDto dto);
    }
}
