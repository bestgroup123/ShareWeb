using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Domain.UserCenter.Entity
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }

        /// <summary>
        /// 用户登录表
        /// </summary>
        public DbSet<UserLoginRepo> UserLoginRepos { get; set; }

        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<UserRepo> UserRepos { get; set; }
    }

    public static class Extend
    {
        public static IList<T> SqlQuery<T>(this DatabaseFacade database, string sql, params object[] parameters)
                 where T : new()
        {
            //注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose否则bContext后续不能再进行使用了，会抛异常
            var conn = database.GetDbConnection();
            try
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.AddRange(parameters);

                    var rtnList = new List<T>();

                    //如果返回类型不是类 类型，则只进行首行首列的查询【string is class】
                    if (!typeof(T).IsClass)
                    {
                        var result = command.ExecuteScalar();
                        rtnList.Add((T)result);
                        return rtnList;
                    }

                    var propts = typeof(T).GetProperties();
                    T model;
                    object val;
                    //查询结果的列中不存在模型字段
                    List<string> nonExistentfields = new List<string>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new T();
                            foreach (var p in propts)
                            {
                                if (nonExistentfields.Any(o => o == p.Name))
                                {
                                    continue;
                                }
                                try
                                {
                                    val = reader[p.Name];
                                    if (val == DBNull.Value)
                                    {
                                        p.SetValue(model, null);
                                    }
                                    else
                                    {
                                        //处理bit 转 bool 的问题
                                        if (reader.GetDataTypeName(reader.GetOrdinal(p.Name)).ToLower() == "bit")
                                        {
                                            p.SetValue(model, val.GetHashCode() == 1);
                                        }
                                        else
                                        {
                                            p.SetValue(model, val);
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (ex is IndexOutOfRangeException)
                                    {
                                        nonExistentfields.Add(p.Name);
                                        continue;
                                    }
                                    throw ex;
                                }
                            }
                            rtnList.Add(model);
                        }
                    }
                    return rtnList;
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
