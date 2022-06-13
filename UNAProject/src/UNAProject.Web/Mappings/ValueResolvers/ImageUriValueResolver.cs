// <copyright file="ImagesPathValueResolver.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Options;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.Infrastructure.Configurations;
using UNAProject.Web.Models;

namespace UNAProject.Web.Mappings.ValueResolvers
{
    public class ImageUriValueResolver :
        IValueResolver<Publication, PublicationDTO, Uri>,
        IValueResolver<Publication, PublicationDTO, List<Uri>>
    {
        private readonly StorageConfiguration _storageConfiguration;

        public ImageUriValueResolver(IOptions<StorageConfiguration> storageConfiguration)
        {
            _storageConfiguration = storageConfiguration.Value;
        }

        public Uri Resolve(Publication source, PublicationDTO destination, Uri destMember, ResolutionContext context)
        {
            return CreateUriFromImageName(source.LeadImageName);
        }

        public List<Uri> Resolve(Publication source, PublicationDTO destination, List<Uri> destMember, ResolutionContext context)
        {
            return source.Attachments.Select(a => CreateUriFromImageName(a.Name)).ToList();
        }

        private Uri CreateUriFromImageName(string imageName)
        {
            return new Uri(_storageConfiguration.ImagesPath + imageName, UriKind.Relative);
        }
    }
}
