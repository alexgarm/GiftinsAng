using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Giftins.Core.ComponentModel.Validation.Tests
{
    [TestClass]
    public class ValidationDescriptorTest
    {
        [TestMethod]
        public void CreateCorrectValidator()
        {
            string propName = "name";
            string invalidMsg = "invalid";

            ValidationDescriptor validator = new ValidationDescriptor(propName, 
                (val) => { return val == "0" ? true : false; }, 
                invalidMsg);

            Assert.AreEqual(propName, validator.PropertyName);
            Assert.AreEqual(invalidMsg, validator.InvalidMessage);
            Assert.IsTrue(validator.Validate("0"));
            Assert.IsFalse(validator.Validate("1"));
        }

        [TestMethod]
        public void CreateArgumentNullThrowException()
        {
            string propName = "name";
            string invalidMsg = "invalid";

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ValidationDescriptor validator = new ValidationDescriptor(propName,
                    (val) => { return val == "0" ? true : false; },
                    null);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ValidationDescriptor validator = new ValidationDescriptor(propName, null, invalidMsg);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                ValidationDescriptor validator = new ValidationDescriptor(null,
                    (val) => { return val == "0" ? true : false; },
                    invalidMsg);
            });
        }

        [TestMethod]
        public void CreateArgumentEmptyThrowException()
        {
            string propName = "name";
            string invalidMsg = "invalid";

            Assert.ThrowsException<ArgumentException>(() =>
            {
                ValidationDescriptor validator = new ValidationDescriptor(propName,
                    (val) => { return val == "0" ? true : false; },
                    "");
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                ValidationDescriptor validator = new ValidationDescriptor("",
                    (val) => { return val == "0" ? true : false; },
                    invalidMsg);
            });
        }
    }
}
