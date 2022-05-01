// <copyright file="AppDbContextSeed.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UNAProject.Core.Entities.PublicationAggregate;

namespace UNAProject.Infrastructure.Data
{
    public static class AppDbContextSeed
    {
        public static readonly Publication Publication1 = new Publication("PublicationTest1", PublicationType.Simple)
        {
            Description = "A very long description1 for testing purpose",
        };

        public static readonly Publication Publication2 = new Publication("PublicationTest2", PublicationType.Simple)
        {
            Description = "A very long description2 for testing purpose",
        };

        public static readonly Publication Publication3 = new Publication("PublicationTest3", PublicationType.Simple)
        {
            Description = "A very long description3 for testing purpose",
        };

        public static readonly Attachment Attachment1 = new Attachment("test1.jpg", AttachmentType.Image);
        public static readonly Attachment Attachment2 = new Attachment("test2.jpg", AttachmentType.Image);
        public static readonly Attachment Attachment3 = new Attachment("test3.jpg", AttachmentType.Image);

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any Publications items.
                if (dbContext.Publications.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }

        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Publications)
            {
                dbContext.Remove(item);
            }

            dbContext.SaveChanges();

            Publication1.AddAttachments(Attachment1);
            Publication1.AddAttachments(Attachment2);
            Publication1.AddAttachments(Attachment3);

            dbContext.Publications.AddRange(Publication1, Publication2, Publication3);
            dbContext.SaveChanges();
        }
    }
}
