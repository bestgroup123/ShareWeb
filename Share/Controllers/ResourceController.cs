using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.Common;
using Share.Domain.ResourceCenter.IService;
using Share.Domain.ResourceCenter.Model;
using Share.Model;

namespace Share.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IResourceService _resourceService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="resourceService"></param>
        public ResourceController(IBus bus, IResourceService resourceService)
        {
            _bus = bus;
            _resourceService = resourceService;
        }
        /// <summary>
        /// 新增资源
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public long Create(CreateResourceDto dto)
        {
            var currentUserId = 1;
            if (string.IsNullOrWhiteSpace(dto.Title) || string.IsNullOrWhiteSpace(dto.Content))
            {
                throw new Exception("格式不正确");
            }
            var model = new ResourceModel
            {
                Title = dto.Title,
                Content = dto.Content,
                Version = 1,
                CreateBy = currentUserId,
                LastEditBy = currentUserId,
                CreateAt = DateTime.Now,
                LastEditAt = DateTime.Now
            };
            var result = _resourceService.Create(model);
            return result;
            ////todo 业务逻辑代码 新增一条资源
            ////...
            ////广播用户
            //ClientMessage message = new ClientMessage
            //{
            //    ClientId = dto.Id,
            //    ClientName = dto.Name
            //};
            //await _bus.PublishAsync(message);
            //return "Create Success! Notice To AllUser!";
        }
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDetail")]
        public ResourceDetailDto GetDetail(long id)
        {
            var result = _resourceService.GetResource(id);
            return Mapper.Map<ResourceDetailDto>(result);
        }
    }
}