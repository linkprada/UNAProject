// <copyright file="DefaultCoreDependencies.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UNAProject.Core.Interfaces;
using UNAProject.Core.Services;

namespace UNAProject.Core
{
    public static class DefaultCoreDependencies
    {
        public static void AddDefaultCoreDependencies(this IServiceCollection services)
        {
            services.AddScoped<IToDoItemSearchService, ToDoItemSearchService>();
        }
    }
}
