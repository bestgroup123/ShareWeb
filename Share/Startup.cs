using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using SchoolPal.Toolkit.Caching;
using SchoolPal.Toolkit.Caching.Redis;
using Share.Domain.ResourceCenter.Entity;
using Share.Domain.ResourceCenter.IService;
using Share.Domain.ResourceCenter.Service;
using Share.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace Share
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ShareApi", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Share.XML"));
                c.DescribeAllEnumsAsStrings();
            });
            //mysql
            //resource_db
            services.AddDbContext<MysqlDb_Resource>(options => options.UseMySQL(Configuration["MySql:Connection_Resource"]));
            DbContextOptions<MysqlDb_Resource> dbOptions = new DbContextOptionsBuilder<MysqlDb_Resource>().UseMySQL(Configuration["MySql:Connection_Resource"]).Options;
            MysqlDb_Resource.SetDefaultOptions(dbOptions);
            //redis
            services.AddSingleton<ICache>(serviceProvider => new RedisCache(Configuration["Redis:Connection"]));
            //automapper
            services.AddAutoMapper();
            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyOrigin();
                });
            });
            //rabbitmq
            services.AddSingleton(RabbitHutch.CreateBus(Configuration["RabbitMQ:Dev"]));

            //add service
            services.AddTransient<IResourceService, ResourceService>();
        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            #region swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShareApi V1");
            });

            #endregion
            app.UseCors("AllowAllOrigin");
            app.UseHttpsRedirection();
            app.UseMvc();

            //easynetq
            app.UseSubscribe("ClientMessageService", Assembly.GetExecutingAssembly());
        }
    }
}
