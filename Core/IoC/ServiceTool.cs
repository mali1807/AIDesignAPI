using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IoC
{
    public static class ServiceTool
    {
        //ServiceProvider'ı kullanmamızı sağlıyor bu property
        public static IServiceProvider ServiceProvider { get; private set; }

        //Microsoft'un altyapısını kullanan serviceleri autofac'ın yakalamasını sağlıyor
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
