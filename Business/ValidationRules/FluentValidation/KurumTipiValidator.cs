using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class KurumTipiValidator:AbstractValidator<KurumTipi>
    {
        public KurumTipiValidator()
        {
            RuleFor(a => a.Adi).NotEmpty().WithMessage("Kurum Tipi Adı alanı bış geçilemez.");
            RuleFor(a => a.KurumTurId).GreaterThan(0).WithMessage("Kurum Türü seçimi yapmadınız.");
        }
    }
}
