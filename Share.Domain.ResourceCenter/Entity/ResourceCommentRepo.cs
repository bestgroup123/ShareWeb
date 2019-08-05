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
	/// 资源评论留言表
	/// </summary>
	[Table("resource_comment")]
	public partial class ResourceCommentRepo
	{
        /// <summary>
        /// 主键
        /// 数据列类型: bigint(20)
        /// 不可以为空
        /// </summary>
        [Column("id"), Key]
        public long Id { get; set; }
        /// <summary>
        /// 留言
        /// 数据列类型: varchar(200)
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
        /// <summary>
        /// 创建人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        [Column("create_by")]
        public long CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 编辑人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        [Column("lastedit_by")]
        public long LastEditBy { get; set; }
        /// <summary>
        /// 编辑时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        [Column("lastedit_at")]
        public DateTime LastEditAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 姓名
        /// 数据列类型: varchar(100)
        /// 不可以为空
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = string.Empty;
	}
}
