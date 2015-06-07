using System;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    public class RuleException : ApplicationException
    {
        public XElement XElement { get; private set; } //XElement del error.

        public string Id
        {
            get
            {
                return XElement.Attribute("Id").Value;
            }
        }
        public string Name
        {
            get
            {
                return XElement.Attribute("Name").Value;
            }
        }
        public string ElementName
        {
            get
            {
                return XElement.Name.LocalName;
            }
        }
        public string XPath { get; set; }
        public string TypeActivity { get; set;}

        public RuleException(string message, XElement xElement,string typeActivity)
            : base(message) 
        {
            this.XElement = xElement;
            XPath = GetPath(xElement);
            this.TypeActivity = typeActivity; 
        }

        private string GetPath(XElement element)
        {
            return string.Join("/", element.AncestorsAndSelf().Reverse()
                .Select(e =>
                {
                    var index = GetIndex(e);

                    return index == 1 ? e.Name.LocalName : string.Format("{0}[{1}]", e.Name.LocalName, GetIndex(e));
                }));

        }

        private static int GetIndex(XElement element)
        {
            if (element.Parent == null)
            {
                return 1;
            }

            return 1 + element.Parent.Elements(element.Name.LocalName).TakeWhile(e => e != element).Count();
        }
    }
}
