// <copyright file="EmailConfiguration.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace UNAProject.Infrastructure.Configurations
{
    public class EmailConfiguration
    {
        public const string EmailConfig = "EmailConfiguration";

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string AdminEmail { get; set; }
    }
}
