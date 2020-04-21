using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Core.Exceptions;
using Giftins.Data;
using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.Create
{
    [TestClass]
    public class CreateHandlerTest : ApplicationTestBase
    {
        public CreateHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void CreateFilledCorrectAccount()
        {
            string userName = "testuser001";
            string testPass = "Pass#rd000";
            var cmd = new Application.Account.Create.CreateAccountCommand(userName, testPass, testPass)
            {
                Email = "testuser01@email.net",
                Phone = "+78005553535",
                FirstName = "User",
                LastName = "Test",
                Birthdate = new DateTime(1990, 1, 1),
                LockoutEnabled = false
            };

            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.IsTrue(res.Succeeded);

            var acc = _accountDbContext.Users.First(u => u.Id == res.AccountId);
            Assert.AreEqual(userName, acc.UserName);
            Assert.IsNotNull(acc.SecurityStamp);
            Assert.AreNotEqual(acc.SecurityStamp, "");
            Assert.IsNotNull(acc.PasswordHash);
        }

        [TestMethod]
        public void CreateFilledWithoutPasswordCorrectAccount()
        {
            string userName = "testuser002";
            var cmd = new Application.Account.Create.CreateAccountCommand(userName)
            {
                Email = "testuser02@email.net",
                Phone = "+78005553535",
                FirstName = "User",
                LastName = "Test",
                Birthdate = new DateTime(1990, 1, 1),
                LockoutEnabled = false
            };

            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.IsTrue(res.Succeeded);

            var acc = _accountDbContext.Users.First(u => u.Id == res.AccountId);
            Assert.AreEqual(userName, acc.UserName);
            Assert.IsNotNull(acc.SecurityStamp);
            Assert.AreNotEqual(acc.SecurityStamp, "");
            Assert.IsNull(acc.PasswordHash);
        }

        [TestMethod]
        public void CreateAccountWithUsernameAndEmail()
        {
            string userName = "testuser003";
            string email = "testuser03@email.net";
            var cmd = new Application.Account.Create.CreateAccountCommand(userName)
            {
                Email = email
            };

            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.IsTrue(res.Succeeded);

            var acc = _accountDbContext.Users.First(u => u.Id == res.AccountId);
            Assert.AreEqual(email, acc.Email);
        }

        [TestMethod]
        public void CreateAccountWithNotMatchingPassword()
        {
            string userName = "testuser004";
            string testPass = "Pass#rd000";
            string confirmPass = "Pas#ord000";
            var cmd = new Application.Account.Create.CreateAccountCommand(userName, testPass, confirmPass)
            {
                Email = "testuser@email.net",
                Phone = "+78005553535",
                FirstName = "User",
                LastName = "Test",
                Birthdate = new DateTime(1990, 1, 1),
                LockoutEnabled = false
            };

            Assert.ThrowsException<GiftinsBadRequestException>(() =>
            {
                _mediator.Send(cmd).GetAwaiter().GetResult();
            });
        }

        [TestMethod]
        public void CreateAccountWithoutUsernameFails()
        {
            string testPass = "Pass#rd000";
            var cmd = new Application.Account.Create.CreateAccountCommand(null)
            {
                Email = "testuser@email.net",
                Phone = "+78005553535",
                FirstName = "User",
                LastName = "Test",
                Birthdate = new DateTime(1990, 1, 1),
                Password = testPass,
                ConfirmPassword = testPass,
                LockoutEnabled = false
            };

            Assert.ThrowsException<GiftinsBadRequestException>(() =>
            {
                _mediator.Send(cmd).GetAwaiter().GetResult();
            });
        }

        [TestMethod]
        public void CreateAccountWithDuplicatingEmailFailed()
        {
            string userName1 = "testuser005";
            string userName2 = "testuser006";
            string email = "testuser5.6@email.net";

            var cmd = new Application.Account.Create.CreateAccountCommand(userName1)
            {
                Email = email
            };

            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.IsTrue(res.Succeeded);

            var acc1 = _accountDbContext.Users.First(u => u.Id == res.AccountId);
            Assert.AreEqual(email, acc1.Email);

            cmd = new Application.Account.Create.CreateAccountCommand(userName2)
            {
                Email = email
            };

            res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.IsFalse(res.Succeeded);
        }
    }
}
