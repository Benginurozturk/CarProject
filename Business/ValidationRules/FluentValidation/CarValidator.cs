using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(2021).When(p => p.BrandID == 2);
            RuleFor(c => c.ColorID).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(2020);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Araç adı uzunluğu 2 karakterden az olamaz");
            RuleFor(c => c.Description).Must(StartWithO).WithMessage("Arabalar O harfi ile başlamalı");
        }

        private bool StartWithO(string arg)
        {
            return arg.StartsWith("O");
        }
    }
}
