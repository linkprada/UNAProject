// <copyright file="PaginationInfosViewModel.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;

namespace UNAProject.Web.ViewModels
{
    public class PaginationInfosViewModel
    {
        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
