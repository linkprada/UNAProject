// <copyright file="EfRepositoryDelete.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task Delete_ExistingPublication_RemovesItFromDBAsync()
        {
            var publicationTitle = "testDeletePublication";
            var publication = new Publication(publicationTitle, PublicationType.Simple);
            var repository = GetRepository<Publication>();

            await repository.AddAsync(publication);

            await repository.DeleteAsync(publication);

            Assert.DoesNotContain(
                await repository.ListAsync(),
                publication => publication.Title == publicationTitle);
        }
    }
}
