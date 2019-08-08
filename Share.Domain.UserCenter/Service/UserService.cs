using SchoolPal.Toolkit.Caching;
using SchoolPal.Toolkit.Caching.Redis;
using Share.Common;
using Share.Domain.UserCenter.Entity;
using Share.Domain.UserCenter.IRepository;
using Share.Domain.UserCenter.IService;
using Share.Domain.UserCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Domain.UserCenter.Service
{
    public class UserService : IUserService
    {
        private UserDBContext _db;
        private IUserRepository _userRepository;
        private IUserLoginRepository _userLoginRepository;
        private ICache _cache;
        private RedisCache _redis;

        public UserService(IUserRepository userRepository, IUserLoginRepository userLoginRepository,ICache cache, RedisCache redis, UserDBContext db)
        {
            _userRepository = userRepository;
            _userLoginRepository = userLoginRepository;
            _cache = cache;
            _redis = redis;
            this._db = db;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool CreateUser(CreateUserDto dto)
        {
            var tran = _db.Database.BeginTransaction();
            try
            {
                //校验
                _userRepository.CreateValidate(_db, dto);
                //创建登录信息
                var userLogin = new UserLoginRepo
                {
                    LoginName = dto.LoginName,
                    Password = dto.Password.MD5Encrypt(),
                    HeadImgUrl = dto.HeadImgUrl,
                    CraeteAt = DateTime.Now,
                    LastEditAt = DateTime.Now
                };
                _userLoginRepository.Create(_db,userLogin);
                //创建用户
                _userRepository.Create(_db, new UserRepo
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
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public bool UserLogin(UserLoginDto dto)
        {
            //校验账户是否存在
            var loginUser = _userLoginRepository.Get(_db, dto.LoginName);
            if (loginUser == null)
            {
                throw new Exception("账户不存在");
            }
            if (loginUser.Password != dto.Password.MD5Encrypt())
            {
                throw new Exception("密码错误");
            }
            //写入redis
            var expiry = DateTime.Now.AddHours(1);
            _redis.Set("userloginid", loginUser.Id, expiry);
            return true;
        }
    }
}
