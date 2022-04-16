// <copyright file="MemberByUserIdSpecification.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace UNAProject.Core.Entities.MemberAggregate.Specifications
{
    public class MemberByUserIdSpecification : Specification<Member>, ISingleResultSpecification
    {
        public MemberByUserIdSpecification(string userId)
        {
            Query
                .Where(member => member.UserId == userId);

        }
    }
}
