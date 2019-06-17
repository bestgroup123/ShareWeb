using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;

namespace Share.Common
{
    /// <summary>
    /// 消息模型
    /// </summary>
    [Queue("Dev.Client", ExchangeName = "Dev.Client")]
    public class ClientMessage
    {
        /// <summary>
        /// id
        /// </summary>
        public long ClientId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ClientName { get; set; }
    }
}
