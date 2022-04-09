// <copyright file="CustomWebApplicationFactory.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UNAProject.Infrastructure.Data;
using UNAProject.Infrastructure.Identity;
using UNAProject.UnitTests;
using UNAProject.Web;

namespace UNAProject.FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        /// <summary>
        /// Overriding CreateHost to avoid creating a separate ServiceProvider per this thread:
        /// https://github.com/dotnet-architecture/eShopOnWeb/issues/465
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = builder.Build();

            // Get service provider.
            var serviceProvider = host.Services;

            // Create a scope to obtain a reference to the database
            // context (AppDbContext).
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                var logger = scopedServices
                    .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                // Ensure the database is created.
                db.Database.EnsureCreated();

                try
                {
                    // Seed the database with test data.
                    AppDbContextSeed.PopulateTestData(db);

                    // seed sample user data
                    var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
                    AppIdentityDbContextSeed.SeedAsync(userManager, roleManager).Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred seeding the " +
                                        "database with test messages. Error: {ex.Message}");
                }
            }

            host.Start();
            return host;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder
                .UseSolutionRelativeContentRoot("UNAProject/src/UNAProject.Web")
                .ConfigureServices(services =>
                {
                    RemoveExistingDbContextImplementaions(services);

                    services.AddEntityFrameworkInMemoryDatabase();

                    // Create a new service provider.
                    var provider = services.BuildServiceProvider();

                    // Add a database context (ApplicationDbContext) using an in-memory 
                    // database for testing.
                    services.AddDbContext<AppDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(provider);
                    });

                    services.AddDbContext<AppIdentityDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("Identity");
                        options.UseInternalServiceProvider(provider);
                    });

                    services.AddScoped<IMediator, NoOpMediator>();
                });
        }

        private static void RemoveExistingDbContextImplementaions(IServiceCollection services)
        {
            var descriptors = services.Where(d =>
                                                d.ServiceType == typeof(DbContextOptions<AppDbContext>) ||
                                                d.ServiceType == typeof(DbContextOptions<AppIdentityDbContext>))
                                            .ToList();

            if (descriptors.Count > 0)
            {
                foreach (var descriptor in descriptors)
                {
                    services.Remove(descriptor);
                }
            }
        }
    }
}