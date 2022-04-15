// <copyright file="MemberConstructor.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Core.Entities.MemberAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.MemberAggregate
{
    public class MemberConstructor
    {
        private readonly string _userId = "testusername123";

        [Fact]
        public void Instantiate_MemberFromFakeLoggedInUserId()
        {
            var member = new Member(_userId);

            Assert.Equal(member.UserId, _userId);
            Assert.Equal(AccountStatus.Pending, member.Status);
        }
    }
}
