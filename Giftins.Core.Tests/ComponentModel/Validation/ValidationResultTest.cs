using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Giftins.Core.ComponentModel.Validation.Tests
{
    [TestClass]
    public class ValidationResultTest
    {
        [TestMethod]
        public void FilledValidationResultCorrect()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>()
            {
                { "p1", "err1" },
                { "p2", "err2" }
            };
            var res = ValidationResult.Completed(errors);

            Assert.IsFalse(res.IsValid);
            CollectionAssert.AreEquivalent(errors.Values.ToArray(), res.ValidationErrors.ToArray());
        }

        [TestMethod]
        public void EmptyValidationResultCorrect()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            var res = ValidationResult.Completed(errors);

            Assert.IsTrue(res.IsValid);
            Assert.AreEqual(0, res.PropertyErrors.Count);
            Assert.AreEqual(0, res.ValidationErrors.Count());
        }
    }
}
