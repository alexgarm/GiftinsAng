using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Giftins.Core.ComponentModel.Validation.Tests
{
    [TestClass]
    public class PropertiesValidatorTest
    {
        private ValidationDescriptor p1_valLen_min3_validator;
        private ValidationDescriptor p2_val_is_int_validator;

        public PropertiesValidatorTest()
        {
            p1_valLen_min3_validator = new ValidationDescriptor("p1", (value) =>
            {
                return value.Length >= 3;
            },
            "\"p1\" min len 3");
            p2_val_is_int_validator = new ValidationDescriptor("p2", (value) =>
            {
                return int.TryParse(value, out int res);
            },
            "\"p2\" is not integer");
        }

        [TestMethod]
        public void ValidatorAddCorrect()
        {
            PropertiesValidator validator = new PropertiesValidator();

            Assert.IsTrue(validator.Validators.Count() == 0);

            validator.AddValidationDescriptor(p1_valLen_min3_validator);

            Assert.IsTrue(validator.Validators.Count() == 1);
            Assert.AreSame(p1_valLen_min3_validator, validator.Validators.First());
        }

        [TestMethod]
        public void ValidatorAddByNameCorrect()
        {
            string propertyName = "some_prop";
            PropertiesValidator validator = new PropertiesValidator();
            validator.AddValidationDescriptor(propertyName, (val) => val == "", "Invalid");

            var v = validator.Validators.Single();
            Assert.AreEqual(propertyName, v.PropertyName);
        }

        [TestMethod]
        public void ValidatorAddByNameInvalidThrowExceptions()
        {
            string propertyName = "invalid_prop";
            string invalidMsg = "Invalid";

            PropertiesValidator validator = new PropertiesValidator();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                validator.AddValidationDescriptor(null, (val) => val == "", invalidMsg);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                validator.AddValidationDescriptor(propertyName, null, invalidMsg);
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                validator.AddValidationDescriptor(propertyName, (val) => val == "", null);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                validator.AddValidationDescriptor("", (val) => val == "", invalidMsg);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                validator.AddValidationDescriptor(propertyName, (val) => val == "", "");
            });
        }

        [TestMethod]
        public void GenericValidatorAddNotJsonPropertyNameCorrect()
        {
            PropertiesValidator<ValidationTestClass> validator = new PropertiesValidator<ValidationTestClass>();
            bool validationFunc(string v) => v.Length != 3;
            string invalidMsg = "Invalid";

            validator.AddValidationDescriptor(p => p.Prop5, validationFunc, invalidMsg);
            validator.AddValidationDescriptor(p => p.Prop6, validationFunc, invalidMsg);
            validator.AddValidationDescriptor(p => p.Prop7, validationFunc, invalidMsg);
            validator.AddValidationDescriptor(p => p.Prop8, validationFunc, invalidMsg);

            var e1 = validator.Validators.ElementAt(0);
            var e2 = validator.Validators.ElementAt(1);
            var e3 = validator.Validators.ElementAt(2);
            var e4 = validator.Validators.ElementAt(3);

            Assert.AreEqual(nameof(ValidationTestClass.Prop5), e1.PropertyName);
            Assert.AreEqual(nameof(ValidationTestClass.Prop6), e2.PropertyName);
            Assert.AreEqual(nameof(ValidationTestClass.Prop7), e3.PropertyName);
            Assert.AreEqual(nameof(ValidationTestClass.Prop8), e4.PropertyName);
        }

        [TestMethod]
        public void GenericValidatorAddJsonPropertyNameCorrect()
        {
            PropertiesValidator<ValidationTestClass> validator = new PropertiesValidator<ValidationTestClass>();
            bool validationFunc(string v) => v.Length != 3;
            string invalidMsg = "Invalid";

            validator.AddValidationDescriptor(p => p.Prop1, validationFunc, invalidMsg);
            validator.AddValidationDescriptor(p => p.Prop2, validationFunc, invalidMsg);
            validator.AddValidationDescriptor(p => p.Prop3, validationFunc, invalidMsg);
            validator.AddValidationDescriptor(p => p.Prop4, validationFunc, invalidMsg);

            var e1 = validator.Validators.ElementAt(0);
            var e2 = validator.Validators.ElementAt(1);
            var e3 = validator.Validators.ElementAt(2);
            var e4 = validator.Validators.ElementAt(3);

            Assert.AreEqual(ValidationTestClass.PROP_1_NAME, e1.PropertyName);
            Assert.AreEqual(ValidationTestClass.PROP_2_NAME, e2.PropertyName);
            Assert.AreEqual(ValidationTestClass.PROP_3_NAME, e3.PropertyName);
            Assert.AreEqual(ValidationTestClass.PROP_4_NAME, e4.PropertyName);
        }

        [TestMethod]
        public void ValidatorAddNullThrowArgumentNullException()
        {
            PropertiesValidator validator = new PropertiesValidator();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                validator.AddValidationDescriptor(null);
            });
        }

        [TestMethod]
        public void GenericValidatorAddDescriptorWithInvalidPropertyNameThrowArgumentException()
        {
            PropertiesValidator<ValidationTestClass> validator = new PropertiesValidator<ValidationTestClass>();
            ValidationDescriptor descriptor = new ValidationDescriptor("unknown_prop", (val) => val == "", "Invalid");

            Assert.ThrowsException<ArgumentException>(() =>
            {
                validator.AddValidationDescriptor(descriptor);
            });
        }

        [TestMethod]
        public void ValidateSingleCorrectProperty()
        {
            PropertiesValidator validator = new PropertiesValidator();
            validator.AddValidationDescriptor(p1_valLen_min3_validator);

            string value = "xxx";
            var res = validator.Validate(p1_valLen_min3_validator.PropertyName, value, out string invalidMsg);

            Assert.IsTrue(res);
            Assert.IsNull(invalidMsg);
        }

        [TestMethod]
        public void ValidateSingleInvalidProperty()
        {
            PropertiesValidator validator = new PropertiesValidator();
            validator.AddValidationDescriptor(p1_valLen_min3_validator);

            string value = "xx";
            var res = validator.Validate(p1_valLen_min3_validator.PropertyName, value, out string invalidMsg);

            Assert.IsFalse(res);
            Assert.AreEqual(p1_valLen_min3_validator.InvalidMessage, invalidMsg);
        }

        [TestMethod]
        public void ValidateSingleUnknownPropertyAllowedSucceeded()
        {
            PropertiesValidator validator = new PropertiesValidator();
            validator.AddValidationDescriptor(p1_valLen_min3_validator);

            string prop = "p_xxx";
            string value = "xxx";
            var res = validator.Validate(prop, value, out string invalidMsg);

            Assert.IsTrue(validator.AllowUnknownProperties);
            Assert.IsTrue(res);
            Assert.IsNull(invalidMsg);
        }

        [TestMethod]
        public void ValidateSingleUnknownPropertyForbiddenError()
        {
            PropertiesValidator validator = new PropertiesValidator(false);
            validator.AddValidationDescriptor(p1_valLen_min3_validator);

            string prop = "p_xxx";
            string value = "xxx";
            var res = validator.Validate(prop, value, out string invalidMsg);

            Assert.IsFalse(validator.AllowUnknownProperties);
            Assert.IsFalse(res);
            Assert.AreEqual(validator.UnknownPropertyInvalidMessageFormatter(prop), invalidMsg);
        }

        [TestMethod]
        public void ValidateMultipleCorrectProperties()
        {
            PropertiesValidator validator = new PropertiesValidator();
            validator.AddValidationDescriptor(p1_valLen_min3_validator);
            validator.AddValidationDescriptor(p2_val_is_int_validator);

            string v1 = "xxx";
            string v2 = "321123";

            var res = validator.Validate(new Dictionary<string, string>()
            {
                { p1_valLen_min3_validator.PropertyName, v1 },
                { p2_val_is_int_validator.PropertyName, v2 }
            });

            Assert.IsTrue(res.IsValid);
            Assert.AreEqual(0, res.PropertyErrors.Count());
            Assert.AreEqual(0, res.ValidationErrors.Count());
        }

        [TestMethod]
        public void ValidateMultipleInvalidProperties()
        {
            PropertiesValidator validator = new PropertiesValidator();
            validator.AddValidationDescriptor(p1_valLen_min3_validator);
            validator.AddValidationDescriptor(p2_val_is_int_validator);

            string v1 = "xx";
            string v2 = "321,123";

            var res = validator.Validate(new Dictionary<string, string>()
            {
                { p1_valLen_min3_validator.PropertyName, v1 },
                { p2_val_is_int_validator.PropertyName, v2 }
            });

            Assert.IsFalse(res.IsValid);
            Assert.AreEqual(2, res.ValidationErrors.Count());
            CollectionAssert.AreEquivalent(
                new[] { p1_valLen_min3_validator.InvalidMessage, p2_val_is_int_validator.InvalidMessage },
                res.ValidationErrors.ToArray());
        }

        [TestMethod]
        public void ValidateValidAndInvalidProperties()
        {
            PropertiesValidator validator = new PropertiesValidator();
            validator.AddValidationDescriptor(p1_valLen_min3_validator);
            validator.AddValidationDescriptor(p2_val_is_int_validator);

            string v1 = "xxx";
            string v2 = "321,123";

            var res = validator.Validate(new Dictionary<string, string>()
            {
                { p1_valLen_min3_validator.PropertyName, v1 },
                { p2_val_is_int_validator.PropertyName, v2 }
            });

            Assert.IsFalse(res.IsValid);
            Assert.AreEqual(1, res.ValidationErrors.Count());
            CollectionAssert.AreEquivalent(
                new[] { p2_val_is_int_validator.InvalidMessage },
                res.ValidationErrors.ToArray());
        }
    }


    public class ValidationTestClass
    {
        public const string PROP_1_NAME = "p1";
        public const string PROP_2_NAME = "p2";
        public const string PROP_3_NAME = "p3";
        public const string PROP_4_NAME = "p4";

        [JsonProperty(PropertyName = PROP_1_NAME)]
        public string Prop1 { get; set; }
        [JsonProperty(PropertyName = PROP_2_NAME)]
        public int Prop2 { get; set; }
        [JsonProperty(PropertyName = PROP_3_NAME)]
        public DateTime Prop3 { get; set; }
        [JsonProperty(PropertyName = PROP_4_NAME)]
        public Type Prop4 { get; set; }

        public string Prop5 { get; set; }
        public int Prop6 { get; set; }
        public DateTime Prop7 { get; set; }
        public Type Prop8 { get; set; }

        public static ValidationTestClass GetEmptyInstance()
        {
            return new ValidationTestClass();
        }

        public static ValidationTestClass GetFilledInstance()
        {
            return new ValidationTestClass()
            {
                Prop1 = "xxx",
                Prop2 = 123,
                Prop3 = DateTime.UtcNow,
                Prop4 = typeof(ValidationTestClass),
                Prop5 = "xxx",
                Prop6 = 123,
                Prop7 = DateTime.UtcNow,
                Prop8 = typeof(ValidationTestClass)
            };
        }
    }
}
