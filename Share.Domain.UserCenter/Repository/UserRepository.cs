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

        /// <summary>
        /// 创建校验
        /// </summary>
        /// <param name="db"></param>
        /// <param name="dto"></param>
        public void CreateValidate(UserDBContext db, CreateUserDto dto)
        {
            if (db.UserLoginRepos.Any(o => o.LoginName == dto.LoginName))
            {
                throw new Exception("用户名已存在");
            }
            //校验手机号是否存在
            if (string.IsNullOrWhiteSpace(dto.Phone) && db.UserRepos.Any(o => o.Phone == dto.Phone))
            {
                throw new Exception("手机号已存在");
            }
            //校验邮箱是否存在
            if (string.IsNullOrWhiteSpace(dto.Email) && db.UserRepos.Any(o => o.Email == dto.Email))
            {
                throw new Exception("邮箱已存在");
            }
        }
    }
}
