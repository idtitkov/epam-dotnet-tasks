using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NET.W._2019.Titkov._19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string txtFilePath = "D:\\Downloads\\urls.txt";
            string xmlFilePath = "D:\\Downloads\\parseResults.xml";

            IProvider provider = new FileProvider(txtFilePath);

            IValidator validator = new UrlValidator();
            UrlParser parser = new UrlParser(validator);

            ILogger logger = LogManager.GetCurrentClassLogger();

            URLtoXMLConverter converter = new URLtoXMLConverter(provider, parser, xmlFilePath, logger);
            converter.Convert();
        }
    }
}
