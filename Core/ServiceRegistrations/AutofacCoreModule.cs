﻿using Autofac;
using Core.Identity.Jwt;

namespace Core.ServiceRegistrations
{
    public class AutofacCoreModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();
        }
    }
}
