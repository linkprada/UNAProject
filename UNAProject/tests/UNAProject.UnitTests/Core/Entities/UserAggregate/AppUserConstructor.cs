// <copyright file="AppUserConstructor.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.AppUserAggregate;
using UNAProject.UnitTests.Builders;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.UserAggregate
{
    public class AppUserConstructor
    {
        private readonly string _username = "testusername123";
        private readonly string _password = "testpassword123";
        private readonly string _email = "testemail@";

        [Fact]
        public void Instantiate_AppUser()
        {
            var appUser = new AppUserBuilder()
                                .WithUsername(_username)
                                .WithPassword(_password)
                                .WithEmail(_email)
                                .Build();

            Assert.Equal(_username, appUser.Username);
            Assert.Equal(_password, appUser.Password);
            Assert.Equal(_email, appUser.Email);
            Assert.Equal(AccountStatus.Pending, appUser.Status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_AppUserWithUsernameWhiteSpaceOrNull_ThrowException(string inputUsername)
        {
            Action action = () => new AppUserBuilder()
                                        .WithDefaultValues()
                                        .WithUsername(inputUsername)
                                        .Build();

            Assert.ThrowsAny<ArgumentException>(action);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_AppUserWithPasswordWhiteSpaceOrNull_ThrowException(string inputPassword)
        {
            Action action = () => new AppUserBuilder()
                                        .WithDefaultValues()
                                        .WithPassword(inputPassword)
                                        .Build();

            Assert.ThrowsAny<ArgumentException>(action);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_AppUserWithEmailWhiteSpaceOrNull_ThrowException(string inputEmail)
        {
            Action action = () => new AppUserBuilder()
                                        .WithDefaultValues()
                                        .WithEmail(inputEmail)
                                        .Build();

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
