using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NLog;

namespace NET.W._2019.Titkov._19
{
    /// <summary>
    /// Converts UrlAddress to XML format.
    /// </summary>
    public class URLtoXMLConverter
    {
        private IProvider provider;
        private UrlParser parser;
        private string xmlFilePath;
        private ILogger logger;

        public URLtoXMLConverter(IProvider provider, UrlParser parser, string xmlFilePath, ILogger logger)
        {
            this.provider = provider ?? throw new ArgumentNullException(nameof(provider));
            this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
            this.xmlFilePath = xmlFilePath ?? throw new ArgumentNullException(nameof(xmlFilePath));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Performing convertion.
        /// </summary>
        public void Convert()
        {
            XDocument document = new XDocument();
            XElement root = new XElement("urlAddresses");

            foreach (var urlAddress in provider.Provide())
            {
                try
                {
                    root.Add(CreateXmlElement(parser.Parse(urlAddress)));
                    logger.Info("Parsed succesfully: " + urlAddress);
                }
                catch (Exception e)
                {
                    logger.Error(e, "Error: " + urlAddress + ". " + e.Message);
                }
            }

            document.Add(root);
            document.Save(xmlFilePath);
        }

        private static XElement CreateXmlElement(UrlAddress urlAddress)
        {
            XElement xmlElement = new XElement("urlAdress");
            XElement hostElement = new XElement("host", new XAttribute("name", urlAddress.HostName));
            xmlElement.Add(hostElement);

            XElement uri = new XElement("uri");
            foreach (var item in urlAddress.Segments)
            {
                uri.Add(new XElement("segment", item));
            }

            xmlElement.Add(uri);

            XElement parameters = new XElement("parameters");
            foreach (var item in urlAddress.Parameters)
            {
                parameters.Add(new XElement(
                    "parameter",
                    new XAttribute("value", item.Value),
                    new XAttribute("key", item.Key)));
            }

            if (parameters.HasElements)
            {
                xmlElement.Add(parameters);
            }

            return xmlElement;
        }
    }
}
