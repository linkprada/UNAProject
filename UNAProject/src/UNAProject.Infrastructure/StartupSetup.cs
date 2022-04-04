// <copyright file="StartupSetup.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UNAProject.Infrastructure.Data;
using UNAProject.Infrastructure.Identity;

namespace UNAProject.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)); // will be created in web project root

        public static void AddIdentityDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(connectionString)); // will be created in web project root
    }
}
