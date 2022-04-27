using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using UNAProject.Core.Entities.PublicationAggregate;
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var publicationFound = await _publicationRepository.GetByIdAsync(id);
            if (publicationFound is null)
            {
                return LocalRedirect("/");
            }

            Publication = _mapper.Map<PublicationDTO>(publicationFound);

            return Page();
        }
    }
}
