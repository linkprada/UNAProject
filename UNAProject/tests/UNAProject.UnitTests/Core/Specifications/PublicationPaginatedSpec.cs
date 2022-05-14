// <copyright file="PublicationPaginatedSpec.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.Core.Entities.PublicationAggregate.Specifications;
using Xunit;

namespace UNAProject.UnitTests.Core.Specifications
{
    public class PublicationPaginatedSpec
    {
        [Theory]
        [InlineData(3, 0, 3)]
        [InlineData(2, 2, 1)]
        [InlineData(1, 4, 1)]
        [InlineData(3, 1, 2)]
        public void PublicationPaginatedSpec_GetPublicationsSpecifiedByPageSize(int inputPageSize, int inputPageIndex, int expectedPublicationsCount)
        {
            var specification = new PublicationPaginatedSpecification(inputPageSize * inputPageIndex, inputPageSize);

            var publicationsPerPage = specification.Evaluate(GetPublicationsListTest()).ToList();

            Assert.Equal(expectedPublicationsCount, publicationsPerPage.Count);
        }

        [Fact]
        public void PublicationPaginatedSpec_GetNoPublicationsIfPageIndexOutofRange()
        {
            var testingPublicationsList = GetPublicationsListTest();

            var pageSize = 2;
            var pageIndex = testingPublicationsList.Count * 2;
            var specification = new PublicationPaginatedSpecification(pageSize * pageIndex, pageSize);

            var publicationsPerPage = specification.Evaluate(testingPublicationsList).ToList();

            Assert.Empty(publicationsPerPage);
        }

        private List<Publication> GetPublicationsListTest()
        {
            var publication1 = new Publication("PublicationTest1", PublicationType.Simple);

            var publication2 = new Publication("PublicationTest2", PublicationType.Event);

            var publication3 = new Publication("PublicationTest3", PublicationType.JobOffre);

            var publication4 = new Publication("PublicationTest4", PublicationType.Event);

            var publication5 = new Publication("PublicationTest5", PublicationType.Simple);

            return new List<Publication>() { publication1, publication2, publication3, publication4, publication5 };
        }
    }
}
