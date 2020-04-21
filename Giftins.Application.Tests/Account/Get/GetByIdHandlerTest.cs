using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.Get
{
    [TestClass]
    public class GetByIdHandlerTest : ApplicationTestBase
    {
        public GetByIdHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var account = _accountDbContext.Users.First();
            _accountDbContext.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            var cmd = new Application.Account.Get.GetAccountByIdQuery()
            {
                AccountId = account.Id
            };
            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.AreEqual(account.Id, res.Id);
        }
    }
}
