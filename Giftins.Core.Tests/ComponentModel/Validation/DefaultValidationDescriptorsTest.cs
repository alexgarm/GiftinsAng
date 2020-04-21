using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Giftins.Core.ComponentModel.Validation.Tests
{
    [TestClass]
    public class DefaultValidationDescriptorsTest
    {
        [TestMethod]
        public void NotNullOrEmptyValidationCorrect()
        {
            string prop = "p0";
            string invalidMsg = "Invalid";
            var validator = ValidationDescriptor.NotNullOrEmptyValidation(prop, invalidMsg);

            Assert.AreEqual(prop, validator.PropertyName);
            Assert.AreEqual(invalidMsg, validator.InvalidMessage);

            Assert.IsTrue(validator.Validate("xxx"));
            Assert.IsTrue(validator.Validate("123"));
            Assert.IsFalse(validator.Validate(""));
            Assert.IsFalse(validator.Validate(null));
        }

        [TestMethod]
        public void IntegerValidationCorrect()
        {
            string prop = "p0";
            string invalidMsg = "Invalid";
            var validator = ValidationDescriptor.IntegerValidation(prop, invalidMsg);

            Assert.AreEqual(prop, validator.PropertyName);
            Assert.AreEqual(invalidMsg, validator.InvalidMessage);

            Assert.IsTrue(validator.Validate("0"));
            Assert.IsTrue(validator.Validate("-0"));
            Assert.IsTrue(validator.Validate("123"));
            Assert.IsTrue(validator.Validate("-500"));
            Assert.IsTrue(validator.Validate(int.MaxValue.ToString()));
            Assert.IsTrue(validator.Validate(int.MinValue.ToString()));

            Assert.IsFalse(validator.Validate(""));
            Assert.IsFalse(validator.Validate(null));
            Assert.IsFalse(validator.Validate("sex"));
            Assert.IsFalse(validator.Validate("99999999999999999"));
            Assert.IsFalse(validator.Validate("-99999999999999999"));
        }

        [TestMethod]
        public void BooleanValidation()
        {
            string prop = "p0";
            string invalidMsg = "Invalid";
            var validator = ValidationDescriptor.BooleanValidation(prop, invalidMsg);

            Assert.IsTrue(validator.Validate("true"));
            Assert.IsTrue(validator.Validate("false"));
            Assert.IsTrue(validator.Validate("True"));
            Assert.IsTrue(validator.Validate("FALSE"));
            Assert.IsTrue(validator.Validate("0"));
            Assert.IsTrue(validator.Validate("1"));
            Assert.IsTrue(validator.Validate(true.ToString()));
            Assert.IsTrue(validator.Validate(false.ToString()));

            Assert.IsFalse(validator.Validate("-1"));
            Assert.IsFalse(validator.Validate("-0"));
            Assert.IsFalse(validator.Validate(""));
            Assert.IsFalse(validator.Validate("text"));
            Assert.IsFalse(validator.Validate("hello"));
        }

        [TestMethod]
        public void EmailValidationValidFormat()
        {
            string emailProperty = "email";
            var validator = ValidationDescriptor.EmailValidation(emailProperty);

            Assert.IsTrue(validator.Validate("j..s@proseware.com"));
            Assert.IsTrue(validator.Validate("j.@server1.proseware.com"));
            Assert.IsTrue(validator.Validate("ma...ma@jjf.co"));
            Assert.IsTrue(validator.Validate("ma.@jjf.com"));
            Assert.IsTrue(validator.Validate("ma_@jjf.com"));
            Assert.IsTrue(validator.Validate("12@hostname.com"));
            Assert.IsTrue(validator.Validate("d.j@server1.proseware.com"));
            Assert.IsTrue(validator.Validate("david.jones@proseware.com"));
            Assert.IsTrue(validator.Validate("j.s@server1.proseware.com"));
            Assert.IsTrue(validator.Validate("j_9@[129.126.118.1]"));
            Assert.IsTrue(validator.Validate("jones@ms1.proseware.com"));
            Assert.IsTrue(validator.Validate("m.a@hostname.co"));
            Assert.IsTrue(validator.Validate("m_a1a@hostname.com"));
            Assert.IsTrue(validator.Validate("ma.h.saraf.onemore@hostname.com.edu"));
            Assert.IsTrue(validator.Validate("ma@hostname.com"));
            Assert.IsTrue(validator.Validate("ma12@hostname.com"));
            Assert.IsTrue(validator.Validate("ma-a.aa@hostname.com.edu"));
            Assert.IsTrue(validator.Validate("ma-a@hostname.com"));
            Assert.IsTrue(validator.Validate("ma-a@hostname.com.edu"));
            Assert.IsTrue(validator.Validate("ma@1hostname.com"));
            Assert.IsTrue(validator.Validate("toms.email.@gmail.com"));
        }

        [TestMethod]
        public void EmailValidationInvalidFormat()
        {
            string emailProperty = "email";
            var validator = ValidationDescriptor.EmailValidation(emailProperty);

            Assert.IsFalse(validator.Validate(null));
            Assert.IsFalse(validator.Validate(""));
            Assert.IsFalse(validator.Validate(" "));
            Assert.IsFalse(validator.Validate(" email@example.com"));
            Assert.IsFalse(validator.Validate("email@example.com "));
            Assert.IsFalse(validator.Validate(" email@example.com "));
            Assert.IsFalse(validator.Validate("@majjf.com"));
            Assert.IsFalse(validator.Validate("A@b@c@example.com"));
            Assert.IsFalse(validator.Validate("Abc.example.com"));
            Assert.IsFalse(validator.Validate("js*@proseware.com"));
            Assert.IsFalse(validator.Validate("js@proseware..com"));
            Assert.IsFalse(validator.Validate("ma@@jjf.com"));
            Assert.IsFalse(validator.Validate("ma@jjf."));
            Assert.IsFalse(validator.Validate("ma@jjf..com"));
            Assert.IsFalse(validator.Validate("ma@jjf.c"));
            Assert.IsFalse(validator.Validate("ma_@jjf"));
            Assert.IsFalse(validator.Validate("ma_@jjf."));
            Assert.IsFalse(validator.Validate("-------"));
            Assert.IsFalse(validator.Validate("j@proseware.com9"));
            Assert.IsFalse(validator.Validate("js#internal@proseware.com"));
            Assert.IsFalse(validator.Validate("js@proseware.com9"));
            Assert.IsFalse(validator.Validate("js@proseware.com9"));
            Assert.IsFalse(validator.Validate("ma@hostname.comcom"));
            Assert.IsFalse(validator.Validate("MA@hostname.coMCom"));
        }

        [TestMethod]
        public void PhoneNumberValidFormat()
        {
            string emailProperty = "phone";
            var validator = ValidationDescriptor.PhoneNumberValidator(emailProperty);

            Assert.IsTrue(validator.Validate("+380630000000"));
            Assert.IsTrue(validator.Validate("+79080000000"));
            Assert.IsTrue(validator.Validate("+38(063)0000000"));
            Assert.IsTrue(validator.Validate("+7(908)0000000"));
            Assert.IsTrue(validator.Validate("+38(0512)000000"));
            Assert.IsTrue(validator.Validate("+38(0512)00-00-00"));
            Assert.IsTrue(validator.Validate("+38(044)000-00-00"));

            /* CUMBACK ISRAEL
            Assert.IsTrue(validator.Validate("+97252-000-0000"));
            Assert.IsTrue(validator.Validate("+972-52-000-0000"));
            Assert.IsTrue(validator.Validate("+972(52-000)0000"));
            Assert.IsTrue(validator.Validate("+972(52-000)00-00"));
            */
        }

        [TestMethod]
        public void PhoneNumberInvalidFormat()
        {
            string emailProperty = "phone";
            var validator = ValidationDescriptor.PhoneNumberValidator(emailProperty);

            Assert.IsFalse(validator.Validate(null));
            Assert.IsFalse(validator.Validate(""));
            Assert.IsFalse(validator.Validate(" +380630000000"));
            Assert.IsFalse(validator.Validate("+380630000000 "));
            Assert.IsFalse(validator.Validate(" +380630000000 "));
        }
    }
}
