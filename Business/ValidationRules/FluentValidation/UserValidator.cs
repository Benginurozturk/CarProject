using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(u => u.UserFirstName).NotEmpty();
            RuleFor(u => u.UserLastName).NotEmpty();
            RuleFor(u => u.UserEmail).NotEmpty();
            //RuleFor(u => u.UserPasswordHash).NotEmpty();
            RuleFor(u => u.UserEmail).EmailAddress();
            RuleFor(u => u.UserFirstName).MinimumLength(2);
            RuleFor(u => u.UserLastName).MinimumLength(2);
            //RuleFor(u => u.UserPasswordSalt).MinimumLength(7);

        }
    }
}



