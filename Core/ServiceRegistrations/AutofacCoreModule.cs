using Autofac;
using Core.Identity.Abstract;
using Core.Identity.Concrete;
using Core.Identity.Jwt;

namespace Core.ServiceRegistrations
{
    public class AutofacCoreModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();
        }
    }
}
