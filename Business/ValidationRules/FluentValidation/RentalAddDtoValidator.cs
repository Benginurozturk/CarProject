using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalAddDtoValidator : AbstractValidator<RentalAddDto>
    {
        public RentalAddDtoValidator()
        {
            RuleFor(r => r.RentStartDate).LessThan(r => r.RentEndDate);
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.ReturnDate).WithMessage("Kiralama tarihi, dönüş tarihinden önce olmalıdır");
        }
    }
}
