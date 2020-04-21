using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Core.ComponentModel;
using Giftins.Core.Exceptions;
using Giftins.Web.ComponentModel;

namespace Giftins.Web.Test.ComponentModel
{
    [TestClass]
    public class GJsonResultTest
    {
        [TestMethod]
        public void SuccessImplicitConvertationCorrect()
        {
            var obj = GActionResult.Success();
            GJsonResult res = obj;

            Assert.IsTrue(res.Response == GJsonResult.RESPONSE_OK);
            Assert.IsNull(res.Result);
            Assert.IsNull(res.Error);
        }

        [TestMethod]
        public void FailedImplicitConvertationCorrect()
        {
            var error = GiftinsErrorResponse.Unknown();
            var obj = GActionResult.Failed(error);
            GJsonResult res = obj;

            Assert.IsTrue(res.Response == GJsonResult.RESPONSE_FAIL);
            Assert.IsNull(res.Result);
            Assert.AreEqual(error, res.Error);
        }

        [TestMethod]
        public void SuccessGJsonResultCast()
        {
            GActionResult obj = GActionResult.Success();
            GJsonResult res = obj;

            Assert.IsTrue(res.Response == GJsonResult.RESPONSE_OK);
            Assert.IsNull(res.Result);
            Assert.IsNull(res.Error);
        }

        [TestMethod]
        public void FailedGJsonResultCast()
        {
            GiftinsErrorResponse error = new GiftinsErrorResponse(GiftinsErrorCode.UnknownError, "Test");
            GActionResult obj = GActionResult.Failed(error);
            GJsonResult res = obj;

            Assert.IsTrue(res.Response == GJsonResult.RESPONSE_FAIL);
            Assert.IsNull(res.Result);
            Assert.AreEqual(error, res.Error);
        }
    }
}
