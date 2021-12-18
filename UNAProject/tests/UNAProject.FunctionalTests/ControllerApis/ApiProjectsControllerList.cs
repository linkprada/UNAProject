// <copyright file="ApiProjectsControllerList.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ardalis.HttpClientTestExtensions;
using Newtonsoft.Json;
using UNAProject.Web;
using UNAProject.Web.ApiModels;
using Xunit;

namespace UNAProject.FunctionalTests.ControllerApis
{
    [Collection("Sequential")]
    public class ProjectCreate : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProjectCreate(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsOneProject()
        {
            var result = await _client.GetAndDeserialize<IEnumerable<ProjectDTO>>("/api/projects");

            Assert.Single(result);
            Assert.Contains(result, i => i.Name == SeedData.TestProject1.Name);
        }
    }
}
