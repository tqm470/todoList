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
using TodoApp.Domain.Repository;
using TodoApp.Infra;
using TodoApp.Infra.Repository;

namespace TodoApp.Api
{
    public class Startup
    {
        private string ConnectionString = "Server=localhost,1433;Initial Catalog=TodoApp;Persist Security Info=False;User ID=sa;Password=Password1;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc( options => options.EnableEndpointRouting = false);
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(ConnectionString)
            );
            services.AddScoped<IItemRepository, ItemRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
