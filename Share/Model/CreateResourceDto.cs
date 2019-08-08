using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateResourceDto
    {
        /// <summary>
        /// 标题
        /// 数据列类型: varchar(200)
        /// 不可以为空
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// 内容详情
        /// </summary>
        public string Content { get; set; }
    }

    public class ResourceDetailDto
    {
        /// <summary>
        /// 主键
        /// 数据列类型: bigint(20)
        /// 不可以为空
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 标题
        /// 数据列类型: varchar(200)
        /// 不可以为空
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// 版本号
        /// 数据列类型: int(11)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// 创建时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        public DateTime CreateAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 创建人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        public long CreateBy { get; set; }
        /// <summary>
        /// 上次修改时间
        /// 数据列类型: datetime
        /// 默认值: CURRENT_TIMESTAMP
        /// 不可以为空
        /// </summary>
        public DateTime LastEditAt { get; set; } = DateTime.Now;
        /// <summary>
        /// 上次修改人
        /// 数据列类型: bigint(20)
        /// 默认值: 0
        /// 不可以为空
        /// </summary>
        public long LastEditBy { get; set; }
        /// <summary>
        /// 内容详情
        /// </summary>
        public string Content { get; set; }
    }
}
