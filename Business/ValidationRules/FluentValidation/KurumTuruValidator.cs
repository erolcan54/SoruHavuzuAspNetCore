using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class KurumTuruValidator:AbstractValidator<KurumTuru>
    {
        public KurumTuruValidator()
        {
            RuleFor(a => a.Adi).NotEmpty().WithMessage("Kurum Türü Adı alanı boş geçilemez.");
            RuleFor(a => a.Adi).MinimumLength(2).WithMessage("Kurum Türü Adı alanı için yazılan değer uygun değil.");
        }
    }
}
