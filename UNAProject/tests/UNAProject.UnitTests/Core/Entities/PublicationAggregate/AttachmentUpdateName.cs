// <copyright file="AttachmentUpdateFileName.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.PublicationAggregate
{
    public class AttachmentUpdateName
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdateTitle_AttachmentWithNameWhiteSpaceOrNull_ThrowException(string inputAttachmentName)
        {
            var publication = new Attachment("testPublication", AttachmentType.Image);

            Action action = () => publication.UpdateName(inputAttachmentName);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
