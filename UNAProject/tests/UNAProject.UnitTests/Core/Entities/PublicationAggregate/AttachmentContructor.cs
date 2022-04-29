// <copyright file="AttachmentContructor.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.PublicationAggregate
{
    public class AttachmentContructor
    {
        [Fact]
        public void Instantiate_Attachment()
        {
            var attachmentName = "testAttachmentName";
            var attachment = new Attachment(attachmentName, AttachmentType.Image);

            Assert.Equal(attachmentName, attachment.Name);
            Assert.Equal(AttachmentType.Image, attachment.Type);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_AttachmentWithNameWhiteSpaceOrNull_ThrowException(string inputAttachmentName)
        {
            Action action = () => new Attachment(inputAttachmentName, AttachmentType.Image);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
