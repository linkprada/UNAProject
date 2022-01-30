// <copyright file="AppUserConfiguration.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UNAProject.Core.Entities.AppUserAggregate;

namespace UNAProject.Infrastructure.Data.Config
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(au => au.Username)
                .IsRequired();

            builder.Property(au => au.Password)
                .IsRequired();

            builder.Property(au => au.Email)
                .IsRequired();
        }
    }
}
