// <copyright file="Publication_AddAttachment.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.PublicationAggregate
{
    public class Publication_AddAttachment
    {
        [Fact]
        public void AddAttachments_PublicationAttachments_AttachmentsWithAddedOne()
        {
            var publication = new Publication("testPublicationAddAttachment", PublicationType.JobOffre);

            var attachment = new Attachment("testFileName", AttachmentType.File);

            publication.AddAttachments(attachment);

            Assert.Contains(attachment, publication.Attachments);
        }
    }
}
