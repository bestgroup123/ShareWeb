﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.Model;
using Share.Web.User.IServices;
using Share.Web.User.Repository;

namespace Share.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region 构造函数
        private IUserService _userService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion


        /// <summary>
        /// 新建用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateUser(CreateUserRequestModel model)
        {
            //参数校验
            model.Validate();
            if (!Enum.IsDefined(typeof(SexTypes), model.Sex))
            {
                throw new Exception("error sex");
            }
            var dto = new CreateUserDto
            {
                LoginName = model.LoginName,
                UserName = model.UserName,
                Sex = model.Sex,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password,
                HeadImgUrl = model.HeadImgUrl
            };
            var result = _userService.CreateUser(dto);
            return result;
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