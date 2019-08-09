using Share.Domain.UserCenter.Entity;
using Share.Domain.UserCenter.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Domain.UserCenter.Repository
{
    public class UserLoginRepository: IUserLoginRepository
    {
        /// <summary>
        /// 创建用户账户
        /// </summary>
        /// <param name="db"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        public long Create(UserDBContext db,UserLoginRepo repo)
        {
            db.UserLoginRepos.Add(repo);
            db.SaveChanges();
            return repo.Id;
        }

        /// <summary>
        /// 获取账户
        /// </summary>
        /// <param name="db"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public UserLoginRepo Get(UserDBContext db,string loginName)
        {
            return db.UserLoginRepos.Where(o => o.LoginName == loginName).FirstOrDefault();
        }
    }
}
