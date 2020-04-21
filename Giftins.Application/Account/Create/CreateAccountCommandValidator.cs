using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Giftins.Application.Account.Create
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
