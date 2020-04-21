using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Giftins.Core.ComponentModel
{
    [JsonConverter(typeof(ClassEnumerationJsonConverter))]
    public abstract class ClassEnumeration : IComparable
    {
        protected const int NAME_LENGHT_LIMIT = 64;
        protected const string NAME_REGEX_PATTERN = @"^[a-zA-Z][\w_]*$";
        protected static readonly Regex _namingRuleCheck = new Regex(NAME_REGEX_PATTERN, RegexOptions.Compiled);

        protected const string NAME_LENGTH_EXCEEDED_EXCEPTION_MESSAGE
            = "Name length limited at 64 characters";
        protected const string NAME_INVALID_EXCEPTION_MESSAGE
            = "Invalid name. You can use only cyrilic letters, digits and underline. First character must be a letter.";

        public int Id { get; }
        public string Name { get; }

        protected static readonly Dictionary<Type, ClassEnumeration[]> _registredTypes
            = new Dictionary<Type, ClassEnumeration[]>();

        protected ClassEnumeration(Type classType, int id, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (name.Length > NAME_LENGHT_LIMIT)
                throw new ArgumentException(NAME_LENGTH_EXCEEDED_EXCEPTION_MESSAGE, nameof(name));
            if (!_namingRuleCheck.IsMatch(name))
                throw new ArgumentException(NAME_INVALID_EXCEPTION_MESSAGE, nameof(name));

            if (!_registredTypes.ContainsKey(classType))
            {
                Id = id;
                Name = name;
                _registredTypes.Add(classType, new ClassEnumeration[1] { this });
            }
            else
            {
                if (_registredTypes[classType].Any(e => e.Id == id))
                    throw new ArgumentException("Enumeration with same ID is already defined.", nameof(id));

                if (_registredTypes[classType].Any(e => e.Name == name))
                    throw new ArgumentException("Enumeration with same name is already defined.", nameof(name));

                var registred = _registredTypes[classType];
                registred.Append(this);
                _registredTypes[classType] = registred.OrderBy(e => e.Id).ToArray();
            }
        }

        protected static IEnumerable<ClassEnumeration> GetList(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!_registredTypes.ContainsKey(type)) // All ClassEnumerations register on creating
                throw new ArgumentException($"Type is not {nameof(ClassEnumeration)}.", nameof(type));

            return _registredTypes[type];
        }
        protected static IEnumerable<T> GetList<T>()
            where T: ClassEnumeration
        {
            Type type = typeof(T);
            if (_registredTypes.ContainsKey(type))
                return _registredTypes[typeof(T)] as IEnumerable<T>;
            else
                return Array.Empty<T>();
        }

        protected static bool IsRegistred(Type type, int id)
        {
            return GetList(type).Any(e => e.Id == id);
        }
        protected static bool IsRegistred<T>(int id)
            where T: ClassEnumeration
        {
            return GetList<T>().Any(e => e.Id == id);
        }

        protected static bool IsRegistred(Type type, string name)
        {
            return GetList(type).Any(e => e.Name == name);
        }
        protected static bool IsRegistred<T>(string name)
            where T: ClassEnumeration
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            return GetList<T>().Any(e => e.Name == name);
        }

        public override string ToString() => this.Id.ToString();

        /// <summary>
        /// Format class to string like <see cref="Enum"/>
        /// </summary>
        /// <param name="format">Format string (supports "G", "D")</param>
        /// <exception cref="FormatException">Unknown format</exception>
        public virtual string ToString(string format)
        {
            switch (format)
            {
                case "d":
                    goto case "D";
                case "D":
                    return this.Id.ToString();
                case "g":
                    goto case "G";
                case "G":
                    return this.Name;
                case null:
                    goto case "G";
                case "":
                    goto case "G";
                default:
                    throw new FormatException("Supporting formats are \"G\", \"D\".");
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ClassEnumeration otherValue))
                return false;

            if (GetType().Equals(obj.GetType()))
            {
                return Id.Equals(otherValue.Id);
            }
            return false;
        }

        public int CompareTo(object other)
        {
            return Id.CompareTo(((ClassEnumeration)other).Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Throw <see cref="ArgumentException"/> with list of described values of enumeration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="possibleValues"></param>
        protected static void ThrowNotRegistred<T>(IEnumerable<T> possibleValues)
            where T: ClassEnumeration
        {
            throw new ArgumentException($"Possible values for {nameof(T)}: {String.Join(",", possibleValues.Select(s => $"{s.Id} ({s.Name})"))}");
        }

        protected static T Parse<T>(int id)
            where T: ClassEnumeration
        {
            Type type = typeof(T);

            if (_registredTypes.ContainsKey(type))
            {
                return _registredTypes[type].FirstOrDefault(e => e.Id == id) as T 
                    ?? throw new ArgumentException($"Enumeration '{type.Name}' does not contain option with Id '{id}'.", nameof(id));
            }

            throw new InvalidCastException();
        }
        protected static bool TryParse<T>(int id, out T result)
            where T: ClassEnumeration
        {
            Type type = typeof(T);

            if (_registredTypes.ContainsKey(type))
            {
                result = _registredTypes[type].FirstOrDefault(e => e.Id == id) as T;
                return result != null;
            }

            result = null;
            return false;
        }

        protected static T Parse<T>(string value)
            where T: ClassEnumeration
        {
            Type type = typeof(T);

            if (_registredTypes.ContainsKey(type))
            {
                if (int.TryParse(value, out int id))
                {
                    return _registredTypes[type].FirstOrDefault(e => e.Id == id) as T
                        ?? throw new ArgumentException($"Enumeration '{type.Name}' does not contain option with Id '{id}'.", nameof(id));
                }

                return _registredTypes[type].FirstOrDefault(e => e.Name == value) as T
                    ?? throw new ArgumentException($"Enumeration '{type.Name}' does not contain option with name '{value}'.", nameof(id));
            }

            throw new InvalidCastException();
        }
        protected static bool TryParse<T>(string value, out T result)
            where T: ClassEnumeration
        {
            Type type = typeof(T);

            if (_registredTypes.ContainsKey(type))
            {
                if (int.TryParse(value, out int id))
                {
                    result = _registredTypes[type].FirstOrDefault(e => e.Id == id) as T;
                }
                else
                {
                    result = _registredTypes[type].FirstOrDefault(e => e.Name == value) as T;
                }

                return result != null;
            }

            throw new InvalidCastException();
        }

        public static implicit operator int(ClassEnumeration value)
        {
            return value.Id;
        }
    }

    public abstract class ClassEnumeration<T> : ClassEnumeration
        where T: ClassEnumeration
    {
        protected ClassEnumeration(int id, string name)
            : base(typeof(T), id, name)
        { }

        public static IEnumerable<T> List => GetList<T>();

        public static bool IsRegistred(int id) => IsRegistred<T>(id);
        public static bool IsRegistred(string name) => IsRegistred<T>(name);

        public static T Parse(int id) => Parse<T>(id);
        protected static T Parse(int? id, T defaultValue)
        {
            return id.HasValue
                ? Parse(id.Value)
                : defaultValue;
        }

        public static T Parse(string value) => Parse<T>(value);
        protected static T Parse(string value, T defaultValue)
        {
            return string.IsNullOrEmpty(value)
                ? defaultValue
                : Parse(value);
        }

        public static bool TryParse(int id, out T result) => TryParse<T>(id, out result);
        public static bool TryParse(string value, out T result) => TryParse<T>(value, out result);
    }
}
