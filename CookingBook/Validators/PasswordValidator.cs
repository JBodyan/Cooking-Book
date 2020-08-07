using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using FluentValidation;

namespace CookingBook.Validators
{
    public class PasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public PasswordValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).Length(5, 25).Equal(c => c.Confirmation);
            RuleFor(x => x.Confirmation).Length(5, 25).Equal(c => c.Password);
        }
    }
}
