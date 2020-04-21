using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.Remove
{
    [TestClass]
    public class RemoveAccountHandlerTest : ApplicationTestBase
    {
        public RemoveAccountHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void RemoveAccountTest()
        {
            var cmd = new Application.Account.Remove.RemoveAccountCommand();
            _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
