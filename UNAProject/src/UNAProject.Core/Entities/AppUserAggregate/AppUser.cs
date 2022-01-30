// <copyright file="AppUser.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.GuardClauses;
using System;
using UNAProject.SharedKernel;
using UNAProject.SharedKernel.Interfaces;

namespace UNAProject.Core.Entities.AppUserAggregate
{
    public class AppUser : BaseEntity, IAggregateRoot
    {
        public AppUser(string username, string password, string email)
        {
            Username = Guard.Against.NullOrWhiteSpace(username, nameof(username));
            Password = Guard.Against.NullOrWhiteSpace(password, nameof(password));
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
            Status = AccountStatus.Pending;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AccountStatus Status { get; private set; }

        public void ApproveAccount()
        {
            Status = AccountStatus.Approved;
        }

        public void BlockAccount()
        {
            Status = AccountStatus.Blocked;
        }

        public void UpdateUsername(string newUsername)
        {
            Username = Guard.Against.NullOrWhiteSpace(newUsername, nameof(newUsername));
        }

        public void UpdatePassword(string newPassword)
        {
            Password = Guard.Against.NullOrWhiteSpace(newPassword, nameof(newPassword));
        }

        public void UpdateEmail(string email)
        {
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
        }
    }
}
