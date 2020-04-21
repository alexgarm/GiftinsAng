using System;
using System.Collections.Generic;
using System.Text;
using Giftins.TestUtils.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Giftins.Application.Tests.Account.Unban
{
    [TestClass]
    public class UnbanHandlerTest : ApplicationTestBase
    {
        public UnbanHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void UnbanTest()
        {
            var cmd = new Application.Account.Unban.UnbanUserCommand();
            _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
