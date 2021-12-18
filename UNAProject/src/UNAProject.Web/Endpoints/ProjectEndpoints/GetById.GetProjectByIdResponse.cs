// <copyright file="GetById.GetProjectByIdResponse.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public class GetProjectByIdResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ToDoItemRecord> Items { get; set; } = new();
    }
}