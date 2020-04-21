using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MediatR;

namespace Giftins.Application.Account.Create
{
    /// <summary>
    /// Create new user into system
    /// </summary>
    public class CreateAccountCommand : IRequest<CreateAccountResult>
    {
        /// <summary>
        /// ID of initiator if called manually
        /// </summary>
        public string InitiatorId { get; set; }

        /// <summary>
        /// Unique user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User birthdate
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Is lockout enabled for this user
        /// </summary>
        public bool LockoutEnabled { get; set; } = false;

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User password again
        /// </summary>
        public string ConfirmPassword { get; set; }

        protected CreateAccountCommand()
        { }

        /// <summary>
        /// Format command for creating account with login
        /// </summary>
        /// <param name="userName">Login</param>
        public CreateAccountCommand(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// Format command for creating account with login and password
        /// </summary>
        /// <param name="userName">Login</param>
        /// <param name="password">Password</param>
        /// <param name="confirmPassword">Password confirmation</param>
        public CreateAccountCommand(string userName, string password, string confirmPassword)
        {
            UserName = userName;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
