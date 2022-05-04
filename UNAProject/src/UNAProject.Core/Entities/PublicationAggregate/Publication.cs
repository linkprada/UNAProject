// <copyright file="Publication.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using UNAProject.SharedKernel;
using UNAProject.SharedKernel.Interfaces;

namespace UNAProject.Core.Entities.PublicationAggregate
{
    public class Publication : BaseEntity, IAggregateRoot
    {
        private readonly List<Attachment> _attachments = new List<Attachment>();

        public Publication(string title, PublicationType type)
        {
            Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            Type = type;
        }

        public string Title { get; private set; }

        public string LeadImageName { get; set; }

        public PublicationType Type { get; private set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public IEnumerable<Attachment> Attachments => _attachments.AsReadOnly();

        public void UpdateTitle(string newTitle)
        {
            Title = Guard.Against.NullOrWhiteSpace(newTitle, nameof(newTitle));
        }

        public void AddAttachments(Attachment attachment)
        {
            _attachments.Add(attachment);
        }
    }
}
