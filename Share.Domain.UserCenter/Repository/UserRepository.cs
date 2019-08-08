using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolPal.Toolkit.Caching;
using Share.Domain.UserCenter.Entity;
using Share.Domain.UserCenter.IRepository;
using Share.Domain.UserCenter.Model;

namespace Share.Domain.UserCenter.Repository
{
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="db"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        public long Create(UserDBContext db,UserRepo repo)
        {
            db.UserRepos.Add(repo);
            db.SaveChanges();
            return repo.Id;
        }
    }
}
