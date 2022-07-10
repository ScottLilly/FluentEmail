using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace FluentEmail
{
    internal static class ExtensionMethods
    {
        internal static bool IsEmpty(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        internal static bool IsNotEmpty(this string text)
        {
            return !text.IsEmpty();
        }

        internal static bool Matches(this string text, 
            string comparisonText, bool isCaseSensitive = true)
        {
            return text.Trim().Equals(comparisonText.Trim(),
                isCaseSensitive
                    ? StringComparison.InvariantCulture
                    : StringComparison.InvariantCultureIgnoreCase);
        }

        internal static bool None<T>(this IEnumerable<T> elements, 
            Func<T, bool> func = null)
        {
            return func == null
                ? !elements.Any()
                : !elements.Any(func.Invoke);
        }
    }
}
