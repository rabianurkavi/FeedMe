using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GateValidator:AbstractValidator<Gate>
    {
        public GateValidator()
        {
            RuleFor(x => x.GateCoordinate).NotEmpty().WithMessage("Lütfen koordinatları girin.");


        }
    }
}
