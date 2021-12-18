// <copyright file="ToDoItemRecord.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public record ToDoItemRecord(int Id, string Title, string Description, bool IsDone);
}
