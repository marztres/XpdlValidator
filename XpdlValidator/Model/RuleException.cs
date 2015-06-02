using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    class RuleException : Exception
    {
        public XDocument xmlXDocument { get; set; } //Xml completo
        public XElement xElement { get; set; } //XElement del error.
        public string elementName
        {
            get
            {
                return xElement.Name.LocalName;
            }
        }
        public string XPath { get; set; }

        RuleException(string message, XElement xElement, XDocument xmlXDocument)
            : base(message) 
        {
            this.xElement = xElement;
            this.xmlXDocument = xmlXDocument;
        }

        private string getXPath(XElement _xElement, XDocument xmlXDocument)
        {
            return "";
        }
    }
}
