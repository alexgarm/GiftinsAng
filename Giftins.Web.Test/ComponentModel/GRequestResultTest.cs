using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Core.ComponentModel;
using Giftins.Web.ComponentModel;

namespace Giftins.Web.Test.ComponentModel
{
    [TestClass]
    public class GRequestResultTest
    {
        [TestMethod]
        public void SuccessGJsonResultConversionCorrect()
        {
            float resObj = 3.14f;
            GRequestResult obj = GRequestResult<float>.Success(resObj);
            GJsonResult res = obj;
            Assert.IsTrue(res.Response == GJsonResult.RESPONSE_OK);
            Assert.IsNull(res.Error);
            Assert.AreEqual(res.Result, resObj);
        }

        [TestMethod]
        public void FailedGJsonResultConvertinCorrect()
        {
            GiftinsErrorResponse error = GiftinsErrorResponse.InternalError("BAD FOR U");
            GRequestResult obj = GRequestResult<object>.Failed(error);
            GJsonResult res = obj;

            Assert.IsTrue(res.Response == GJsonResult.RESPONSE_FAIL);
            Assert.IsNull(res.Result);
            Assert.AreEqual(res.Error, error);
        }
    }
}
