using Share.Domain.UserCenter.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.UserCenter.IRepository
{
    public interface IUserLoginRepository
    {
        /// <summary>
        /// 创建用户账户
        /// </summary>
        /// <param name="db"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        long Create(UserDBContext db, UserLoginRepo repo);
        /// <summary>
        /// 获取账户
        /// </summary>
        /// <param name="db"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        UserLoginRepo Get(UserDBContext db, string loginName);
    }
}
