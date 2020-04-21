using Giftins.TestUtils.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Giftins.Application.Tests.Account.AddRoles
{
    [TestClass]
    public class AddRolesHandlerTest : ApplicationTestBase
    {
        public AddRolesHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void AddRolesTest()
        {
            var cmd = new Application.Account.AddRoles.AddAccountRolesCommand();
            _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
