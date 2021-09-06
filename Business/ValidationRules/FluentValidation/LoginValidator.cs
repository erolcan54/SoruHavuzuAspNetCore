using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator:AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(a=>a.Email).NotEmpty().WithMessage("Email adresi alanı boş geçilemez.");
            RuleFor(a => a.Sifre).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
        }
    }
}
