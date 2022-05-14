// <copyright file="Index.cshtml.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.Core.Entities.PublicationAggregate.Specifications;
using UNAProject.SharedKernel.Interfaces;
using UNAProject.Web.Interfaces;
using UNAProject.Web.Models;
using UNAProject.Web.ViewModels;

namespace UNAProject.Web.Pages.Publications
{
    public class IndexModel : PageModel
    {
        private readonly IReadRepository<Publication> _publicationRepository;
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;

        public IndexModel(IReadRepository<Publication> publicationRepository, IMapper mapper, IPaginationService paginationService)
        {
            _publicationRepository = publicationRepository;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public PaginationInfosViewModel PaginationViewModel { get; set; }

        public List<PublicationDTO> Publications { get; set; }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var publicationsPaginatedSpec = new PublicationPaginatedSpecification((pageIndex - 1) * Constants.ITEMS_PER_PAGE, Constants.ITEMS_PER_PAGE);

            var retrievedPublications = await _publicationRepository.ListAsync(publicationsPaginatedSpec);

            Publications = _mapper.Map<List<PublicationDTO>>(retrievedPublications);

            var totalPublicationsCount = await _publicationRepository.CountAsync();
            PaginationViewModel = _paginationService.CreatePaginationInfos(pageIndex, Publications.Count, totalPublicationsCount);
        }
    }
}
