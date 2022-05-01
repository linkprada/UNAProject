// <copyright file="MemberByUserIdSpec.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using UNAProject.Core.Entities.MemberAggregate;
using UNAProject.Core.Entities.MemberAggregate.Specifications;
using Xunit;

namespace UNAProject.UnitTests.Core.Specifications
{
    public class MemberByUserIdSpec
    {
        [Fact]
        public void MemberByUserIdSpec_GetMemberByLoggedInUserName()
        {
            var loggedInUsername = "user2";
            var specification = new MemberByUserIdSpecification(loggedInUsername);

            var memberFound = specification.Evaluate(GetMembersListTest()).SingleOrDefault();

            Assert.Equal(loggedInUsername, memberFound.UserId);
        }

        private List<Member> GetMembersListTest()
        {
            return new List<Member>
            {
                new Member("user1"),
                new Member("user2"),
                new Member("user3"),
            };
        }
    }
}
