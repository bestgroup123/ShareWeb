using Share.Web.User.IServices;
using Share.Web.User.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Web.User.Services
{
    public class UserService : IUserService
    {
        private UserDBContext db;
        public UserService(UserDBContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool CreateUser(CreateUserDto dto)
        {
            var tran = db.Database.BeginTransaction();
            try
            {
                //校验用户名是否存在
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
                //创建登录信息
                var userLogin = new UserLoginRepo
                {
                    LoginName = dto.LoginName,
                    Password = dto.Password,//TODO:MD5加密
                    HeadImgUrl = dto.HeadImgUrl,
                    CraeteAt = DateTime.Now,
                    LastEditAt = DateTime.Now
                };
                db.UserLoginRepos.Add(userLogin);
                //创建用户
                db.UserRepos.Add(new UserRepo
                {
                    UserName = dto.UserName,
                    Sex = dto.Sex,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    IsDelete = false,
                    RegistrationTime = DateTime.Now,
                    UserLoginId = userLogin.Id,
                    CraeteAt = DateTime.Now,
                });
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }
    }
}
