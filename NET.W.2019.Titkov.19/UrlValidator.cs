using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._19
{
    /// <summary>
    /// Provides methods to validate data in string format.
    /// </summary>
    public class UrlValidator : IValidator
    {
        private const string URLPATTERN = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

        /// <summary>
        /// Validates data in string format.
        /// </summary>
        /// <param name="value">String to validate.</param>
        /// <returns>True if data is valid, otherwise false.</returns>
        public bool IsValid(string value) => Regex.IsMatch(value, URLPATTERN, RegexOptions.IgnoreCase);
    }
}
