// <copyright file="AttachmentConfiguration.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UNAProject.Core.Entities.PublicationAggregate;

namespace UNAProject.Infrastructure.Data.Config
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.Property(a => a.FileName)
                .IsRequired();

            builder.Property(a => a.FileType)
                .IsRequired();
        }
    }
}
