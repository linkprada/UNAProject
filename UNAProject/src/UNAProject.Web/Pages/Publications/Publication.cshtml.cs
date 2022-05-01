// <copyright file="Publication.cshtml.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.Core.Entities.PublicationAggregate.Specifications;
using UNAProject.SharedKernel.Interfaces;
using UNAProject.Web.Models;

namespace UNAProject.Web.Pages.Publications
{
    public class PublicationModel : PageModel
    {
        private readonly IReadRepository<Publication> _publicationRepository;
        private readonly IMapper _mapper;

        public PublicationModel(IReadRepository<Publication> publicationRepository, IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _mapper = mapper;
        }

        public PublicationDTO Publication { get; set; }

        public PublicationType PublicationType { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var publicationSpec = new PublicationWithAttachmentsSpecification(id);
            var publicationFound = await _publicationRepository.GetBySpecAsync(publicationSpec);
            if (publicationFound is null)
            {
                return LocalRedirect("/");
            }

            Publication = _mapper.Map<PublicationDTO>(publicationFound);

            return Page();
        }
    }
}
