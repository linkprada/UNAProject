// <copyright file="ContactUsDTOValidator.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using FluentValidation;
using UNAProject.Web.Models;

namespace UNAProject.Web.Validators
{
    public class ContactUsDTOValidator : AbstractValidator<ContactUsDTO>
    {
        public ContactUsDTOValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(c => c.Subject)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
