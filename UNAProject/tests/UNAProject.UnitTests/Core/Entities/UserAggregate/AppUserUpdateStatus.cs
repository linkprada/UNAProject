// <copyright file="AppUserUpdateStatus.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using UNAProject.Core.Entities.AppUserAggregate;
using UNAProject.UnitTests.Builders;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.UserAggregate
{
    public class AppUserUpdateStatus
    {
        [Fact]
        public void ApproveAccount_ChangeAccountStatus_Approved()
        {
            var appUser = new AppUserBuilder()
                                .WithDefaultValues()
                                .Build();

            appUser.ApproveAccount();

            Assert.Equal(AccountStatus.Approved, appUser.Status);
        }

        [Fact]
        public void BlockAccount_ChangeAccountStatus_Blocked()
        {
            var appUser = new AppUserBuilder()
                                .WithDefaultValues()
                                .Build();

            appUser.BlockAccount();

            Assert.Equal(AccountStatus.Blocked, appUser.Status);
        }
    }
}
