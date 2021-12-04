using System.Collections.Generic;
using UNAProject.Core.ProjectAggregate;

namespace UNAProject.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
