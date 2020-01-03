using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NET.W._2019.Titkov._19
{
    /// <summary>
    /// Gets info from file.
    /// </summary>
    public class FileProvider : IProvider
    {
        private readonly string filePath;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="filePath">File path.</param>
        public FileProvider(string filePath)
        {
            this.filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        /// <summary>
        /// Gets info from file.
        /// </summary>
        /// <returns>Info as a collection of strings.</returns>
        public IEnumerable<string> Provide()
        {
            var readedLines = new List<string>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    readedLines.Add(line);
                }
            }

            return readedLines;
        }
    }
}
