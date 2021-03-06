﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage("Olmayan araba kiralanamaz");
            RuleFor(r => r.RentStartDate).LessThan(r => r.RentEndDate);
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.ReturnDate).WithMessage("Kiralama tarihi, dönüş tarihinden önce olmalıdır");
        }
    }
}
