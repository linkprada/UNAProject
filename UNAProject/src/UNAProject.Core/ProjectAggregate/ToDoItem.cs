// <copyright file="ToDoItem.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using UNAProject.SharedKernel;

namespace UNAProject.Core.ProjectAggregate
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; }

        public bool IsDone { get; private set; }

        public void MarkComplete()
        {
            IsDone = true;
        }

        public override string ToString()
        {
            string status = IsDone ? "Done!" : "Not done.";
            return $"{Id}: Status: {status} - {Title} - {Description}";
        }
    }
}
