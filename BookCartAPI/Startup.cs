using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using BookCartAPI.Helper;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace BookCartAPI
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            _config = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<BookCartDBContext>(opt => opt.UseInMemoryDatabase(databaseName: _config.GetConnectionString("DataBase")));
           
            services.AddMvc();

            services.AddControllers();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;              
            });
            services.ServiceRegistry();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(options =>
            {


                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BookCart",
                    Description = "An ASP.NET Core Web API for managing Books",

                });


                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                    {
                        new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference
                          {
                         Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                          },
                            Scheme = "oauth2",
                            Name = "Bearer",
                                In = ParameterLocation.Header,

                        },
                            new List<string>()
                    }
                 });

            });

            
           
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
          
            var context = serviceProvider.GetService<BookCartDBContext>();
            DataSeeder.Initialize(context);

          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Cart"); });

            app.UseHttpsRedirection();


   

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
