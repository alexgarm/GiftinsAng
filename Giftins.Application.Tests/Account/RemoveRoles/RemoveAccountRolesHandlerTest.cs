using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.RemoveRoles
{
    [TestClass]
    public class RemoveAccountRolesHandlerTest : ApplicationTestBase
    {
        public RemoveAccountRolesHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void RemoveAccountRolesTest()
        {
            var cmd = new Application.Account.RemoveRoles.RemoveAccountRolesCommand();
            _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
