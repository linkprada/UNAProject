﻿// <copyright file="HomeControllerIndex.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Net.Http;
using System.Threading.Tasks;
using UNAProject.Web;
using Xunit;

namespace UNAProject.FunctionalTests.ControllerViews
{
    [Collection("Sequential")]
    public class HomeControllerIndex : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerIndex(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsViewWithCorrectMessage()
        {
            HttpResponseMessage response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            string stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains("UNAProject.Web", stringResponse);
        }
    }
}
