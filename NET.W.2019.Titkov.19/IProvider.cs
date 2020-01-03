using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Titkov._19
{
    /// <summary>
    /// Provides methods to get collection from some source.
    /// </summary>
    public interface IProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Collection of strings.</returns>
        IEnumerable<string> Provide();
    }
}
