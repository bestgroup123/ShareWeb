using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Share.Web.User.IServices
{
    public enum SexTypes
    {
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]//Male 
        Male = 1,
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]//Female
        Female = 2,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]//Other
        Other = 3
    }
}
