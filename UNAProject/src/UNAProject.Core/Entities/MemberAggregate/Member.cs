// <copyright file="Member.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using UNAProject.SharedKernel;
using UNAProject.SharedKernel.Interfaces;

namespace UNAProject.Core.Entities.MemberAggregate
{
    public class Member : BaseEntity, IAggregateRoot
    {
        public Member(string userId)
        {
            UserId = Guard.Against.NullOrWhiteSpace(userId, nameof(userId));
            Status = AccountStatus.Pending;
        }

        public string UserId { get; init; }

        public AccountStatus Status { get; private set; }

        public void ChangeStatus(AccountStatus accountStatus)
        {
            Status = accountStatus;
        }
    }
}
