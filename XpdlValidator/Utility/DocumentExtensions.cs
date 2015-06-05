using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XpdlValidator.Utility
{
    /// <summary>
    /// Clase de utilidad para convertir XmlDocument a Xdocument y viceversa.
    /// </summary>
    /// <remarks>
    /// Convertir XmlDocument a XDocument
    /// Convertir Xdocumente a XmlDocument
    /// Formatear un string xml.
    /// </remarks>
    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        /// <summary>
        /// Convierte un XmlDocument a Xdocument
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns> XDocument </returns>
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

        /// <summary>
        /// Convierte un XmlDocument en string indentado de xml.
        /// </summary>
        /// <param name="doc"> Documento Xml a convertir a string y formatear.</param>
        /// <returns> string con xmlDocument indentado.</returns>
        public static string BeautifyXml(XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }
    }
}
