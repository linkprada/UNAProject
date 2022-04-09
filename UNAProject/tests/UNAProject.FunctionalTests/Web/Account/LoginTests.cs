// <copyright file="LoginTests.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using UNAProject.Web;
using Xunit;

namespace UNAProject.FunctionalTests.Web.Account
{
    public class LoginTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public LoginTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });
        }

        [Fact]
        public async Task Login_WithValidCredentials_SuccefulSignInAsync()
        {
            var getResponse = await _client.GetAsync("/identity/account/login");
            getResponse.EnsureSuccessStatusCode();
            var stringResponse = await getResponse.Content.ReadAsStringAsync();

            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Email", "demouser@test.test"),
                new KeyValuePair<string, string>("Password", "Pass@word1"),
                new KeyValuePair<string, string>(WebPageHelpers.TokenTag, WebPageHelpers.GetRequestVerificationToken(stringResponse)),
            };
            var formContent = new FormUrlEncodedContent(keyValues);

            var postResponse = await _client.PostAsync("/identity/account/login", formContent);
            Assert.Equal(HttpStatusCode.Redirect, postResponse.StatusCode);
            Assert.Equal(new Uri("/", UriKind.Relative), postResponse.Headers.Location);
        }
    }
}
