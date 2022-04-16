// <copyright file="RegisterTests.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using UNAProject.Core.Entities.MemberAggregate;
using UNAProject.Core.Entities.MemberAggregate.Specifications;
using UNAProject.SharedKernel.Interfaces;
using UNAProject.Web;
using Xunit;

namespace UNAProject.FunctionalTests.Web.Account
{
    public class RegisterTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly IReadRepository<Member> _repository;

        public RegisterTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });

            _repository = factory.Services.GetRequiredService<IReadRepository<Member>>();
        }

        [Fact]
        public async Task Register_CreateMemberWhenAddingApplicationUser()
        {
            var getResponse = await _client.GetAsync("/identity/account/register");
            getResponse.EnsureSuccessStatusCode();
            var stringResponse = await getResponse.Content.ReadAsStringAsync();

            var userName = "demousermember@test.test";
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Email", userName),
                new KeyValuePair<string, string>("Password", "Pass@word1"),
                new KeyValuePair<string, string>("ConfirmPassword", "Pass@word1"),
                new KeyValuePair<string, string>(WebPageHelpers.TokenTag, WebPageHelpers.GetRequestVerificationToken(stringResponse)),
            };

            var formContent = new FormUrlEncodedContent(keyValues);

            var postResponse = await _client.PostAsync("/identity/account/register", formContent);

            var memberFound = await _repository.GetBySpecAsync(new MemberByUserIdSpecification(userName));

            Assert.Equal(userName, memberFound?.UserId);
        }
    }
}
