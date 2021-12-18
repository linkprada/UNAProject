// <copyright file="ListIncomplete.ListIncompleteRequest.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Mvc;

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public class ListIncompleteRequest
    {
        [FromRoute]
        public int ProjectId { get; set; }

        [FromQuery]
        public string SearchString { get; set; }
    }
}
