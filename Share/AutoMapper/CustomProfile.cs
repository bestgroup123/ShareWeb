using AutoMapper;
using Share.Domain.ResourceCenter.Model;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share.AutoMapper
{
    /// <summary>
    ///  创建关系映射
    /// </summary>
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomProfile()
        {
            CreateMap<ResourceModel, ResourceDetailDto>();
        }
    }
}
