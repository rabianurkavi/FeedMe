using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnimalLoverValidator : AbstractValidator<AnimalLover>
    {
        public AnimalLoverValidator()
        {
            RuleFor(x => x.AnimalLoverName).NotEmpty().WithMessage("ismini boş bırakamazsınız");
            RuleFor(x => x.AnimalLoverPassword).NotEmpty().WithMessage("Şifre kısmını boş geçemezsiniz");
            RuleFor(x => x.AnimalLoverSurName).NotEmpty().WithMessage("Soy ismini boş bırakamazsınız");
            RuleFor(x => x.AnimalLoverAbout).MaximumLength(100).WithMessage("100 karakterden fazla giriş yapamazsınız.");
            RuleFor(x => x.AnimalLoverSurName).MaximumLength(40).WithMessage("40 karakterden fazla giriş yapamazsınız");
            RuleFor(x => x.AnimalLoverName).MaximumLength(40).WithMessage("40 karakterden fazla giriş yapamazsınız");
            RuleFor(x => x.AnimalLoverName).MinimumLength(3).WithMessage("3 karakterden daha az isim giremezsiniz");
            RuleFor(x => x.AnimalLoverSurName).MinimumLength(3).WithMessage("3 karakterden daha az soy isim giremezsiniz");
        }
    }
}
