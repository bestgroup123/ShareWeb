﻿using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Share.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class AppBuilderExtension
    {
        /// <summary>
        /// Subscriber快速注册
        /// </summary>
        /// <param name="appBuilder"></param>
        /// <param name="subscriptionIdPrefix"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSubscribe(this IApplicationBuilder appBuilder, string subscriptionIdPrefix, Assembly assembly)
        {
            var services = appBuilder.ApplicationServices.CreateScope().ServiceProvider;

            var lifeTime = services.GetService<IApplicationLifetime>();
            var bus = services.GetService<IBus>();
            lifeTime.ApplicationStarted.Register(() =>
            {
                var subscriber = new AutoSubscriber(bus, subscriptionIdPrefix);
                subscriber.Subscribe(assembly);
                ; subscriber.SubscribeAsync(assembly);
            });
            lifeTime.ApplicationStopped.Register(() => bus.Dispose());
            return appBuilder;
        }
    }
}
