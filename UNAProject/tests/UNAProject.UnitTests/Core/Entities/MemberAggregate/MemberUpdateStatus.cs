// <copyright file="MemberUpdateStatus.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using UNAProject.Core.Entities.MemberAggregate;
using Xunit;

namespace UNAProject.UnitTests.Core.Entities.MemberAggregate
{
    public class MemberUpdateStatus
    {
        private readonly string _userId = "testusername123";

        [Theory]
        [InlineData(AccountStatus.Approved)]
        [InlineData(AccountStatus.Blocked)]
        public void ChangeStatus_ChangeAccountStatus_ReflectAppropriateStatus(AccountStatus expectedAccountStatus)
        {
            var member = new Member(_userId);

            member.ChangeStatus(expectedAccountStatus);

            Assert.Equal(expectedAccountStatus, member.Status);
        }
    }
}
