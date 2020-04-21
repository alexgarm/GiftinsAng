using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.Get
{
    [TestClass]
    public class GetByUsernameHandlerTest : ApplicationTestBase
    {
        public GetByUsernameHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void GetByUsernameTest()
        {
            var account = _accountDbContext.Users.First();
            _accountDbContext.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            var cmd = new Application.Account.Get.GetAccountByUsernameQuery()
            {
                Username = account.UserName
            };
            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.AreEqual(account.Id, res.Id);
            Assert.AreEqual(account.UserName, res.UserName);
        }
    }
}
