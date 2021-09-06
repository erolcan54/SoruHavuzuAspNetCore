using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BransValidator:AbstractValidator<Brans>
    {
        public BransValidator()
        {
            RuleFor(a => a.Adi).NotEmpty().WithMessage("Branş Adı alanı boş geçilemez.");
            RuleFor(a => a.Adi).MinimumLength(2).WithMessage("Branş Adı alanı için yazılan değer uygun değil.");
            RuleFor(a => a.KurumTurId).GreaterThan(0).WithMessage("Kurum Türü seçilmedi.");
        }
    }
}
