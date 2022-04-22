// <copyright file="PublicationConstructor.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.PublicationAggregate
{
    public class PublicationConstructor
    {
        private readonly string _publicationTitle = "testPublication";

        [Fact]
        public void Instantiate_Publication()
        {
            var publication = new Publication(_publicationTitle, PublicationType.JobOffre);
            Assert.Equal(_publicationTitle, publication.Title);
            Assert.Equal(PublicationType.JobOffre, publication.Type);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_PublicationWithTitleWhiteSpaceOrNull_ThrowException(string inputPublicationTitle)
        {
            Action action = () => new Publication(inputPublicationTitle, PublicationType.Simple);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
