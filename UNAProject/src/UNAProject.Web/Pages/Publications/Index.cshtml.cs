// <copyright file="Index.cshtml.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.SharedKernel.Interfaces;
using UNAProject.Web.Models;

namespace UNAProject.Web.Pages.Publications
{
    public class IndexModel : PageModel
    {
        private readonly IReadRepository<Publication> _publicationRepository;
        private readonly IMapper _mapper;

        public IndexModel(IReadRepository<Publication> publicationRepository, IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _mapper = mapper;
        }

        public List<PublicationDTO> Publications { get; set; }

        public async Task OnGetAsync()
        {
            var allPublications = await _publicationRepository.ListAsync();

            Publications = _mapper.Map<List<PublicationDTO>>(allPublications);
        }
    }
}
