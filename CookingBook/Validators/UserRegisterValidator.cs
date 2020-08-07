using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto.User;
using FluentValidation;

namespace CookingBook.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be empty");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email required");
            RuleFor(x => x.Password).Length(5, 25).Equal(c => c.Confirmation).WithMessage("Password mismatch");
            RuleFor(x => x.Confirmation).Length(5, 25).Equal(c => c.Password);

        }
    }
}
