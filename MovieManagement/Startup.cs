using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IO;

namespace MovieManagement
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           string teststri = _configuration.GetConnectionString("ConnectionStrings:MovieDBConnection");
            teststri=_configuration.GetValue<string>("ConnectionStrigs:MovieDBConnection");
            //adddbcontxtpool uses available instance of appdbcontext in the pool rather than creating new
            services.AddDbContextPool<AppDbContext>(options =>
          options.UseSqlServer("Data Source=localhost;database=MoviesDB;Uid=SA;Password=SAadmin123;MultipleActiveResultSets=true"));


             //allow dependancy injection,to make configuration available throught project.added for recaptcha
             services.AddSingleton<IConfiguration>(new ConfigurationBuilder()  
                .SetBasePath(Directory.GetCurrentDirectory())  
                .AddJsonFile($"appsettings.json")  
                .Build());
            //register .netcore identity classes for user and role
            services.AddIdentity<ApplicationUser, IdentityRole>(opt=>{
                                                                opt.Password.RequiredLength = 7;
                                                                opt.Password.RequireDigit = false;
                                                                opt.Password.RequireUppercase = false;
                                                                opt.User.RequireUniqueEmail = true;
                                                                opt.SignIn.RequireConfirmedEmail = true;
                                                                })
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            //apply authorize globally to each controller action except ones decorated allowAnonymous
            services.AddMvc(options=>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
             }).AddXmlSerializerFormatters();
            
            services.AddAuthentication()
            .AddGoogle(options=>{
                          options.ClientId="228400734362-rsn59jqf4shu61kkuhmov79k0q8sldnl.apps.googleusercontent.com";
                          options.ClientSecret="aTpRfhmhkvoTwZFVExgJO34F";
                                });

            services.AddTransient<IMovieRepository, SqlMovieRepository>();//Change Mockrepository to sqlrepository


    

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
            app.UseAuthentication();

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
