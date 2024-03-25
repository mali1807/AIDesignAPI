using Autofac.Core;
using Core.Configurations;
using Core.Identity.Entities;
using Core.IoC;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ServiceRegistrations
{
    public class DataAccessModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<SqlDbContext>(options =>
                options.UseNpgsql(OptionsConfiguration.ConnectionString.PostgreSQL));

            serviceCollection.AddIdentity<User, Role>(options =>
            {
                options.User.AllowedUserNameCharacters = String.Empty;
            })
                .AddRoleManager<RoleManager<Role>>()
                .AddEntityFrameworkStores<SqlDbContext>().AddDefaultTokenProviders();

        }
    }
}
