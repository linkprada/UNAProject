// <copyright file="PublicationDTO.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace UNAProject.Web.Models
{
    public class PublicationDTO
    {
        public PublicationDTO()
        {
            ImagesUri = new List<Uri>();
            FilesUri = new List<Uri>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Uri LeadImageName { get; set; }

        public List<Uri> ImagesUri { get; set; }

        public List<Uri> FilesUri { get; set; }
    }
}
