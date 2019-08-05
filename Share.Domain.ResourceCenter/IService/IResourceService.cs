using Share.Domain.ResourceCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ResourceCenter.IService
{
    public interface IResourceService
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        long Create(ResourceModel model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Edit(ResourceModel model);
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        ResourceModel GetResource(long resourceId);
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <returns></returns>
        List<ResourceModel> GetResourceList();
        /// <summary>
        /// 获取资源评论
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        List<ResourceCommentModel> GetResourceComments(long resourceId);
    }
}
