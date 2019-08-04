using Share.Web.User.IServices;
using Share.Web.User.Repository;
using System;
using System.Collections.Generic;
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

        public bool CreateUser()
        {
            var tran = db.Database.BeginTransaction();
            try
            {

                //创建登录信息
                //创建用户
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
