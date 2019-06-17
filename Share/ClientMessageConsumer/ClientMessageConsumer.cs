using EasyNetQ.AutoSubscribe;
using Share.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Share.ClientMessageConsumer
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientMessageConsumer : IConsumeAsync<ClientMessage>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [AutoSubscriberConsumer(SubscriptionId = "ClientMessageService.Share")]
        public Task ConsumeAsync(ClientMessage message)
        {
            //获取所有用户，发送邮件逻辑代码

            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine("Consume one message from RabbitMQ : {0}, I will send one email to client.", message.ClientName);
            Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
