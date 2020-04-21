using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Giftins.Core.ComponentModel;

namespace Giftins.Core.ComponentModel.Tests
{
    [TestClass]
    public class GRequestResultTest
    {
        [TestMethod]
        public void SuccessNullThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                GRequestResult<object>.Success(null);
            });
        }

        [TestMethod]
        public void SuccessNotNullCorrect()
        {
            var resObj = new
            {
                name = "JOHN",
                title = "CENA",
                props = new
                {
                    weight = 100500,
                    cool = "VERY"
                }
            };
            var obj = GRequestResult<object>.Success(resObj);

            Assert.IsTrue(obj.Succeeded);
            Assert.IsNull(obj.Error);
            Assert.AreEqual(obj.Result, resObj);
        }

        [TestMethod]
        public void FailedNullThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                GRequestResult<object>.Failed(null);
            });
        }

        [TestMethod]
        public void FailedWithErrorCorrect()
        {
            GiftinsErrorResponse error = GiftinsErrorResponse.Unknown();
            GRequestResult obj = GRequestResult<object>.Failed(error);

            Assert.IsFalse(obj.Succeeded);
            Assert.IsNull(obj.Result);
            Assert.AreEqual(obj.Error, error);
        }
    }
}
