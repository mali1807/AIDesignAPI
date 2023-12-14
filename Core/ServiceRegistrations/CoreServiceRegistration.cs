using Core.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceRegistrations
{
    public static class CoreServiceRegistrations
    {
        public static IServiceCollection AddServiceRegistrations(this IServiceCollection services, ICoreModule[] modules)
        {
            //Modul'lere gelen service'leri Service collection'a veriyor
            foreach (var module in modules)
            {
                module.Load(services);
            }
            //ServiceCollection'daki service built edip provider'a ekliyor
            return ServiceTool.Create(services);
        }
    }
}
