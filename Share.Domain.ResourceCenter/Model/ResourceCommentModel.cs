using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ResourceCenter.Model
{
    public class ResourceCommentModel
    {
        /// <summary>
        /// 主键
        /// 数据列类型: bigint(20)
        /// 不可以为空
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 留言
        /// 数据列类型: varchar(200)
        /// 不可以为空
        /// </summary>
        public string Content { get; set; } = string.Empty;
        /// <summary>
        /// 资源id
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        public long ResourceId { get; set; }
        /// <summary>
        /// 创建人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        public long CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        public DateTime CreateAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 编辑人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        public long LastEditBy { get; set; }
        /// <summary>
        /// 编辑时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        public DateTime LastEditAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 姓名
        /// 数据列类型: varchar(100)
        /// 不可以为空
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
