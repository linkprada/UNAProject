// <copyright file="AppUserUpdateUsername.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.UnitTests.Builders;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.UserAggregate
{
    public class AppUserUpdateUsername
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void UpdateUsername_WithUsernameWhiteSpaceOrNull_ThrowException(string inputUsername)
        {
            var appUser = new AppUserBuilder()
                                .WithDefaultValues()
                                .Build();

            Action action = () => appUser.UpdateUsername(inputUsername);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
