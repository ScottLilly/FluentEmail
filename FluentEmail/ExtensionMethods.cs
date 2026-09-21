using System;

namespace FluentEmail
{
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Compares two email addresses. The comparison ignores case, because domains are case
        /// insensitive by definition and no mail provider in practice treats the local part as
        /// case sensitive, so two addresses differing only in case reach the same person.
        /// </summary>
        internal static bool Matches(this string text, string comparisonText)
        {
            return text.Equals(comparisonText, StringComparison.OrdinalIgnoreCase);
        }
    }
}
