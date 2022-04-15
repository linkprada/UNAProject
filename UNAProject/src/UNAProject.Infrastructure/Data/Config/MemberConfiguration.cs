// <copyright file="MemberConfiguration.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UNAProject.Core.Entities.MemberAggregate;

namespace UNAProject.Infrastructure.Data.Config
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(au => au.UserId)
                .IsRequired();
        }
    }
}
