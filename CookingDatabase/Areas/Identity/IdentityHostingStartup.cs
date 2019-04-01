using System;
using CookingDatabase.Areas.Identity.Data;
using CookingDatabase.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CookingDatabase.Areas.Identity.IdentityHostingStartup))]
namespace CookingDatabase.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<IdentityContext>(options =>
            //        options.UseSqlite(context.Configuration.GetConnectionString("sqlcon")));

            //    services.AddIdentity<Users,Roles>().AddDefaultUI()
            //        .AddEntityFrameworkStores<IdentityContext>();
            //});
        }
    }
}