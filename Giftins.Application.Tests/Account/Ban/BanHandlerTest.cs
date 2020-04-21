using Giftins.TestUtils.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Application.Tests.Account.Ban
{
    [TestClass]
    public class BanHandlerTest : ApplicationTestBase
    {
        public BanHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void BanUserTest()
        {
            var cmd = new Application.Account.Ban.BanUserCommand();
            _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
