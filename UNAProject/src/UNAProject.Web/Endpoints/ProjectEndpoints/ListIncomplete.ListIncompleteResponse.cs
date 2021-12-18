// <copyright file="ListIncomplete.ListIncompleteResponse.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public class ListIncompleteResponse
    {
        public int ProjectId { get; set; }

        public List<ToDoItemRecord> IncompleteItems { get; set; }
    }
}
