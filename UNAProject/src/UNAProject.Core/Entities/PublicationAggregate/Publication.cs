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
        public Publication(string title, PublicationType type)
        {
            Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
            Type = type;

            Attachments = new List<Attachment>();
        }

        public string Title { get; private set; }

        public PublicationType Type { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public List<Attachment> Attachments { get; set; }

        public void UpdateTitle(string newTitle)
        {
            Title = Guard.Against.NullOrWhiteSpace(newTitle, nameof(newTitle));
        }

        public void AddAttachments(Attachment attachment)
        {
            Attachments.Add(attachment);
        }
    }
}
