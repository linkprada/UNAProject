using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UNAProject.Core.Interfaces;
using UNAProject.Core.ProjectAggregate;
using UNAProject.Infrastructure.Data;
using UNAProject.SharedKernel.Interfaces;

namespace UNAProject.Infrastructure
{
    public static class DefaultInfrastructureDependencies
    {
        public static void AddDefaultInfrastructureDependencies(
            this IServiceCollection services,
            bool isDevelopment,
            Assembly callingAssembly = null)
        {
            var assemblies = GroupUpAllAssemblies(callingAssembly);

            if (isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(services);
            }
            else
            {
                RegisterProductionOnlyDependencies(services);
            }
            RegisterCommonDependencies(services, assemblies);
        }

        private static List<Assembly> GroupUpAllAssemblies(Assembly callingAssembly)
        {
            var assemblies = new List<Assembly>();

            var coreAssembly = Assembly.GetAssembly(typeof(Project)); // TODO: Replace "Project" with any type from your Core project
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
            assemblies.Add(coreAssembly);
            assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                assemblies.Add(callingAssembly);
            }

            return assemblies;
        }

        private static void RegisterCommonDependencies(IServiceCollection services, List<Assembly> assemblies)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            services.AddScoped<IEmailSender, EmailSender>();

            services.AddMediatR(assemblies.ToArray());
        }

        private static void RegisterProductionOnlyDependencies(IServiceCollection services)
        {
            
        }

        private static void RegisterDevelopmentOnlyDependencies(IServiceCollection services)
        {
            
        }
    }
}
