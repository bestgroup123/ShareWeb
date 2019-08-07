﻿using System;

namespace Share.Web.User.IServices
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
