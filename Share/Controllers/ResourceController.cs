using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.Common;
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
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bus"></param>
        public ResourceController(IBus bus)
        {
            _bus = bus;
        }
        /// <summary>
        /// 新增资源
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<string> Create(CreateResourceDto dto)
        {
            //todo 业务逻辑代码 新增一条资源
            //...
            //广播用户
            ClientMessage message = new ClientMessage
            {
                ClientId = dto.Id,
                ClientName = dto.Name
            };
            await _bus.PublishAsync(message);
            return "Create Success! Notice To AllUser!";
        }
    }
}