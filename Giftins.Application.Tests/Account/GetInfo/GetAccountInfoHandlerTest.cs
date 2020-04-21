using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.GetInfo
{
    [TestClass]
    public class GetAccountInfoHandlerTest : ApplicationTestBase
    {
        public GetAccountInfoHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void GetAccountInfoTest()
        {
            var account = _accountDbContext.Users.First();

            var cmd = new Application.Account.GetInfo.GetAccountInfoQuery()
            {
                AccountId = account.Id
            };
            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.AreEqual(account.Id, res.AccountId);
        }
    }
}
