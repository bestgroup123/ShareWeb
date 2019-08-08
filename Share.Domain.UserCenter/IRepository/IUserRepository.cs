using Share.Domain.UserCenter.Entity;
using Share.Domain.UserCenter.Model;
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
        /// <param name="db"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        long Create(UserDBContext db, UserRepo repo);
    }
}
