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
    /// 资源
    /// </summary>
    [Table("resource")]
    public partial class ResourceRepo
    {
        /// <summary>
        /// 主键
        /// 数据列类型: bigint(20)
        /// 不可以为空
        /// </summary>
        [Column("id"), Key]
        public long Id { get; set; }
        /// <summary>
        /// 标题
        /// 数据列类型: varchar(200)
        /// 不可以为空
        /// </summary>
        [Column("title")]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// 是否删除
        /// 数据列类型: tinyint(1)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        [Column("delete")]
        public bool Delete { get; set; }
        /// <summary>
        /// 版本号
        /// 数据列类型: int(11)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        [Column("version")]
        public int Version { get; set; }
        /// <summary>
        /// 创建时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        [Column("create_at")]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        [Column("create_by")]
        public long CreateBy { get; set; }
        /// <summary>
        /// 上次修改时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        [Column("lastedit_at")]
        public DateTime LastEditAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 上次修改人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        [Column("lastedit_by")]
        public long LastEditBy { get; set; }
    }
}
