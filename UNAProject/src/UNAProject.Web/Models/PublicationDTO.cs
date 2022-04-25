// <copyright file="PublicationDTO.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using UNAProject.Core.Entities.PublicationAggregate;

namespace UNAProject.Web.Models
{
    public class PublicationDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public PublicationType PublicationType { get; set; }

        public List<Attachment> Attachments { get; set; }
    }
}
