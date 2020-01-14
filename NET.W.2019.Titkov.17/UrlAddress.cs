using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._19
{
    /// <summary>
    /// Template for URL address.
    /// </summary>
    public class UrlAddress
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public UrlAddress()
        {
            Segments = new List<string>();
            Parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// Protocol.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Host name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Segments list.
        /// </summary>
        public List<string> Segments { get; set; }

        /// <summary>
        /// Parameters as key and value.
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }
    }
}
