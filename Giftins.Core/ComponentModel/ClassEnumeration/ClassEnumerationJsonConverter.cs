using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Giftins.Core.ComponentModel
{
    public class ClassEnumerationJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ClassEnumeration).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            serializer.Serialize(writer, ((ClassEnumeration)value).Id);
        }
    }
}
