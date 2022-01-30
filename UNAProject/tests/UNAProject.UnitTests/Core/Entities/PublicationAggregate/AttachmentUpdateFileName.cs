// <copyright file="AttachmentUpdateFileName.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.PublicationAggregate
{
    public class AttachmentUpdateFileName
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdateTitle_AttachmentWithFileNameWhiteSpaceOrNull_ThrowException(string inputAttachmentFileName)
        {
            var publication = new Attachment("testPublication", AttachmentType.Image);

            Action action = () => publication.UpdateFileName(inputAttachmentFileName);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
