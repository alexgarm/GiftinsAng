using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Core.ComponentModel;

namespace Giftins.Core.ComponentModel.Tests
{
    [TestClass]
    public class GActionResultTest
    {
        [TestMethod]
        public void SuccessCorrect()
        {
            var obj = GActionResult.Success();

            Assert.IsTrue(obj.Succeeded);
            Assert.IsNull(obj.Error);
        }

        [TestMethod]
        public void FailedNullThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                GActionResult.Failed(null);
            });

        }

        [TestMethod]
        public void FailedNotNullCorrect()
        {
            var obj = GActionResult.Failed(GiftinsErrorResponse.Unknown());

            Assert.IsFalse(obj.Succeeded);
            Assert.IsNotNull(obj.Error);
        }
    }
}
