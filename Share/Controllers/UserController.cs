using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Share.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //新建用户
        public bool CreateUser()
        {
            return true;
        }
        //登录
        public bool UserLogin()
        {
            return true;
        }
        //编辑用户
        //找回密码
        
    }
}