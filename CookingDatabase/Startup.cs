using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CookingDatabase.Models;
using CookingDatabase.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace CookingDatabase
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<CookingDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("sqlcon")));
            services.AddDbContext<IdentityContext>(opt => opt.UseSqlite(configuration.GetConnectionString("sqlcon")));
            // services.AddIdentity<CookingUser,CookingRole>().AddDefaultUI().AddEntityFrameworkStores<IdentityContext>();
            services.AddDefaultIdentity<CookingUser>()
         .AddRoles<CookingRole>()
         .AddEntityFrameworkStores<IdentityContext>()
         .AddUserManager<UserManager<CookingUser>>()
         .AddRoleManager<RoleManager<CookingRole>>()
         .AddDefaultTokenProviders();

            //  services.Add(new ServiceDescriptor(typeof(CookingRole), new CookingRole, ServiceLifetime.Scoped));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            
            app.UseMvc(cfg =>
            {
                cfg.MapRoute(name: "default",
                    template: "{Controller=Home}/{Action=Index}/{Id?}");
            });
            app.UseWelcomePage();
        }
    }
}
