using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Data;
using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.SetInfo
{
    [TestClass]
    public class SetAccountInfoHandlerTest : ApplicationTestBase
    {
        public SetAccountInfoHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void SetAccountInfoTest()
        {
            var account = _accountDbContext.Users.First();
            _accountDbContext.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            string NewLanguage = "TTR";
            if (NewLanguage == account.Language)
                account.Language = "AZR";

            var cmd = new Application.Account.SetInfo.SetAccountInfoCommand()
            {
                InitiatorId = null,
                AccountId = account.Id,
                Values = new[]
                {
                    new KeyValuePair<string, string>("language", "RUS")
                }
            };
            _mediator.Send(cmd).GetAwaiter().GetResult();

            var newAccount = _accountDbContext.Users.First();

            Assert.AreNotEqual(account.Language, newAccount.Language);
            Assert.AreEqual(newAccount.Language, NewLanguage);
        }

        [TestMethod]
        public void SetAccountInfoUserNotExitTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void SetAccountInfoNullOrEmptyLanguageTest()
        {
            throw new NotImplementedException();
        }
    }
}
