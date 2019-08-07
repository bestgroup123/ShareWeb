using System.Configuration;
using System.IO;
using System.Reflection;
using AutoMapper;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using SchoolPal.Toolkit.Caching;
using SchoolPal.Toolkit.Caching.Redis;
using Share.Domain.ResourceCenter.Entity;
using Share.Domain.ResourceCenter.IService;
using Share.Domain.ResourceCenter.Service;
using Share.Domain.UserCenter.Entity;
using Share.Domain.UserCenter.IService;
using Share.Domain.UserCenter.Service;
using Share.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using MongoDB.Driver;
using Share.Domain.ErrorLogCenter.Entity;

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

            //userdb context
            services.AddDbContext<UserDBContext>(o => o.UseMySQL(Configuration.GetConnectionString("UserDBConnection")));
            services.AddTransient<IUserService, UserService>();

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

            //mongodb
            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            });
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
