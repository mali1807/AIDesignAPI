using Autofac.Core;
using Core.Configurations;
using Core.IoC;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ServiceRegistrations
{
    public class DataAccessModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<SqlDbContext>(options => options.UseNpgsql(OptionsConfiguration.ConnectionString.PostgreSQL));

            serviceCollection.AddIdentity<User, Role>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 6;
                opts.User.RequireUniqueEmail = true;
            }
           ).AddEntityFrameworkStores<SqlDbContext>().AddDefaultTokenProviders();
        }
    }
}
