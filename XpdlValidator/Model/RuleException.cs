using System;
using System.Linq;
using System.Xml.Linq;

namespace XpdlValidator.Model
{
    /// <summary>
    /// Model of an BPMN rule Exception
    /// </summary>
    public class RuleException : ApplicationException
    {
        public XElement XElement { get; private set; } //XElement reference.

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

        /// <summary>
        /// Get the absolute XPath to a given XElement
        /// Took from 
        /// the code was got from http://stackoverflow.com/questions/451950/get-the-xpath-to-an-xelement
        /// </summary>
        /// <param name="element"> XElement reference with error </param>
        /// <returns> XPath of the element </returns>
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
