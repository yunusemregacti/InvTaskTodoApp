using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InvTask.TodoApp.Business.Abstract;
using InvTask.TodoApp.Business.Concrete;
using InvTask.TodoApp.DataAccess.Abstract;
using InvTask.TodoApp.DataAccess.Concrete.EntityFramework;
using InvTask.TodoApp.DataAccess.Concrete.InMemoryDB;
using InvTask.TodoApp.MvcWebUI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace InvTask.TodoApp.MvcWebUI
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
            //services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("InvTask"));
            //services.AddScoped<ITodoItemService, TodoItemManager>();
            //services.AddScoped<ITodoItemDal, InMemoryTodoDal>();


            services.AddDbContext<EfTodoContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFTodoDB;Trusted_Connection=True;"));
            services.AddScoped<ITodoItemService, TodoItemManager>();
            services.AddScoped<ITodoItemDal, EfTodoDal>();
            services.AddMvc();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(
                        Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                    RequestPath = new PathString("/vendor")
                });

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/ToDo/Error");
            }


            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/notificationHub");

            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ToDo}/{action=Index}/{id?}");
            });
        }
    }
}
