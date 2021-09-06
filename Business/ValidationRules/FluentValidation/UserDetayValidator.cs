using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserDetayValidator : AbstractValidator<UserDetay>
    {
        public UserDetayValidator()
        {
            RuleFor(a => a.ilId).GreaterThan(0).WithMessage("İl seçimi yapınız.");
            RuleFor(a => a.ilceId).GreaterThan(0).WithMessage("İlçe seçimi yapınız.");
            RuleFor(a => a.KurumTurId).GreaterThan(0).WithMessage("Kurum Türü seçiniz.");
            RuleFor(a => a.KurumTipId).GreaterThan(0).WithMessage("Kurum Tipi seçiniz.");
            RuleFor(a => a.OkulAdi).NotEmpty().WithMessage("Okul Adı alanı boş geçilemez.");
            RuleFor(a => a.BransId).GreaterThan(0).WithMessage("Branş seçimi yapınız.");
        }
    }
}
