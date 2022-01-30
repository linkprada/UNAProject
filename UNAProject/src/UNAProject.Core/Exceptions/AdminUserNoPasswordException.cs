// <copyright file="AdminUserNoPasswordException.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;

namespace UNAProject.Core.Exceptions
{
    public class AdminUserNoPasswordException : Exception
    {
        public AdminUserNoPasswordException()
        {
        }

        public AdminUserNoPasswordException(string message)
            : base(message)
        {
        }

        public AdminUserNoPasswordException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
