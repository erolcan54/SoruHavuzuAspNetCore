using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.Ad).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi yazınız.");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.");
            RuleFor(a => a.Soyad).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
        }
    }
}
