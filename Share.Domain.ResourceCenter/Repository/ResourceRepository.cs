using Microsoft.EntityFrameworkCore;
using Share.Domain.ResourceCenter.Entity;
using Share.Domain.ResourceCenter.IRepository;
using Share.Domain.ResourceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Share.Domain.ResourceCenter.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        protected MysqlDb_Resource _db;

        public ResourceRepository(MysqlDb_Resource db)
        {
            _db = db;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public long Create(ResourceRepo model, ResourceContentRepo resourceContent)
        {
            var tran = _db.Database.BeginTransaction();
            try
            {
                _db.ResourceRepos.Add(model);
                _db.SaveChanges();
                resourceContent.ResourceId = model.Id;
                _db.ResourceContentRepos.Add(resourceContent);
                _db.SaveChanges();
                tran.Commit();
                return model.Id;
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw e;
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="resourceContent"></param>
        /// <returns></returns>
        public bool Edit(ResourceRepo model, ResourceContentRepo resourceContent)
        {
            var entity = _db.ResourceRepos.FirstOrDefault(p => p.Id == model.Id && !p.Delete);
            if (entity != null)
            {
                entity.Title = model.Title;
                entity.LastEditBy = model.LastEditBy;
                entity.LastEditAt = model.LastEditAt;
                entity.Version = model.Version;
                var content = _db.ResourceContentRepos.FirstOrDefault(p => p.ResourceId == entity.Id);
                if (content != null)
                {
                    content.Content = resourceContent.Content;
                }
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        public ResourceRepo GetResource(long resourceId)
        {
            return _db.ResourceRepos.FirstOrDefault(p => p.Id == resourceId && !p.Delete);
        }
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <returns></returns>
        public List<ResourceRepo> GetResourceList()
        {
            return _db.ResourceRepos.Where(p => !p.Delete).ToList();
        }
        /// <summary>
        /// 获取资源内容
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        public ResourceContentRepo GetResourceContent(long resourceId)
        {
            return _db.ResourceContentRepos.FirstOrDefault(p => p.ResourceId == resourceId);
        }
        /// <summary>
        /// 获取资源评论
        /// </summary>
        /// <param name="resourceId">资源id</param>
        /// <returns></returns>
        public List<ResourceCommentRepo> GetResourceComments(long resourceId)
        {
            return _db.ResourceCommentRepos.Where(p => p.ResourceId == resourceId).ToList();
        }
    }
}
