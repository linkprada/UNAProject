// <copyright file="DefaultInfrastructureDependencies.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UNAProject.Core.Entities.MemberAggregate;
using UNAProject.Core.Interfaces;
using UNAProject.Infrastructure.Configurations;
using UNAProject.Infrastructure.Data;
using UNAProject.SharedKernel.Interfaces;

namespace UNAProject.Infrastructure
{
    public static class DefaultInfrastructureDependencies
    {
        public static void AddDefaultInfrastructureDependencies(
            this IServiceCollection services,
            IConfiguration configuration,
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

            services.Configure<StorageConfiguration>(configuration.GetSection(StorageConfiguration.StorageConfig));
            services.Configure<EmailConfiguration>(configuration.GetSection(EmailConfiguration.EmailConfig));

            RegisterCommonDependencies(services, assemblies);
        }

        private static List<Assembly> GroupUpAllAssemblies(Assembly callingAssembly)
        {
            var assemblies = new List<Assembly>();

            var coreAssembly = Assembly.GetAssembly(typeof(Member)); // TODO: Replace "Project" with any type from your Core project
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
