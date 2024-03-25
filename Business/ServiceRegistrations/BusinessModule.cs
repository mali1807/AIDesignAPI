using Autofac.Core;
using Business.Abstract;
using Business.Concrete;
using Core.Configurations;
using Core.Identity.Entities;
using Core.IoC;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DataAccess.ServiceRegistrations
{
    public class BusinessModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            
        }
    }
}
