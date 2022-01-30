// <copyright file="Attachment.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using UNAProject.SharedKernel;

namespace UNAProject.Core.Entities.PublicationAggregate
{
    public class Attachment : BaseEntity
    {
        public Attachment(string fileName, AttachmentType fileType)
        {
            FileName = Guard.Against.NullOrWhiteSpace(fileName, nameof(fileName));
            FileType = fileType;
        }

        public string FileName { get; set; }

        public AttachmentType FileType { get; set; }

        public string StoragePath { get; set; }

        public void UpdateFileName(string fileName)
        {
            FileName = Guard.Against.NullOrWhiteSpace(fileName, nameof(fileName));
        }
    }
}
