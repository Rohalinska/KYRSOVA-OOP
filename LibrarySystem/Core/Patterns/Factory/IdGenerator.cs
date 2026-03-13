using System;

namespace LibrarySystem.Core.Patterns.Factory
{
    internal static class IdGenerator
    {
        public static string Generate(string prefix)
        {
            return $"{prefix}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
        }
    }
}