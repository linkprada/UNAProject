// <copyright file="PublicationConfiguration.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UNAProject.Core.Entities.PublicationAggregate;

namespace UNAProject.Infrastructure.Data.Config
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired();

            builder.Property(p => p.Type)
                .IsRequired();
        }
    }
}
