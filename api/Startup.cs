using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApp.Infra;

namespace TodoApp.Api
{
    public class Startup
    {
        private string ConnectionString = "Server=localhost,1433;Initial Catalog=TodoApp;Persist Security Info=False;User ID=sa;Password=Password1;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().ConfigureApiBehaviorOptions(option => option.);
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(ConnectionString)
            );

            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy("DevCORS", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin() // Podemos utilizar o AllowOrigins com um array de whitelist
                        .WithExposedHeaders("X-Total-Count", "Link", "Authorization", "RefreshToken")
                        .AllowCredentials();
                });
                options.AddPolicy("ProdCORS", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin() // Podemos utilizar o AllowOrigins com um array de whitelist
                        .WithExposedHeaders("X-Total-Count", "Link", "Authorization", "RefreshToken")
                        .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("DevCORS");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("ProdCORS");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
