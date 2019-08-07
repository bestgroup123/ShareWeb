using System;
using System.Collections.Generic;
using System.Text;
using SchoolPal.Toolkit.Caching;
using Share.Domain.UserCenter.Entity;
using Share.Domain.UserCenter.IRepository;

namespace Share.Domain.UserCenter.Repository
{
    public class UserRepository: IUserRepository
    {
        private UserDBContext db;
        public UserRepository(UserDBContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="repo"></param>
        /// <returns></returns>
        public long Create(UserRepo repo)
        {
            db.UserRepos.Add(repo);
            db.SaveChanges();
            return repo.Id;
        }
    }
}
