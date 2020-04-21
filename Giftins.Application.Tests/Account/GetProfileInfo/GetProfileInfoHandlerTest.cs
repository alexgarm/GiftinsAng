using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Data;
using Giftins.TestUtils.Initializers;

namespace Giftins.Application.Tests.Account.GetProfileInfo
{
    [TestClass]
    public class GetProfileInfoHandlerTest : ApplicationTestBase
    {

        public GetProfileInfoHandlerTest()
        {
            var dbInitializer = (BasicDummyInitializer)_services.GetService(typeof(BasicDummyInitializer));
            dbInitializer.Initialize(_userManager, _accountDbContext, 1);
        }

        [TestMethod]
        public void GetProfileInfoTest()
        {
            var account = _accountDbContext.Users.First();

            var cmd = new Application.Account.GetProfileInfo.GetProfileInfoQuery()
            {
                AccountId = account.Id
            };

            var res = _mediator.Send(cmd).GetAwaiter().GetResult();

            Assert.AreEqual(account.Id, res.AccountId);
            Assert.AreEqual(BasicDummyInitializer.FormatFirstName(0), res.FirstName);
            Assert.AreEqual(BasicDummyInitializer.FormatLastName(0), res.LastName);
            Assert.IsNotNull(res.Gender);
            Assert.IsNotNull(res.Relation);
            Assert.AreEqual(BasicDummyInitializer.FormatBirthdateTime(0), res.Birthdate);
            Assert.IsNull(res.Country);
            Assert.IsNull(res.City);
        }
    }
}
