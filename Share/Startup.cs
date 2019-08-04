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
using Share.Domain.UserCenter.Entity;
using Share.Extensions;
using Share.Web.User.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Share.Web.User.IServices;
using Share.Web.User.Services;

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
            services.AddScoped<IUserService, UserService>();

            //mysql
            services.AddDbContext<MysqlDbContext>(options => options.UseMySQL(Configuration["MySql:MySqlConnection"]));
            DbContextOptions<MysqlDbContext> dbOptions = new DbContextOptionsBuilder<MysqlDbContext>().UseMySQL(Configuration["MySql:MySqlConnection"]).Options;
            MysqlDbContext.SetDefaultOptions(dbOptions);
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
