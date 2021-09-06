using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(a => a.Ad).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(a => a.Soyad).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.");
            RuleFor(a => a.Sifre).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Geçerli bir email adresi yazınız.");
        }
    }
}
