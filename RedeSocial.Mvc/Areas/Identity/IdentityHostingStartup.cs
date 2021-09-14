using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedeSocial.Mvc.Areas.Identity.Data;
using RedeSocial.Mvc.Data;

[assembly: HostingStartup(typeof(RedeSocial.Mvc.Areas.Identity.IdentityHostingStartup))]
namespace RedeSocial.Mvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserAccountsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserAccountsContextConnection")));

                services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<UserAccountsContext>();
            });
        }
    }
}