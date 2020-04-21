using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.Edit
{
    [TestClass]
    public class EditAccountHandlerTest : ApplicationTestBase
    {
        public EditAccountHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void ManuallyEditAllAccountFieldsTest()
        {
            var oldAccInfo = _accountDbContext.Users.First();
            _accountDbContext.Entry(oldAccInfo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            string newEmail = "newRandomEmail@random.mail";
            string newPhone = "+380512555555";
            DateTimeOffset? newLockoutEnd = oldAccInfo.LockoutEnd?.AddDays(1) ?? new DateTime(2200, 1, 1);

            var cmd = new Application.Account.Edit.EditAccountCommand()
            {
                AccountId = oldAccInfo.Id,
                Enabled = !oldAccInfo.Enabled,
                Email = newEmail,
                PhoneNumber = newPhone,
                EmailConfirmed = !oldAccInfo.EmailConfirmed,
                PhoneNumberConfirmed = !oldAccInfo.PhoneNumberConfirmed,
                LockoutEnabled = !oldAccInfo.LockoutEnabled,
                LockoutEnd = newLockoutEnd
            };
            _mediator.Send(cmd).GetAwaiter().GetResult();

            var newAccInfo = _accountDbContext.Users.First();

            Assert.AreEqual(oldAccInfo.Id, newAccInfo.Id);
            Assert.AreNotEqual(oldAccInfo.Enabled, newAccInfo.Enabled);
            Assert.AreNotEqual(oldAccInfo.Email, newAccInfo.Email);
            Assert.AreNotEqual(oldAccInfo.PhoneNumber, newAccInfo.PhoneNumber);
            Assert.AreNotEqual(oldAccInfo.EmailConfirmed, newAccInfo.EmailConfirmed);
            Assert.AreNotEqual(oldAccInfo.PhoneNumberConfirmed, newAccInfo.PhoneNumberConfirmed);
            Assert.AreNotEqual(oldAccInfo.LockoutEnabled, newAccInfo.LockoutEnabled);
            Assert.AreNotEqual(oldAccInfo.LockoutEnd, newAccInfo.LockoutEnd);

            Assert.AreNotEqual(oldAccInfo.SecurityStamp, newAccInfo.SecurityStamp);
        }

        [TestMethod]
        public void EditFieldsImpactingAuthorizationChangeSecurityStampTest()
        {
            // TODO: пока непонятно что будет где менять
            var oldAccInfo = _accountDbContext.Users.First();
            oldAccInfo.LockoutEnabled = false;
            _accountDbContext.SaveChanges();
            _accountDbContext.Entry(oldAccInfo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            string newEmail = "newRandomEmail@random.mail";
            string newPhone = "+380512555555";
            DateTimeOffset? newLockoutEnd = oldAccInfo.LockoutEnd?.AddDays(1) ?? new DateTime(2200, 1, 1);

            Application.Account.Edit.EditAccountCommand cmd = null;

            #region Change email test
            cmd = new Application.Account.Edit.EditAccountCommand()
            {
                AccountId = oldAccInfo.Id,
                Email = newEmail
            };
            _mediator.Send(cmd).GetAwaiter().GetResult();
            var newAccInfo = _accountDbContext.Users.First();
            _accountDbContext.Entry(newAccInfo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            Assert.AreEqual(oldAccInfo.Id, newAccInfo.Id);
            Assert.AreEqual(newAccInfo.Email, newEmail);
            Assert.AreNotEqual(oldAccInfo.SecurityStamp, newAccInfo.SecurityStamp);

            oldAccInfo = newAccInfo;
            #endregion

            #region Change phone test

            #endregion

            cmd = new Application.Account.Edit.EditAccountCommand()
            {
                AccountId = oldAccInfo.Id,
                Enabled = !oldAccInfo.Enabled,
                Email = newEmail,
                PhoneNumber = newPhone,
                LockoutEnabled = true
            };
            _mediator.Send(cmd).GetAwaiter().GetResult();
            newAccInfo = _accountDbContext.Users.First();
            _accountDbContext.Entry(newAccInfo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            Assert.AreEqual(oldAccInfo.Id, newAccInfo.Id);
            Assert.AreNotEqual(oldAccInfo.Enabled, newAccInfo.Enabled);
            Assert.AreNotEqual(oldAccInfo.Email, newAccInfo.Email);
            Assert.AreNotEqual(oldAccInfo.PhoneNumber, newAccInfo.PhoneNumber);

            Assert.AreNotEqual(oldAccInfo.LockoutEnabled, newAccInfo.LockoutEnabled);
            Assert.AreNotEqual(oldAccInfo.LockoutEnd, newAccInfo.LockoutEnd);

            Assert.AreNotEqual(oldAccInfo.SecurityStamp, newAccInfo.SecurityStamp);
        }

        [TestMethod]
        public void EditFieldsNotImpactingAuthorizationDontChangeSecurityStampTest()
        {
            // TODO: пока непонятно что будет где менять

            var oldAccInfo = _accountDbContext.Users.First();
            oldAccInfo.LockoutEnabled = true;
            _accountDbContext.SaveChanges();
            _accountDbContext.Entry(oldAccInfo).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            var cmd = new Application.Account.Edit.EditAccountCommand()
            {
                AccountId = oldAccInfo.Id,
                EmailConfirmed = !oldAccInfo.EmailConfirmed,
                PhoneNumberConfirmed = !oldAccInfo.PhoneNumberConfirmed,
                LockoutEnabled = false,
            };
            _mediator.Send(cmd).GetAwaiter().GetResult();

            var newAccInfo = _accountDbContext.Users.First();

            Assert.AreEqual(oldAccInfo.Id, newAccInfo.Id);
            Assert.AreNotEqual(oldAccInfo.EmailConfirmed, newAccInfo.EmailConfirmed);
            Assert.AreNotEqual(oldAccInfo.PhoneNumberConfirmed, newAccInfo.PhoneNumberConfirmed);
            Assert.AreNotEqual(oldAccInfo.LockoutEnabled, newAccInfo.LockoutEnabled);

            Assert.AreEqual(oldAccInfo.SecurityStamp, newAccInfo.SecurityStamp);

            throw new NotImplementedException();
        }

        [TestMethod]
        public void SetEmptyEmailFails()
        {

        }
        
        [TestMethod]
        public void SetEmptyPhoneNumberFails()
        {

        }
    }
}
