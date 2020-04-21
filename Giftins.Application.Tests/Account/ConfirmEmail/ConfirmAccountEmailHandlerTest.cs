using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.ConfirmEmail
{
    [TestClass]
    public class ConfirmAccountEmailHandlerTest : ApplicationTestBase
    {
        public ConfirmAccountEmailHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void ConfirmAccountEmailTest()
        {
            var cmd = new Application.Account.ConfirmEmail.ConfirmAccountEmailCommand();
            _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
