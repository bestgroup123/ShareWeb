using SchoolPal.Toolkit.Caching;
using Share.Domain.ResourceCenter.IRepository;
using Share.Domain.ResourceCenter.IService;
using Share.Domain.ResourceCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ResourceCenter.Service
{
    public class ResourceService : IResourceService
    {
        #region 注入
        private readonly IResourceRepository _resourceRepository;
        private readonly ICache _cache;
        public ResourceService(IResourceRepository resourceRepository, ICache cache)
        {
            _resourceRepository = resourceRepository;
            _cache = cache;
        }
        #endregion
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public long Create(ResourceModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Edit(ResourceModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        public ResourceModel GetResource(long resourceId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <returns></returns>
        public List<ResourceModel> GetResourceList()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取资源评论
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        public List<ResourceCommentModel> GetResourceComments(long resourceId)
        {
            throw new NotImplementedException();
        }
    }
}
