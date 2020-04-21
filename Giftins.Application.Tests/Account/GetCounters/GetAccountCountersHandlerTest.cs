using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.GetCounters
{
    [TestClass]
    public class GetAccountCountersHandlerTest : ApplicationTestBase
    {
        public GetAccountCountersHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void GetAccountCountersTest()
        {
            var cmd = new Application.Account.GetCounters.GetAccountCountersQuery();
            var res = _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
