// <copyright file="PublicationUpdateTitle.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.PublicationAggregate
{
    public class PublicationUpdateTitle
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdateTitle_PublicationWithTitleWhiteSpaceOrNull_ThrowException(string inputPublicationTitle)
        {
            var publication = new Publication("testPublication", PublicationType.Event);

            Action action = () => publication.UpdateTitle(inputPublicationTitle);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
