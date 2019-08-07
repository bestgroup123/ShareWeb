using Share.Domain.UserCenter.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.UserCenter.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="repo"></param>
        /// <returns></returns>
        long Create(UserRepo repo);
    }
}
