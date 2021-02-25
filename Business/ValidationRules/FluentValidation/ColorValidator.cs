using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(co => co.ColorName).MaximumLength(2).WithMessage("renk ismi maksimum iki karakter olmalı");
            RuleFor(co => co.ColorName).NotEmpty();
            RuleFor(co => co.ColorID).NotEmpty();
        }
    }
}

