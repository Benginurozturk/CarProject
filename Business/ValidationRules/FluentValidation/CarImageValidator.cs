using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ca => ca.CarId).NotEmpty();
            RuleFor(ca => ca.ImageId).NotEmpty();
            RuleFor(ca => ca.ImagePath).NotEmpty();
            
        }

    }

}
