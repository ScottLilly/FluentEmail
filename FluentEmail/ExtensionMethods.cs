using System;

namespace FluentEmail
{
    internal static class ExtensionMethods
    {
        internal static bool Matches(this string text, 
            string comparisonText, bool isCaseSensitive = true)
        {
            return text.Trim().Equals(comparisonText.Trim(),
                isCaseSensitive
                    ? StringComparison.InvariantCulture
                    : StringComparison.InvariantCultureIgnoreCase);
        }
    }
}