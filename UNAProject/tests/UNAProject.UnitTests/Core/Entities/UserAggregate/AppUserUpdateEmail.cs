// <copyright file="AppUserUpdateEmail.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.UnitTests.Builders;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.UserAggregate
{
    public class AppUserUpdateEmail
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Instantiate_AppUserWithEmailWhiteSpaceOrNull_ThrowException(string inputEmail)
        {
            var appUser = new AppUserBuilder()
                                .WithDefaultValues()
                                .Build();

            Action action = () => appUser.UpdateEmail(inputEmail);

            Assert.ThrowsAny<ArgumentException>(action);
        }
    }
}
