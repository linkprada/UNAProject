// <copyright file="PublicationDTO.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using UNAProject.Core.Entities.PublicationAggregate;

namespace UNAProject.Web.Models
{
    public class PublicationDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Uri> ImagesUri { get; set; }

        public List<Uri> FilesUri { get; set; }
    }
}
