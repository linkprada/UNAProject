// <copyright file="IAggregateRoot.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace UNAProject.SharedKernel.Interfaces
{
    // Apply this marker interface only to aggregate root entities
    // Repositories will only work with aggregate roots, not their children
    public interface IAggregateRoot { }
}