// <copyright file="MappingsProfile.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using AutoMapper;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.Web.Mappings.ValueResolvers;
using UNAProject.Web.Models;

namespace UNAProject.Web.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            // DTO to Entity
            CreateMap<PublicationDTO, Publication>();

            // Entity to DTO
            CreateMap<Publication, PublicationDTO>()
                .ForMember(
                    dest => dest.ImagesUri,
                    opt => opt.MapFrom<ImagesPathValueResolver>());
        }
    }
}
