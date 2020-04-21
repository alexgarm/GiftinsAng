using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Giftins.Core.ComponentModel
{
    public static class ClassEnumerationExtension
    {
        /// <summary>
        /// Convert enumeration to Dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<int, string>> ToDictionary<T>(this IEnumerable<T> enumeration)
            where T: ClassEnumeration
        {
            return enumeration.Select(e => new KeyValuePair<int, string>(e.Id, e.Name));
        }

        public static IEnumerable<int> ToIdEnumerable<T>(this IEnumerable<T> enumeration)
            where T: ClassEnumeration
        {
            return enumeration.Select(e => e.Id);
        }

        public static IEnumerable<string> ToNameEnumerable<T>(this IEnumerable<T> enumeration)
            where T : ClassEnumeration
        {
            return enumeration.Select(e => e.Name);
        }
    }
}
