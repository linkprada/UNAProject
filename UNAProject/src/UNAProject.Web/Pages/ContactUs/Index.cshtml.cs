// <copyright file="Index.cshtml.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UNAProject.Core.Interfaces;
using UNAProject.Web.Models;

namespace UNAProject.Web.Pages.ContactUs
{
    public class IndexModel : PageModel
    {
        private readonly IEmailSender _emailSender;

        public IndexModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [BindProperty]
        public ContactUsDTO ContactUsDTO { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _emailSender.SendEmailAsync(ContactUsDTO.Email, ContactUsDTO.Subject, ContactUsDTO.Message);

            return RedirectToPage("/");
        }
    }
}
