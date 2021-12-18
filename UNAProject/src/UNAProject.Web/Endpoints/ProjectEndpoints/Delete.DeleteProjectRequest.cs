// <copyright file="Delete.DeleteProjectRequest.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public class DeleteProjectRequest
    {
        public const string Route = "/Projects/{ProjectId:int}";

        public static string BuildRoute(int projectId) => Route.Replace("{ProjectId:int}", projectId.ToString());

        public int ProjectId { get; set; }
    }
}
