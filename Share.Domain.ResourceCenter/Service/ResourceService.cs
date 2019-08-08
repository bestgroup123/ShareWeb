using AutoMapper;
using SchoolPal.Toolkit.Caching;
using Share.Domain.ResourceCenter.Entity;
using Share.Domain.ResourceCenter.Helper;
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
        private readonly ResourceCacheHelper _resourceCacheHelper;
        public ResourceService(IResourceRepository resourceRepository, ICache cache)
        {
            _resourceRepository = resourceRepository;
            _cache = cache;
            _resourceCacheHelper = new ResourceCacheHelper(_cache);
        }
        #endregion
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public long Create(ResourceModel model)
        {
            var entity = Mapper.Map<ResourceRepo>(model);
            entity.Version = 1;
            var content = new ResourceContentRepo() { Content = model.Content };
            var resultId = _resourceRepository.Create(entity, content);
            return resultId;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Edit(ResourceModel model)
        {
            var entity = Mapper.Map<ResourceRepo>(model);
            entity.Version = entity.Version + 1;
            var content = new ResourceContentRepo() { ResourceId = model.Id, Content = model.Content };
            var result = _resourceRepository.Edit(entity, content);
            if (result)
            {
                _resourceCacheHelper.RefreshResource(Mapper.Map<ResourceModel>(entity));
            }
            return result;
        }
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        public ResourceModel GetResource(long resourceId)
        {
            //从缓存拿取
            var result = _resourceCacheHelper.GetResourceCache(resourceId);
            if (result == null)
            {
                result = Mapper.Map<ResourceModel>(_resourceRepository.GetResource(resourceId));
                result.Content = _resourceRepository.GetResourceContent(resourceId)?.Content;
                //刷新缓存
                _resourceCacheHelper.RefreshResource(result);
            }
            return result;
        }
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <returns></returns>
        public List<ResourceModel> GetResourceList()
        {
            var r = _resourceRepository.GetResourceList();
            return Mapper.Map<List<ResourceModel>>(r);
        }
        /// <summary>
        /// 获取资源评论
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        public List<ResourceCommentModel> GetResourceComments(long resourceId)
        {
            var r = _resourceRepository.GetResourceComments(resourceId);
            return Mapper.Map<List<ResourceCommentModel>>(r);
        }
    }
}
