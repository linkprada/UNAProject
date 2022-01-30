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
            var attachmentFileName = "testFileName";
            var attachment = new Attachment(attachmentFileName, AttachmentType.Image);

            Assert.Equal(attachmentFileName, attachment.FileName);
            Assert.Equal(AttachmentType.Image, attachment.FileType);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_AttachmentWithFileNameWhiteSpaceOrNull_ThrowException(string inputAttachmentFileName)
        {
            Action action = () => new Attachment(inputAttachmentFileName, AttachmentType.Image);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
