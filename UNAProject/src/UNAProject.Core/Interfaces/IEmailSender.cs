// <copyright file="IEmailSender.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Threading.Tasks;

namespace UNAProject.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
