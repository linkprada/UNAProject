// <copyright file="ProjectViewModel.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace UNAProject.Web.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ToDoItemViewModel> Items = new();
    }
}
