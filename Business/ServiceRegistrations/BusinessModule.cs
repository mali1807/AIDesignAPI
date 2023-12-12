﻿using Core.Configurations;
using Core.IoC;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ServiceRegistrations
{
    public class BusinessModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {

        }
    }
}