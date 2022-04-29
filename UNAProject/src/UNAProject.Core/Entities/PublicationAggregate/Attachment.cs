// <copyright file="Attachment.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using UNAProject.SharedKernel;

namespace UNAProject.Core.Entities.PublicationAggregate
{
    public class Attachment : BaseEntity
    {
        public Attachment(string name, AttachmentType type)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Type = type;
        }

        public string Name { get; set; }

        public AttachmentType Type { get; set; }

        public void UpdateName(string name)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        }
    }
}
