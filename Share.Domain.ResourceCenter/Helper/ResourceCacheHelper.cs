using SchoolPal.Toolkit.Caching;
using Share.Domain.ResourceCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ResourceCenter.Helper
{
    public class ResourceCacheHelper
    {
        private ICache _cache;
        private readonly int expireHour = 12;
        public ResourceCacheHelper(ICache cache)
        {
            _cache = cache;
        }
        /// <summary>
        /// 获取缓存的资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResourceModel GetResourceCache(long id)
        {
            var key = GetResourceCacheKey(id);
            ResourceModel result = null;
            var content = _cache.Get<ResourceModel>(key);
            if (content != null)
            {
                result = content;
            }
            return result;
        }

        /// <summary>
        /// 刷新资源
        /// </summary>
        /// <param name="model"></param>
        public void RefreshResource(ResourceModel model)
        {
            var key = GetResourceCacheKey(model.Id);
            _cache.Set(key, model, DateTime.Now.AddHours(12));
        }

        /// <summary>
        /// 清除资源
        /// </summary>
        public void ClearResource(long id)
        {
            var key = GetResourceCacheKey(id);
            _cache.Remove(key);
        }
        /// <summary>
        /// 获取缓存key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetResourceCacheKey(long id)
        {
            return $"Share.Domain.Resource_Id_{id}";
        }
    }
}
