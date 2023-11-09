using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection service)
        {
            service.AddDbContext<SqlDbContext>(options => options.UseNpgsql(ConnectionStringConfiguration.ConnectionString));

            service.AddIdentity<User, Role>(opts =>
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
