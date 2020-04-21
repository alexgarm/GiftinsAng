using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Giftins.Core.Domain.User;
using Giftins.TestUtils.Initializers;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Giftins.Application.Tests.Account.ChangePassword
{
    [TestClass]
    public class ChangePasswordHandlerTest : ApplicationTestBase
    {
        public ChangePasswordHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void ChangeAccountPasswordTest()
        {
            string stubPassword = "StubPass@000!";

            var account = _accountDbContext.Users.First();
            account.PasswordHash = _userManager.PasswordHasher.HashPassword(account, stubPassword);
            _accountDbContext.SaveChanges();

            string stubPasswordHash = account.PasswordHash;

            _accountDbContext.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            string newPass = "TestPassw@000!";

            var cmd = new Application.Account.ChangePassword.ChangeAccountPasswordCommand()
            {
                AccountId = account.Id,
                OldPassword = stubPassword,
                NewPassword = newPass
            };
            _mediator.Send(cmd).GetAwaiter().GetResult();

            var newAcc = _accountDbContext.Users.First();

            var hashComp = _userManager.PasswordHasher
                .VerifyHashedPassword(account, newAcc.PasswordHash, newPass);

            Assert.AreNotEqual(stubPasswordHash, newAcc.PasswordHash);
            Assert.AreEqual(hashComp, newAcc.PasswordHash);
        }
    }
}
