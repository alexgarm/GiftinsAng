using System;
using System.Collections.Generic;
using System.Text;
using Giftins.TestUtils.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Giftins.Application.Tests.Account.Blacklist
{
    [TestClass]
    public class BlacklistHandlerTest : ApplicationTestBase
    {
        public BlacklistHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void GetAccountBlacklistTest()
        {
            var cmd = new Application.Account.Blacklist.GetAccountBlacklistQuery();
            var res = _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
