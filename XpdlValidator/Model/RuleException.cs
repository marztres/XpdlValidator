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
            XPath = GetPath(xElement);
            this.typeActivity = typeActivity; 
        }

        public string GetPath(XElement element)
        {
            return string.Join("/", element.AncestorsAndSelf().Reverse()
                .Select(e =>
                {
                    var index = GetIndex(e);

                    if (index == 1)
                    {
                        return e.Name.LocalName;
                    }

                    return string.Format("{0}[{1}]", e.Name.LocalName, GetIndex(e));
                }));

        }

        private int GetIndex(XElement element)
        {
            var i = 1;

            if (element.Parent == null)
            {
                return 1;
            }

            foreach (var e in element.Parent.Elements(element.Name.LocalName))
            {
                if (e == element)
                {
                    break;
                }

                i++;
            }

            return i;
        }
    }
}
