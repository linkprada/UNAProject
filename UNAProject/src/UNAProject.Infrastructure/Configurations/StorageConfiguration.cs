// <copyright file="StorageConfiguration.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

namespace UNAProject.Infrastructure.Configurations
{
    public class StorageConfiguration
    {
        public const string StorageConfig = "StorageConfiguration";

        public string ImagesPath { get; set; }

        public string FilesPath { get; set; }
    }
}
