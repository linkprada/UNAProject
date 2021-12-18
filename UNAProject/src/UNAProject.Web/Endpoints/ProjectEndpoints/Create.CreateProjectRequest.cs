// <copyright file="Create.CreateProjectRequest.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public class CreateProjectRequest
    {
        public const string Route = "/Projects";

        [Required]
        public string Name { get; set; }
    }
}