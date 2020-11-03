using ConsoleApp1.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IRepository, MemoryRepository>();

            // this is added for using swagger
            services.AddSwaggerGen();

            //services.AddSwaggerGen();
            services.AddSwaggerGen(c => {
                var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var xmlFiles = Directory.GetFiles(folder, "*.xml").ToList();
                xmlFiles.ForEach(x => c.IncludeXmlComments(x));
            });
            //services.AddControllers(option => option.Filters.Add<LogFilterAttribute>());

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<OperationRecord>();


            //services.AddSingleton<IRepository>(provider=> {
            //    var config = Configuration.GetSection("MongoDBConfig").Get<MongoDBConfig>();
            //    var repository = new MongoDBRepository(config);
            //    repository.InitAsync().Wait();
            //    return repository;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // this is added for using swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
