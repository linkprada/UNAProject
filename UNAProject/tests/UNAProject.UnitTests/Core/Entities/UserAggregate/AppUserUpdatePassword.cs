// <copyright file="AppUserUpdatePassword.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.AppUserAggregate;
using UNAProject.UnitTests.Builders;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.UserAggregate
{
    public class AppUserUpdatePassword
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_AppUserWithPasswordWhiteSpaceOrNull_ThrowException(string inputPassword)
        {
            var appUser = new AppUserBuilder()
                                .WithDefaultValues()
                                .Build();

            Action action = () => appUser.UpdatePassword(inputPassword);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
