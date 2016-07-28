using System;
using System.Collections.Generic;
using System.Linq;

namespace EventProviderGenerator
{
    public static class StringExtensions
    {
        public static string GetSafeString(this string name)
        {
            return name.Replace('-', '_').Replace('.', '_');
        }
    }
}
