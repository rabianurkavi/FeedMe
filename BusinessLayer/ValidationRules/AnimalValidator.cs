using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.AnimalName).NotEmpty().WithMessage("Hayvan adını boş geçemezsiniz");
            RuleFor(x => x.AnimalDescription).NotEmpty().WithMessage("Hayvan açıklamasını boş geçemezsiniz");
            RuleFor(x => x.AnimalName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.AnimalName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın");
        }
    }
}

