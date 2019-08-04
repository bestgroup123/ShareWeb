using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Web.User.Repository
{
    public class DateEntity
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CraeteAt { get; set; }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime LastEditAt { get; set; }
    }
}
