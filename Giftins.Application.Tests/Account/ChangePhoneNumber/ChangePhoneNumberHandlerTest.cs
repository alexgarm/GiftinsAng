using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.ConfirmPhoneNumber
{
    [TestClass]
    public class ChangePhoneNumberHandlerTest : ApplicationTestBase
    {
        public ChangePhoneNumberHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
        }

        [TestMethod]
        public void ChangePhoneNumberTest()
        {
            var cmd = new Application.Account.ChangePhoneNumber.ChangeAccountPhoneNumberCommand();
            _mediator.Send(cmd).GetAwaiter().GetResult();
        }
    }
}
