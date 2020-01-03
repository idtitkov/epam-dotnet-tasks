using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._19
{
    public class UrlParser
    {
        private readonly IValidator validator;

        private readonly char schemeHostSeparator = ':';
        private readonly char segmentSeparator = '/';
        private readonly char beginOfParamaters = '?';
        private readonly char parametersSeparator = '&';
        private readonly char keyValueSeparator = '=';

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="validator">Validator to check is string possible to parse.</param>
        public UrlParser(IValidator validator)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Parses string to UrlAddress class.
        /// </summary>
        /// <param name="sourceString">String to parse.</param>
        /// <returns></returns>
        public UrlAddress Parse(string sourceString)
        {
            _ = sourceString ?? throw new ArgumentNullException();
            _ = validator ?? throw new ArgumentNullException();

            if (!validator.IsValid(sourceString))
            {
                throw new ArgumentException("Source string is not a valid URL", nameof(sourceString));
            }

            UrlAddress url = new UrlAddress();

            url.Protocol = sourceString.Substring(0, sourceString.IndexOf(schemeHostSeparator));
            sourceString = sourceString.Substring(sourceString.IndexOf(schemeHostSeparator) + 3);

            url.HostName = sourceString.Substring(0, sourceString.IndexOf(segmentSeparator));
            sourceString = sourceString.Substring(sourceString.IndexOf(segmentSeparator) + 1);

            if (sourceString.Contains(beginOfParamaters))
            {
                var segments = sourceString.Substring(0, sourceString.IndexOf(beginOfParamaters));
                foreach (string segment in segments.Split(new char[] { segmentSeparator }, StringSplitOptions.RemoveEmptyEntries))
                {
                    url.Segments.Add(segment);
                }

                sourceString = sourceString.Substring(sourceString.IndexOf(beginOfParamaters) + 1);

                var parameters = sourceString.Split(parametersSeparator);
                foreach (var parameter in parameters)
                {
                    var keyvaluePair = parameter.Split(keyValueSeparator);
                    url.Parameters.Add(keyvaluePair[0], keyvaluePair[1]);
                }
            }
            else
            {
                foreach (var segment in sourceString.Split(new char[] { segmentSeparator }, StringSplitOptions.RemoveEmptyEntries))
                {
                    url.Segments.Add(segment);
                }
            }

            return url;
        }
    }
}
