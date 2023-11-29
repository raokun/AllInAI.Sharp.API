using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Extensions {
    public static class StringExtensions {
        /// <summary>
        ///     Remove the search string from the beginning of string if it exists
        /// </summary>
        /// <param name="text"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static string RemoveIfStartWith(this string text, string search) => text.IndexOf(search, StringComparison.Ordinal) == 0 ? text.Substring(search.Length) : text;
    }
}
