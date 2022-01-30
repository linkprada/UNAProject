// <copyright file="AppUserBuilder.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using UNAProject.Core.Entities.AppUserAggregate;

namespace UNAProject.UnitTests.Builders
{
    public class AppUserBuilder
    {
        private string _username;
        private string _password;
        private string _email;

        public AppUserBuilder WithUsername(string username)
        {
            _username = username;
            return this;
        }

        public AppUserBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public AppUserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public AppUserBuilder WithDefaultValues()
        {
            _username = "testUsername";
            _password = "testPassword";
            _email = "testEmail";
            return this;
        }

        public AppUser Build()
        {
            return new AppUser(_username, _password, _email);
        }
    }
}
