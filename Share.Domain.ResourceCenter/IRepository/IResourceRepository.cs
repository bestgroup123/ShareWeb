using Share.Domain.ResourceCenter.Entity;
using Share.Domain.ResourceCenter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ResourceCenter.IRepository
{
    public interface IResourceRepository
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        long Create(ResourceRepo model);
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        bool Edit(ResourceRepo model);
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        ResourceRepo GetResource(long resourceId);
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <returns></returns>
        List<ResourceRepo> GetResourceList();
        /// <summary>
        /// 获取资源内容
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        ResourceContentRepo GetResourceContent(long resourceId);
        /// <summary>
        /// 获取资源评论
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        List<ResourceCommentRepo> GetResourceComments(long resourceId);
    }
}
