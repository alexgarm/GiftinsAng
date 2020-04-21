using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

using Giftins.Core.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Giftins.Core.ComponentModel.Tests
{
    [TestClass]
    public class GJsonResultTest
    {
        /*
        [TestMethod]
        public void NewNullCorrectJson()
        {
            const string expect =
                @"{
                    'RESP': 'ok'
                }";

            GJsonResult actual = new GJsonResult(null as object);

            var expectJson = JToken.Parse(expect);
            var actualJson = JToken.FromObject(actual.Value);
            Assert.IsTrue(JToken.DeepEquals(expectJson, actualJson));
        }

        [TestMethod]
        public void NewTrueCorrectJson()
        {
            const string expect =
                @"{
                    'RESP': 'ok',
                    'RES': true
                }";

            GJsonResult actual = new GJsonResult(true);

            var expectJson = JToken.Parse(expect);
            var actualJson = JToken.FromObject(actual.Value);
            Assert.IsTrue(JToken.DeepEquals(expectJson, actualJson));
        }

        [TestMethod]
        public void NewFalseCorrectJson()
        {
            const string expect =
                @"{
                    'RESP': 'ok',
                    'RES': false
                }";

            GJsonResult actual = new GJsonResult(false);

            var expectJson = JToken.Parse(expect);
            var actualJson = JToken.FromObject(actual.Value);
            Assert.IsTrue(JToken.DeepEquals(expectJson, actualJson));
        }

        [TestMethod]
        public void NewFloatCorrectJson()
        {
            float value = 3.25f;
            const string expect =
                @"{
                    'RESP': 'ok',
                    'RES': 3.25
                }";

            GJsonResult actual = new GJsonResult(value);

            var expectJson = JToken.Parse(expect);
            var actualJson = JToken.FromObject(actual.Value);
            Assert.IsTrue(JToken.DeepEquals(expectJson, actualJson));
        }

        [TestMethod]
        public void NewObjectCorrectJson()
        {
            const string expect =
                @"{
                    'RESP': 'ok',
                    'RES': {
                        'string': 'string',
                        'int': 123,
                        'float': 123.45,
                        'null': null,
                        'object': {
                            'key': 'name',
                            'value': 'value'
                        },
                        'array': [ 'a', 'b', 'cde...' ],
                        'dict': {
                            'key1': 'val1',
                            'key2': 'val2'
                        }
                    }
                }";

            GJsonResult actual = new GJsonResult(new
            {
                @string = "string",
                @int = 123,
                @float = 123.45d,
                @null = null as object,
                @object = new
                {
                    key = "name",
                    value = "value"
                },
                array = new[] { "a", "b", "cde..." },
                dict = new Dictionary<string, string>()
                    {
                        { "key1", "val1" },
                        { "key2", "val2" }
                    }
            });

            var expectJson = JToken.Parse(expect);
            var actualJson = JToken.FromObject(actual.Value);
            Assert.IsTrue(JToken.DeepEquals(expectJson, actualJson));
        }

        [TestMethod]
        public void NewErrorCorrectJson()
        {
            string expect =
                $@"{{
                    'RESP': 'fail',
                    'ERROR': {{
                        'CODE': 5,
                        'MSG': '{GiftinsErrorResponse.MSG_BAD_REQUEST_DEFAULT}'
                    }}
                }}";

            GJsonResult actual = new GJsonResult(GiftinsErrorResponse.BadRequest());

            var expectJson = JToken.Parse(expect);
            var actualJson = JToken.FromObject(actual.Value);
            Assert.IsTrue(JToken.DeepEquals(expectJson, actualJson));
        }

        [TestMethod]
        public void NewErrorWithCustomMessageCorrectJson()
        {
            string messageText = "My custom error text.";
            string expect =
                $@"{{
                    'RESP': 'fail',
                    'ERROR': {{
                        'CODE': 5,
                        'MSG': '{messageText}'
                    }}
                }}";

            GJsonResult actual = new GJsonResult(GiftinsErrorResponse.BadRequest(messageText));

            var expectJson = JToken.Parse(expect);
            var actualJson = JToken.FromObject(actual.Value);
            Assert.IsTrue(JToken.DeepEquals(expectJson, actualJson));
        }

        [TestMethod]
        public void NewNullErrorThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new GJsonResult(null);
            });
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new GJsonResult(null as GiftinsErrorResponse);
            });
        }
    }
    */
    }
}
