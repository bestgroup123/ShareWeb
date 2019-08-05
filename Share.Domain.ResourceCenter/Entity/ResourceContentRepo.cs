/*******************************************************************/
/* 自动生成代码，请勿手动调整。
/*******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Share.Domain.ResourceCenter.Entity
{
    /// <summary>
    /// 资源详情
    /// </summary>
    [Table("resource_content")]
    public partial class ResourceContentRepo
    {
        /// <summary>
        /// 主键id
        /// 数据列类型: bigint(20)
        /// 不可以为空
        /// </summary>
        [Key, Column("id")]
        public long Id { get; set; }
        /// <summary>
        /// 内容
        /// 数据列类型: varchar(2000)
        /// 不可以为空
        /// </summary>
        [Column("content")]
        public string Content { get; set; } = string.Empty;
        /// <summary>
        /// 资源id
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        [Column("resource_id")]
        public long ResourceId { get; set; }
    }
}
