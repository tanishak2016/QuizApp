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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Quiz_App
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



            //services.AddMvcCore(option =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    option.Filters.Add(new AuthorizeFilter(policy));
            //}).AddXmlSerializerFormatters();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option=>
                {
                    option.LoginPath = "/Account/normalAdminLogin";
                    option.Cookie.Name = "normaAdminCookies";
                });


            services.AddMvc(options=>options.EnableEndpointRouting=false);
           
            services.AddMvcCore();
            services.AddControllersWithViews().AddNewtonsoftJson();
           // services.AddRazorPages();





            services.AddControllers()
            .AddJsonOptions(options =>
               options.JsonSerializerOptions.PropertyNamingPolicy = null);






            //services.AddControllers(options =>
            //{
            //    var jsonInputFormatter = options.InputFormatters
            //        .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
            //        .SingleOrDefault();
            //    jsonInputFormatter.SupportedMediaTypes.Add("application/json");
            //}

            //);







        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

           // app.UseAuthentication();
            
            
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
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            
            
           

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                  name: "Main",
                  areaName: "Main",
                 pattern: "Main/{controller=NoticeBoard}/{action=NoticeBoardSave}");
                //pattern: "Main/{controller=Contributor}/{action=saveContributor}");



                endpoints.MapAreaControllerRoute(
                  name: "Admin",
                  areaName: "Admin",
                  pattern: "Admin/{controller=Account}/{action=SuperAdmin}");               

                endpoints.MapControllerRoute(
                    name: "default",                    
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
