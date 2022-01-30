// <copyright file="EfRepositoryAdd.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using UNAProject.Core.Entities.PublicationAggregate;
using Xunit;

namespace UNAProject.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task Add_NewPublication_SetsId()
        {
            var publicationTitle = "testAddPublication";
            var publication = new Publication(publicationTitle, PublicationType.Simple);
            var repository = GetRepository<Publication>();

            await repository.AddAsync(publication);

            var publicationAddeed = (await repository.ListAsync()).FirstOrDefault();

            Assert.Equal(publicationTitle, publicationAddeed?.Title);
            Assert.True(publicationAddeed?.Id > 0);
        }
    }
}
