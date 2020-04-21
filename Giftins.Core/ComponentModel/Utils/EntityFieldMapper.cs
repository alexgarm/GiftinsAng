using System;
using System.Collections.Generic;
using System.Text;

namespace Giftins.Core.ComponentModel
{
    /// <summary>
    /// Mapper that converts string values to corresponding object fields
    /// </summary>
    /// <typeparam name="MT">Object type</typeparam>
    public abstract class EntityFieldMapper<MT>
    {
        /// <summary>
        /// Set value to object field
        /// </summary>
        /// <param name="entity">Entity object</param>
        /// <param name="field">Field name</param>
        /// <param name="value">New value</param>
        public abstract bool SetField(MT entity, string field, string value, out string errorMessage);
        
        /// <summary>
        /// Set values to object fields
        /// </summary>
        /// <param name="entity">Entity object</param>
        /// <param name="values">New values</param>
        public virtual bool SetFields(MT entity, IEnumerable<KeyValuePair<string, string>> values, out string errorMessage)
        {
            foreach (var e in values)
            {
                if (!SetField(entity, e.Key, e.Value, out errorMessage))
                    return false;
            }
            errorMessage = null;
            return true;
        }

        protected static string InvalidPropertyValue(string propertyName) => $"Invalid property value for \"{propertyName}\".";
        protected static string ValueCannotBeEmpty(string propertyName) => $"Property \"{propertyName}\" cannot be empty.";
    }
}
