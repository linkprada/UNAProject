// <copyright file="PaginationService.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using UNAProject.Web.Interfaces;
using UNAProject.Web.ViewModels;

namespace UNAProject.Web.Services
{
    public class PaginationService : IPaginationService
    {
        public PaginationInfosViewModel CreatePaginationInfos(int pageIndex, int itemsPerPage, int totalItemsCount)
        {
            var paginationInfos = new PaginationInfosViewModel
            {
                CurrentPage = pageIndex,
                ItemsPerPage = itemsPerPage,
                TotalPages = GetTotalPagesCount(itemsPerPage, totalItemsCount),
            };

            return paginationInfos;
        }

        private static int GetTotalPagesCount(int itemsPerPage, int totalItemsCount)
        {
            return decimal.ToInt32(Math.Ceiling((decimal)(totalItemsCount / itemsPerPage)));
        }
    }
}
