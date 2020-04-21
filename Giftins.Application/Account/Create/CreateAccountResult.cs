using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Giftins.Application.Account.Create
{
    public class CreateAccountResult
    {
        protected CreateAccountResult()
        { }

        public bool Succeeded { get; protected set; }

        public string AccountId { get; protected set; }

        public IEnumerable<IdentityError> Errors { get; protected set; }

        public static CreateAccountResult Success(string accountId)
        {
            return new CreateAccountResult()
            {
                Succeeded = true,
                AccountId = accountId
            };
        }

        public static CreateAccountResult Failed(IEnumerable<IdentityError> errors)
        {
            return new CreateAccountResult()
            {
                Succeeded = false,
                Errors = errors
            };
        }

        public static CreateAccountResult Failed(params IdentityError[] errors)
        {
            return new CreateAccountResult()
            {
                Succeeded = false,
                Errors = errors
            };
        }

    }
}
