using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.Roles
{
    [TestClass]
    public class GetAccountRolesHandlerTest : ApplicationTestBase
    {
        public GetAccountRolesHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void GetAccountRolesTest()
        {
            var cmd = new Application.Account.Roles.GetAccountRolesQuery();
            var res = _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
