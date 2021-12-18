// <copyright file="Update.UpdateProjectRequest.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public class UpdateProjectRequest
    {
        public const string Route = "/Projects";

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}