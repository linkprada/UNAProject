// <copyright file="EfRepositoryUpdate.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task Update_ExistingPublicationField_ChangesItsValueAsync()
        {
            var title = "testUpdatePublication";
            var publication = new Publication(title, PublicationType.Simple);
            var repository = GetRepository<Publication>();

            await repository.AddAsync(publication);

            // detach the item so we get a different instance
            _dbContext.Entry(publication).State = EntityState.Detached;

            var publicationAddeed = (await repository.ListAsync())
                .FirstOrDefault(publication => publication.Title == title);
            Assert.NotNull(publicationAddeed);
            Assert.NotSame(publication, publicationAddeed);

            var updatedTitle = "testUpdatedModifiedPublication";
            publicationAddeed.UpdateTitle(updatedTitle);

            await repository.UpdateAsync(publicationAddeed);

            var publicationUpdated = (await repository.ListAsync())
                .FirstOrDefault(publication => publication.Title == updatedTitle);

            Assert.NotNull(publicationUpdated);
            Assert.NotEqual(publication.Title, publicationAddeed.Title);
            Assert.Equal(publicationAddeed.Id, publicationUpdated.Id);
        }
    }
}
