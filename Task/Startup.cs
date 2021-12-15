using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Entities;
using Task.Models;

namespace Task
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
            services.AddControllersWithViews();
            services.AddDbContext<TaskDbContext>();

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<User, UserModel>()
                   .ForMember(c => c.Email, o => o.MapFrom(m => m.Email))
                   .ForMember(c => c.ID, o => o.MapFrom(m => m.ID))
                   .ForMember(c => c.password, o => o.MapFrom(m => m.password))
                   .ForMember(c => c.Messages, opt => opt.Ignore())/*MapFrom(m => m.Messages))*/;

                cfg.CreateMap<UserModel, User>()
                    .ForMember(c => c.ID, opt => opt.Ignore())
                    .ForMember(c => c.Messages, opt => opt.Ignore())
                    .ForMember(c => c.Email, opt => opt.MapFrom(m => m.Email))
                    .ForMember(c => c.password, opt => opt.MapFrom(m => m.password));

                cfg.CreateMap<Message, MessagesModel>()
                   .ForMember(c => c.MessageBody, o => o.MapFrom(m => m.MessageBody))
                   .ForMember(c => c.Id, o => o.MapFrom(m => m.Id))
                   .ForMember(c => c.UserId, o => o.MapFrom(m => m.userId));

                cfg.CreateMap<MessagesModel, Message>()
                    .ForMember(c => c.Id, opt => opt.Ignore())
                    .ForMember(c => c.MessageBody, opt => opt.MapFrom(m => m.MessageBody))
                    .ForMember(c => c.userId, opt => opt.MapFrom(m => m.UserId));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
