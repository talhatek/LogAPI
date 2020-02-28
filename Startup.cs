using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using LogAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LogAPI
{
    public class Startup
    {
       
        public IConfiguration Configuration{get;}
         public Startup(IConfiguration configuration) =>Configuration=configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<LogAPIContext>
            (opt=>opt.UseSqlServer(Configuration["Data:LogApiConn:ConnectionString"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddJsonOptions(opt=> {
            var resolver =opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            opt.JsonSerializerOptions.PropertyNamingPolicy = null;

            
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddCors();

    
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(opt=>opt.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
        }
    }
}
