using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class RuleException : ApplicationException
    {
        public XDocument xmlXDocument { get; set; } //XDocument
        public XElement xElement { get; set; } //XElement del error.

        public string id
        {
            get
            {
                return xElement.Attribute("Id").Value;
            }
        }
        public string name
        {
            get
            {
                return xElement.Attribute("Name").Value;
            }
        }
        public string elementName
        {
            get
            {
                return xElement.Name.LocalName;
            }
        }
        public string XPath { get; set; }
        public string typeActivity { get; set;}

        public RuleException(string message, XElement xElement, XDocument xmlXDocument,string typeActivity)
            : base(message) 
        {
            this.xElement = xElement;
            this.xmlXDocument = xmlXDocument;
            XPath = getXPath(xElement, xmlXDocument);
            this.typeActivity = typeActivity; 
        }

        private string getXPath(XElement _xElement, XDocument xmlXDocument)
        {
            return "parent/children/son/producto";
        }
    }
}
