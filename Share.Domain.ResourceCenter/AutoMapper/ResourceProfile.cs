using AutoMapper;
using Share.Domain.ResourceCenter.Entity;
using Share.Domain.ResourceCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ResourceCenter.AutoMapper
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<ResourceModel, ResourceRepo>();
        }
    }
}
