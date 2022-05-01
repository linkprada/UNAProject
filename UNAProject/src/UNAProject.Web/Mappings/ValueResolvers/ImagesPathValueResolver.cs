// <copyright file="ImagesPathValueResolver.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Options;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.Web.Configurations;
using UNAProject.Web.Models;

namespace UNAProject.Web.Mappings.ValueResolvers
{
    public class ImagesPathValueResolver : IValueResolver<Publication, PublicationDTO, List<Uri>>
    {
        private readonly StorageConfiguration _storageConfiguration;

        public ImagesPathValueResolver(IOptions<StorageConfiguration> storageConfiguration)
        {
            _storageConfiguration = storageConfiguration.Value;
        }

        public List<Uri> Resolve(Publication source, PublicationDTO destination, List<Uri> destMember, ResolutionContext context)
        {
            return source.Attachments.Select(a => new Uri(_storageConfiguration.ImagesPath + a.Name, UriKind.Relative)).ToList();
        }
    }
}
