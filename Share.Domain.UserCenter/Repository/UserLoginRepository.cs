using Share.Domain.UserCenter.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Domain.UserCenter.Repository
{
    public class UserLoginRepository
    {
        private UserDBContext db;
        public UserLoginRepository(UserDBContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// 创建用户账户
        /// </summary>
        /// <param name="repo"></param>
        /// <returns></returns>
        public long Create(UserLoginRepo repo)
        {
            db.UserLoginRepos.Add(repo);
            db.SaveChanges();
            return repo.Id;
        }

        /// <summary>
        /// 获取账户
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public UserLoginRepo Get(string loginName)
        {
            return db.UserLoginRepos.Where(o => o.LoginName == loginName).FirstOrDefault();
        }
    }
}
